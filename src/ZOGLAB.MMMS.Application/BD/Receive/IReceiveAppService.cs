using Abp.Application.Services;
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

        //4.检测业务 6# InstrumentTest
        List<IntestEditDto> GetInstrumentTestsByReInId(NullableIdDto<long> input);
        List<InstrumentWithTCountDto> GetInstrumentWithTCountByReId(NullableIdDto<long> input);
        Task<long> CUInstrumentTestF(IntestEditDto input);
        void DelInstrumentTest(NullableIdDto<long> input);

        //5.交接业务 7# Test
        Task<PagedResultDto<TestListDto>> GetTests(GetTestsInput input);
        Task<PagedResultDto<InTstListDto>> GetInstrumentTestsForHandOver(GetInstrumentTestsInput input);
        Task CreateOrUpdateTest(TestEditDto input);
        Task SetInstrumentTestsAsync(long testId, params long[] instrumentTestIds);
    }
}
