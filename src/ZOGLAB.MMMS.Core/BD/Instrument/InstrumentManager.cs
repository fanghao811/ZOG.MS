using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public class InstrumentManager : IInstrumentManager
    {
        private readonly IRepository<BD_Instrument, long> _instrumentRepository;
        private readonly IRepository<BD_Receive, long> _receiveRepository;
        private readonly IRepository<BD_ReceiveInstrument, long> _receiveInstrumentRepository;

        public InstrumentManager(
            IRepository<BD_Instrument, long> instrumentRepository,
            IRepository<BD_Receive, long> receiveRepository,
            IRepository<BD_ReceiveInstrument, long> receiveInstrumentRepository
            )
        {
            _instrumentRepository = instrumentRepository;
            _receiveRepository = receiveRepository;
            _receiveInstrumentRepository = receiveInstrumentRepository;
        }

        /// <summary>
        /// 业务一：向送检单中添加待检设备
        /// </summary>
        /// <param name="instrument">待检设备</param>
        /// <param name="receive">送检单表头</param>
        /// <returns>null</returns>
        public async Task AddToReceiveAsync(long instrumentId, long receiveId)
        {
            await AddToReceiveAsync(
                await GetInstrumentByIdAsync(instrumentId),
                await _receiveRepository.GetAsync(receiveId)
                );
        }

        public async Task AddToReceiveAsync(BD_Instrument instrument, BD_Receive receive)
        {
            var currentReceives = await GetReceivesAsync(instrument);

            if (currentReceives.Any(cre => cre.Id == receive.Id))
            {
                return;
            }

            await _receiveInstrumentRepository.InsertAsync(new BD_ReceiveInstrument(instrument.Id, receive.Id));
        }

        /// <summary>
        /// 业务二：从送检单中删除待检仪器
        /// </summary>
        /// <param name="instrumentId">仪器编号</param>
        /// <param name="receiveId">主表单号</param>
        /// <returns>null</returns>
        public async Task RemoveFromReceiveAsync(long instrumentId, long receiveId)
        {
            await RemoveFromReceiveAsync(
                await GetInstrumentByIdAsync(instrumentId),
                await _receiveRepository.GetAsync(receiveId)
                );
        }

        public async Task RemoveFromReceiveAsync(BD_Instrument instrument, BD_Receive receive)
        {
            await _receiveInstrumentRepository.DeleteAsync(rein => rein.Instrument_ID == instrument.Id && rein.Receive_ID == receive.Id);
        }


        [UnitOfWork]
        public Task<List<BD_Receive>> GetReceivesAsync(BD_Instrument instrument)
        {
            var query = from rein in _receiveInstrumentRepository.GetAll()
                        join re in _receiveRepository.GetAll() on rein.Receive_ID equals re.Id
                        where rein.Instrument_ID == instrument.Id
                        select re;

            return Task.FromResult(query.ToList());
        }

        /// <summary>
        /// Gets a instrument by given id.
        /// Throws exception if no instrument found with given id.
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User</returns>
        /// <exception cref="AbpException">Throws exception if no instrument found with given id</exception>
        public virtual async Task<BD_Instrument> GetInstrumentByIdAsync(long instrumentId)
        {
            var instrument = await _instrumentRepository.FirstOrDefaultAsync(instrumentId);
            if (instrument == null)
            {
                throw new AbpException("没有找到该仪器， id: " + instrumentId);
            }

            return instrument;
        }

    }
}
