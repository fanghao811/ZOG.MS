using EntityFramework.DynamicFilters;
using ZOGLAB.MMMS.EntityFramework;

namespace ZOGLAB.MMMS.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MMMSDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(MMMSDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
