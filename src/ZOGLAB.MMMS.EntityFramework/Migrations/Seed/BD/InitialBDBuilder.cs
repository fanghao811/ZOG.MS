using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _context.SaveChanges();
        }
    }
}
