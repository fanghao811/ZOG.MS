using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly IInstrumentManager _instrumentManager;


        public ReceiveAppService(
            IRepository<BD_Receive, long> receiveRepository, 
            IInstrumentManager instrumentManager)
        {
            _receiveRepository = receiveRepository;
            _instrumentManager = instrumentManager;
        }

        public async Task<List<BD_Receive>> GetAll()
        {
            var query = await _receiveRepository.GetAll().ToListAsync();
            return query;
        }

        public async Task CreateOrUpdateReveice(ReceiveEditDto input)
        {
            BD_Receive item = input.MapTo<BD_Receive>();
            await _receiveRepository.InsertOrUpdateAsync(item);
        }

        public async Task AddInstrumentToReceive(long instrumentId, long receiveId)
        {
            await _instrumentManager.AddToReceiveAsync(instrumentId, receiveId);
        }

        public async Task RemoveInstrumentFromReceive(long instrumentId, long receiveId)
        {
            await _instrumentManager.RemoveFromReceiveAsync(instrumentId, receiveId);
        }

        //public async Task<long> CreateReveice(ReceiveEditDto input)
        //{
        //    //We can use Logger, it's defined in ApplicationService class.
        //    Logger.Info("Creating a reveice for input: " + input);

        //    BD_Receive reveice = input.MapTo<BD_Receive>();

        //    return await _receiveRepository.InsertAndGetIdAsync(reveice);
        //}


        /// <summary>
        /// 过滤，排序，分页 获取标准器列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //public async Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input)
        //{
        //    var query = CreateStandardsQuery(input);    //Step 01

        //    var resultCount = await query.CountAsync(); //Step 02

        //    var results = await query
        //        .AsNoTracking()
        //        .OrderBy(input.Sorting) /*Exp: using System.Linq.Dynamic;*/
        //        .PageBy(input)
        //        .ToListAsync();
        //    var unitListDtos = results.MapTo<List<UnitListDto>>(); //Step 03

        //    return new PagedResultDto<UnitListDto>(resultCount, unitListDtos);  //Step 04
        //}

        //private IQueryable<BD_Unit> CreateStandardsQuery(GetUnitsInput input)
        //{
        //    var query = _unitRepository.GetAll()
        //                .WhereIf(!input.UnitName.IsNullOrWhiteSpace(), item => item.UnitName.Contains(input.UnitName)) //公司名
        //                .WhereIf(!input.Address.IsNullOrWhiteSpace(), item => item.Address.Contains(input.Address)) //地址
        //                .WhereIf(!input.Email.IsNullOrWhiteSpace(), item => item.Email.Contains(input.Email))
        //                .WhereIf(!input.Contact.IsNullOrWhiteSpace(), item => item.Contact.Contains(input.Contact))//联系人
        //                .WhereIf(!input.ContactTel.IsNullOrWhiteSpace(), item => item.ContactTel.Contains(input.ContactTel)); //联系人电话                                                                                                             
        //    return query;
        //}


        public void DeleteItem(EntityDto<long> input)
        {
            var receiveToDel = _receiveRepository.Get(input.Id);

            if (receiveToDel == null)
            {
                throw new Exception("没有找到对应的收发单，无法删除！");
            }

            _receiveRepository.Delete(receiveToDel);
        }
    }
}
