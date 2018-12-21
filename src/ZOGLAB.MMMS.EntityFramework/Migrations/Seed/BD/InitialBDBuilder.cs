using ZOGLAB.MMMS.EntityFramework;

namespace ZOGLAB.MMMS.Migrations.Seed.BD
{
    public class InitialBDBuilder
    {
        private readonly MMMSDbContext _context;

        public InitialBDBuilder(MMMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new InstallationAndStandardCreator(_context).Create();
            new CheckTypeCreator(_context).Create();
            new UnitsCreator(_context).Create();
            _context.SaveChanges();
        }
    }
}
