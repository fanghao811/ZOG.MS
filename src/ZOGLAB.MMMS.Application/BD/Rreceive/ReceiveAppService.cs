using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    /// <summary>
    /// Receive service that is used by 收发单的增删改查.
    /// </summary>
    public class ReceiveAppService : MMMSAppServiceBase, IReceiveAppService
    {

        private readonly IRepository<BD_Receive, long> _receiveRepository;
        private readonly IRepository<BD_InstrumentTest, long> _instrumentTestRepository;
        private readonly IInstrumentManager _instrumentManager;

        #region 1.服务注入
        public ReceiveAppService(
               IRepository<BD_Receive, long> receiveRepository,
               IRepository<BD_InstrumentTest, long> instrumentTestRepository,
               IInstrumentManager instrumentManager)
        {
            _receiveRepository = receiveRepository;
            _instrumentTestRepository = instrumentTestRepository;
            _instrumentManager = instrumentManager;

        }
        #endregion       

        #region 2.登记单 OrderHeader

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

        #region 3.仪器列表 OrderDetail
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

        #region 4.检测业务 Test

        //.获取所有 InstrumentTests By ReceiveInstrumentId TODO
        public List<InTstFRDto> GetInstrumentTestsByReInId(NullableIdDto<long> input)
        {
            var result = new List<InTstFRDto> { };

            if (input.Id.HasValue) //Editing existing role?
            {
                Debug.Assert(input.Id != null, "编辑时，ID不得为空！");

                result = _instrumentTestRepository.GetAllIncluding(q => q.CheckType)
                .Where(w => w.ReceiveInstrument_ID == input.Id.Value)
                .Select(s => new InTstFRDto
                {
                    CheckType = s.CheckType.CheckName,
                    Number = s.Number,
                    CaliValidateDate = s.CaliValidateDate,
                    CaliU = s.CaliU,
                    Address = s.Address,
                    StrFlag = s.StrFlag
                }).ToList();
            }

            return result;
        }

        //2.增加 CreatInstrumentTest

        /// <summary>
        /// CreatOrUpdateInstrumentTestF F 代表 Fast 快速添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CUInstrumentTestF(IntestCreatDto input)
        {
            await _instrumentTestRepository.InsertOrUpdateAsync(input.MapTo<BD_InstrumentTest>());
        }

        #endregion  
    }
}
