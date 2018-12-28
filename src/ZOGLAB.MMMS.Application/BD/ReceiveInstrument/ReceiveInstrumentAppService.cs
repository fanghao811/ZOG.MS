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
        private readonly IRepository<BD_ReceiveInstrument,long> _receiveInstrumentRepository;

        public ReceiveInstrumentAppService(IRepository<BD_ReceiveInstrument, long> receiveInstrumentRepository)
        {
            _receiveInstrumentRepository = receiveInstrumentRepository;
        }

        #region 
        public async Task<List<BD_ReceiveInstrument>> GetAll()
        {
            var query = await _receiveInstrumentRepository.GetAll().ToListAsync();
            return query;
        }

        public async Task<List<BD_ReceiveInstrument>> GetByReceiveId(EntityDto<long> input)
        {
            var query = await _receiveInstrumentRepository.GetAll().Where(r => r.Receive_ID == input.Id).ToListAsync();
            return query;
        }

        public async Task CreateOrUpdateReveice(ReceiveInstrumentEditDto input)
        {
            BD_ReceiveInstrument item = input.MapTo<BD_ReceiveInstrument>();
            await _receiveInstrumentRepository.InsertOrUpdateAsync(item);
        }

        public void DeleteItem(EntityDto<long> input)
        {
            var receiveInstrumentToDel = _receiveInstrumentRepository.Get(input.Id);

            if (receiveInstrumentToDel == null)
            {
                throw new Exception("没有找到对应的收发从表，无法删除！");
            }

            _receiveInstrumentRepository.Delete(receiveInstrumentToDel);
        }
        #endregion

        //public async Task RemoveInstrumentFromReceive(long instrumentId, long receiveId)
        //{
        //    await _instrumentManager.RemoveFromReceiveAsync(instrumentId, receiveId);
        //}
    }
}
