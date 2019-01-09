using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using ZOGLAB.MMMS.Authorization.Users;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// Receive service that is used by 收发单的增删改查.
    /// </summary>
    public class ReceiveAppService : MMMSAppServiceBase, IReceiveAppService
    {
        private readonly IRepository<BD_Receive, long> _receiveRepository;
        private readonly IRepository<BD_InstrumentTest, long> _instrumentTestRepository;
        private readonly IRepository<BD_ReceiveInstrument, long> _receiveInstrumentRepository;
        private readonly IRepository<BD_Test, long> _testRepository;
        private readonly UserManager _userManager;
        private readonly IInstrumentManager _instrumentManager;

        #region 1.服务注入
        public ReceiveAppService(
               IRepository<BD_Receive, long> receiveRepository,
               IRepository<BD_InstrumentTest, long> instrumentTestRepository,
               IRepository<BD_ReceiveInstrument, long> receiveInstrumentRepository,
               IRepository<BD_Test, long> testRepository,
               UserManager userManager,
        IInstrumentManager instrumentManager)
        {
            _receiveRepository = receiveRepository;
            _instrumentTestRepository = instrumentTestRepository;
            _receiveInstrumentRepository = receiveInstrumentRepository;
            _testRepository = testRepository;
            _userManager = userManager;
            _instrumentManager = instrumentManager;
        }
        #endregion

        #region 2.登记单   3# Receive OrderHeader

        //1.获取所有登记单
        public async Task<List<ReceiveEditDto>> GetAll()
        {
            var query = await _receiveRepository.GetAll().ToListAsync();
            return query.MapTo<List<ReceiveEditDto>>();
        }

        public ReceiveEditDto GetReceiveById(NullableIdDto<long> input)
        {
            var receiveEditDto = new ReceiveEditDto();

            if (input.Id.HasValue) //Editing existing role?
            {
                Debug.Assert(input.Id != null, "编辑时，ID不得为空！");
                var currentReceive = _receiveRepository.Get(input.Id.Value);

                receiveEditDto = currentReceive.MapTo<ReceiveEditDto>();
            }

            return receiveEditDto;
        }

        public async Task<long> CreateOrUpdateReveice(ReceiveEditDto input)
        {
            BD_Receive item = input.MapTo<BD_Receive>();
            //BD_Receive src = _receiveRepository.Get(input.Id.Value).Attach();

            //context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return await _receiveRepository.InsertOrUpdateAndGetIdAsync(item);
        }

        public void DeleteItem(EntityDto<long> input)
        {
            var receiveToDel = _receiveRepository.Get(input.Id);

            if (receiveToDel == null)
            {
                throw new Exception("没有找到对应的收发单，无法删除！");
            }
            _receiveRepository.Delete(receiveToDel);
        }
        #endregion

        #region 3.仪器列表 5# ReceiveInstrument
        //1.获取已经登记的仪器列表
        public async Task<ReceiveWithItemsDto> GetReceiveWithItems(NullableIdDto<long> input)
        {
            ReceiveWithItemsDto receiveWithItemsDto = new ReceiveWithItemsDto { };
            if (input.Id.HasValue)
            {
                Debug.Assert(input.Id != null, "此查询送检单ID不得为空！");

                var receive = await _receiveRepository.GetAsync(input.Id.Value);

                receiveWithItemsDto.ReceiveId = receive.Id;
                receiveWithItemsDto.UnitName = receive.Unit.UnitName;
                receiveWithItemsDto.Number = receive.Number;

                var query = _instrumentManager.GetRegistedInstruments(receive);
                receiveWithItemsDto.RegistedInstruments = query.MapTo<List<InstrumentFReadDto>>();
            }
            return receiveWithItemsDto;
        }

        public async Task AddInstrumentToReceive(long instrumentId, long receiveId)
        {
            await _instrumentManager.AddToReceiveAsync(instrumentId, receiveId);
        }

        public async Task RemoveInstrumentFromReceive(long instrumentId, long receiveId)
        {
            await _instrumentManager.RemoveFromReceiveAsync(instrumentId, receiveId);
        }

        #endregion

        #region 4.检测业务 6# InstrumentTest

        //1.获取所有 InstrumentTests By ReceiveInstrumentId TODO
        public List<IntestEditDto> GetInstrumentTestsByReInId(NullableIdDto<long> input)
        {
            var result = new List<IntestEditDto> { };

            if (input.Id.HasValue) //Editing existing role?
            {
                Debug.Assert(input.Id != null, "编辑时，ID不得为空！");

                result = _instrumentTestRepository.GetAllIncluding(q => q.CheckType)
                .Where(w => w.ReceiveInstrument_ID == input.Id.Value)
                .Select(s => new IntestEditDto
                {
                    Id = s.Id,
                    ReceiveInstrument_ID = s.ReceiveInstrument_ID,
                    CheckType_ID = s.CheckType_ID,
                    CheckName = s.CheckType.CheckName,
                    Number = s.Number,
                    CaliValidate = s.CaliValidate,
                    CaliU = s.CaliU,
                    Address = s.Address,
                    StrFlag = s.StrFlag
                }).ToList();
            }

            return result;
        }

        //2.获取 viewModel RIWithITCount
        public List<InstrumentWithTCountDto> GetInstrumentWithTCountByReId(NullableIdDto<long> input)
        {
            var result = new List<InstrumentWithTCountDto> { };

            if (input.Id.HasValue) //Editing existing role?
            {
                Debug.Assert(input.Id != null, "编辑时，ID不得为空！");
                var reInstruments = _receiveInstrumentRepository.GetAllIncluding(q => q.Instrument)
                    .Where(q => q.Receive_ID == input.Id.Value);
                var inTests = _instrumentTestRepository.GetAll();

                result = reInstruments.GroupJoin(inTests,
                    reInstrument => reInstrument.Id,
                    inTest => inTest.ReceiveInstrument_ID,
                    (reInstrument, inTestGroup) => new InstrumentWithTCountDto
                    {
                        Id = reInstrument.Id,
                        SN = reInstrument.Instrument.SN,
                        Name = reInstrument.Instrument.Name,
                        Model = reInstrument.Instrument.Model,
                        CheckTypeCount = inTestGroup.Count(),
                    }).Distinct().OrderBy(q => q.Id).ToList();
            }

            return result;
        }

        //3.增加 CreatInstrumentTest
        /// <summary>
        /// CreatOrUpdateInstrumentTestF F 代表 Fast 快速添加 InstrumentTest
        /// </summary>
        /// <param name="input">IntestEditDto </param>
        /// <returns></returns>
        public async Task<long> CUInstrumentTestF(IntestEditDto input)
        {
            //if (input.Id.HasValue) {
            //    var query = await _instrumentTestRepository.FirstOrDefaultAsync(input.Id.Value);
            //    if (query == null)
            //    {
            //        throw new UserFriendlyException(L("CouldNotFoundTheTaskMessage"));
            //    }                   
            //}

            var item = input.MapTo<BD_InstrumentTest>();


            return await _instrumentTestRepository.InsertOrUpdateAndGetIdAsync(item);
        }

        public void DelInstrumentTest(NullableIdDto<long> input)
        {
            Debug.Assert(input.Id != null, "编辑时，ID不得为空！");
            _instrumentTestRepository.Delete(input.Id.Value);
        }
        #endregion



        #region 5.交接业务 7# Test
        //5.1 获取GetTests
        public async Task<PagedResultDto<TestListDto>> GetTests(GetTestsInput input)
        {
            var tests = _testRepository.GetAll().Include("MeteorType").Include("Installation").Include("User") //Step 01
                .Where(q => q.StartDate >= input.StartDate && q.StartDate <= input.FinishDate)
                .WhereIf(input.MeteorType_ID > 0, q => q.MeteorType_ID == input.MeteorType_ID)
                .WhereIf(input.VocationalWorkType > 0, q => q.VocationalWorkType == input.VocationalWorkType)
                .WhereIf(!input.Check_Num.IsNullOrWhiteSpace(), item => item.Check_Num.Contains(input.Check_Num));

            var query = from t in tests
                        join u in _userManager.Users
                        on t.CreatorUserId equals u.Id
                        select new TestListDto
                        {
                            Id = t.Id,
                            Check_Num = t.Check_Num,
                            MeteorType = t.MeteorType.Name,
                            StartDate = t.StartDate,
                            FinishDate = t.FinishDate,
                            User = u.Name,
                            VocationalWorkType = t.VocationalWorkType.ToString()
                        };

            var resultCount = await query.CountAsync();     //Step 02

            var resultList = await query
                    .AsNoTracking()
                    .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
                    .PageBy(input)
                    .ToListAsync();

            var testListDtos = resultList.MapTo<List<TestListDto>>();

            return new PagedResultDto<TestListDto>(resultCount, testListDtos);  //Step 03
        }

        //5.2 获取已经登记的仪器列表 用于交接挑选，带分页         
        public async Task<PagedResultDto<InTstListDto>> GetInstrumentTestsForHandOver(GetInstrumentTestsInput input)
        {
            var query = CreateInTstsQuery(input);    //Step 01

            var resultCount = await query.CountAsync(); //Step 02

            var inTstListDtos = await query
                                .AsNoTracking()
                                .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
                                .PageBy(input)
                                .ToListAsync();

            return new PagedResultDto<InTstListDto>(resultCount, inTstListDtos);  //Step 03
        }

        //5.2.1
        public async Task<List<InTstSelectionDto>> GetInstrumentTestsForSelection()
        {
            var reInstruments = _receiveInstrumentRepository.GetAllIncluding(q => q.Instrument);
            var inTsts = _instrumentTestRepository.GetAll().Include(q => q.ReceiveInstrument);

            var query = from re in reInstruments
                        join inTst in inTsts
                        on re.Id equals inTst.ReceiveInstrument_ID
                        where inTst.IntHandover == false && inTst.Test_ID == null
                        select new InTstSelectionDto
                        {
                            Id = inTst.Id,
                            InstrumentTest = inTst.Number + " " + re.Instrument.Name + " " + inTst.CheckType.CheckName,
                            Number = inTst.Number
                        };
            return await query.ToListAsync();
        }


        //5.3 生成或者更新 test单据
        public async Task CreateOrUpdateTest(TestEditDto input)
        {
            if (input.Id.HasValue)
            {
                await UpdateTest(input);
            }
            else
            {
                await CreateTest(input);
            }
        }

        //5.3.1 生成test单据，指定user
        public async Task<long> CreateTest(TestEditDto input)
        {
            BD_Test test = input.MapTo<BD_Test>();

            long newTask_Id = await _testRepository.InsertAndGetIdAsync(test);

            await CurrentUnitOfWork.SaveChangesAsync();

            await SetInstrumentTestsAsync(test.Id, input.InstrumentTestIds);

            //foreach (var id in input.InstrumentTestIds)
            //{
            //    var item = new BD_InstrumentTest { };
            //    item = _instrumentTestRepository.FirstOrDefault(i => i.Id == id);
            //    if (item != null)
            //    {
            //        if (item.Test_ID != null)
            //        {
            //            string body = String.Format("InstrumentTest编号：{0},检测项目：{1},已经在任务{2}中！", item.Id, item.CheckType.CheckName, item.Test_ID);
            //            throw new UserFriendlyException("检测单生成失败", body);
            //        }
            //        test.InstrumentTests.Add(item);
            //    }
            //}

            return newTask_Id;
        }

        //5.3.2 
        public async Task UpdateTest(TestEditDto input)
        {
            BD_Test test = input.MapTo<BD_Test>();

            await SetInstrumentTestsAsync(test.Id, input.InstrumentTestIds);

            await _testRepository.UpdateAsync(test);
        }

        //更新 Test.InstrumentTests
        [UnitOfWork]
        public async Task SetInstrumentTestsAsync(long testId, params long[] instrumentTestIds)
        {
            if (instrumentTestIds == null)
            {
                instrumentTestIds = new long[0];
            }

            var currentIts = _instrumentTestRepository.GetAll().Where(it => it.Test_ID == testId).ToList();

            //Remove from removed Its
            foreach (var currentIt in currentIts)
            {
                if (!instrumentTestIds.Contains(currentIt.Id))
                {
                    await RemoveFromTest(currentIt.Id);
                }
            }

            //Add to added Its
            foreach (var instrumentTestId in instrumentTestIds)
            {
                if (currentIts.All(it => it.Id != instrumentTestId))
                {
                    await AddToTest(testId, instrumentTestId);
                }
            }
        }

        //删除 instrumentTest.testId-->null
        [UnitOfWork]
        public async Task RemoveFromTest(long instrumentTestId)
        {
            var item = _instrumentTestRepository.FirstOrDefault(i => i.Id == instrumentTestId);
            if (item == null)
                return;
            item.Test_ID = null;
            item.IntHandover = false;
            await _instrumentTestRepository.UpdateAsync(item);
        }

        //增加 instrumentTest
        [UnitOfWork]
        public async Task AddToTest(long testId, long instrumentTestId)
        {
            var item = _instrumentTestRepository.FirstOrDefault(i => i.Id == instrumentTestId);
            if (item == null)
                return;
            item.Test_ID = testId;
            item.IntHandover = true;
            await _instrumentTestRepository.UpdateAsync(item);
        }


        private IQueryable<InTstListDto> CreateInTstsQuery(GetInstrumentTestsInput input)
        {
            var reInstruments = _receiveInstrumentRepository.GetAllIncluding(q => q.Instrument);
            var inTsts = _instrumentTestRepository.GetAll().Include(q => q.ReceiveInstrument).Include(q => q.User);

            var query = from re in reInstruments
                        join inTst in inTsts
                        on re.Id equals inTst.ReceiveInstrument_ID
                        select new InTstListDto
                        {
                            Id = inTst.Id,
                            InstrumentName = re.Instrument.Name,
                            Number = inTst.Number,
                            CheckType = inTst.CheckType.CheckName,
                            CheckTypeId = inTst.CheckType.Id,
                            CaliValidate = inTst.CaliValidate,
                            IntHandover = inTst.IntHandover,
                            User = inTst.UserId == null ? "暂无" : inTst.User.UserName,
                            UserId = inTst.UserId,
                            Calibration = inTst.Calibration,
                            CaliU = inTst.CaliU,
                            Address = inTst.Address,
                            StrFlag = inTst.StrFlag,
                            CreationTime = inTst.CreationTime
                        };

            query = query      //--查询过滤 Begin
                    .Where(q => q.IntHandover == input.IntHandover)     //是否交接？
                    .WhereIf(input.CheckTypeId > 0, item => item.CheckTypeId == input.CheckTypeId)        //检测类型
                    .WhereIf(input.UserId > 0, item => item.UserId == input.UserId)         //接收用户
                    .WhereIf(!input.Number.IsNullOrWhiteSpace(), item => item.Number.Contains(input.Number))    //仪器编号
                    .WhereIf(!input.Address.IsNullOrWhiteSpace(), item => item.Address.Contains(input.Address));    //实验地址                                                                                                             

            return query;
        }
        #endregion

        #region 8.LinqExp
        //-----> GroupJoin
        //contacts.GroupJoin(orders,
        //contact => contact.ContactID,
        //order => order.Contact.ContactID,
        //(contact, contactGroup) => new
        //{
        //    ContactID = contact.ContactID,
        //    OrderCount = contactGroup.Count(),
        //    Orders = contactGroup.Select(order => order)
        //});
        #endregion
    }
}
