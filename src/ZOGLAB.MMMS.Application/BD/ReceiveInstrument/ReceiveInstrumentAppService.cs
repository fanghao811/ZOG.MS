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
    /// ReceiveInstrumentInstrument service that is used by 收发单的增删改查.
    /// </summary>
    public class ReceiveInstrumentAppService : MMMSAppServiceBase, IReceiveInstrumentAppService
    {
        private readonly IRepository<BD_ReceiveInstrument> _receiveInstrumentRepository;

        public ReceiveInstrumentAppService(IRepository<BD_ReceiveInstrument, long> receiveInstrumentRepository)
        {
            _receiveInstrumentRepository = receiveInstrumentRepository;
        }

        public async Task<List<BD_ReceiveInstrument>> GetAll()
        {
            var query = await _receiveInstrumentRepository.GetAll().ToListAsync();
            return query;
        }

        public async Task CreateOrUpdateReveice(ReceiveInstrumentEditDto input)
        {
            BD_ReceiveInstrument item = input.MapTo<BD_ReceiveInstrument>();
            await _receiveInstrumentRepository.InsertOrUpdateAsync(item);
        }

        //public async Task<long> CreateReveice(ReceiveInstrumentEditDto input)
        //{
        //    //We can use Logger, it's defined in ApplicationService class.
        //    Logger.Info("Creating a reveice for input: " + input);

        //    BD_ReceiveInstrument reveice = input.MapTo<BD_ReceiveInstrument>();

        //    return await _receiveInstrumentRepository.InsertAndGetIdAsync(reveice);
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


        public void DeleteDeceive(EntityDto<long> input)
        {
            var receiveInstrumentToDel = _receiveInstrumentRepository.Get(input.Id);

            if (receiveInstrumentToDel == null)
            {
                throw new Exception("没有找到对应的手法单，无法删除！");
            }

            _receiveInstrumentRepository.Delete(receiveInstrumentToDel);
        }
    }
}
