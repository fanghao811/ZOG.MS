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
        private readonly IInstrumentManager _instrumentManager;

        #region 服务注入
        public ReceiveAppService(
               IRepository<BD_Receive, long> receiveRepository,
               IInstrumentManager instrumentManager)
        {
            _receiveRepository = receiveRepository;
            _instrumentManager = instrumentManager;
        }
        #endregion       

        #region 登记单 OrderHeader

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

        #region 仪器列表 OrderDetail
        //1.获取已经登记的仪器列表
        public async Task<ReceiveWithItemsDto> GetReceiveWithItems(NullableIdDto<long> input)
        {
            Debug.Assert(input.Id != null, "此查询送检单ID不得为空！");

            ReceiveWithItemsDto receiveWithItemsDto = new ReceiveWithItemsDto { };

            var receive = await _receiveRepository.GetAsync(input.Id.Value);

            receiveWithItemsDto.ReceiveId = receive.Id;
            receiveWithItemsDto.UnitName = receive.Unit.UnitName;
            receiveWithItemsDto.Number = receive.Number;

            receiveWithItemsDto.RegistedInstruments =
                 _instrumentManager.GetRegistedInstrumentsAsync(receive).MapTo<List<InstrumentFReadDto>>();

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
    }
}
