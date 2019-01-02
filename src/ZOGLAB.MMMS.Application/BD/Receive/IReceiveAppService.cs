﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZOGLAB.MMMS.BD
{
    public interface IReceiveAppService : IApplicationService
    {
        //Task<PagedResultDto<UnitListDto>> GetUnits(GetUnitsInput input);
        Task<List<ReceiveEditDto>> GetAll();
        Task<ReceiveWithItemsDto> GetReceiveWithItems(NullableIdDto<long> input);
        ReceiveEditDto GetReceiveById(NullableIdDto<long> input);
        Task<long> CreateOrUpdateReveice(ReceiveEditDto input);
        void DeleteItem(EntityDto<long> input);
        Task AddInstrumentToReceive(long instrumentId, long receiveId);
        Task RemoveInstrumentFromReceive(long instrumentId, long receiveId);

        //InstrumentTEST 业务

        List<IntestEditDto> GetInstrumentTestsByReInId(NullableIdDto<long> input);
        List<InstrumentWithTCountDto> GetInstrumentWithTCountByReId(NullableIdDto<long> input);
        Task<long> CUInstrumentTestF(IntestEditDto input);
        void DelInstrumentTest(NullableIdDto<long> input);

    }
}