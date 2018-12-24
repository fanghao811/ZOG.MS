using System;
using System.Collections.Generic;
using System.Linq;
using ZOGLAB.MMMS.BD;
using ZOGLAB.MMMS.EntityFramework;

namespace ZOGLAB.MMMS.Migrations.Seed.BD
{
    public class UnitsCreator
    {
        private readonly MMMSDbContext _context;

        public UnitsCreator(MMMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUnits();
        }

        private void CreateUnits()
        {
            //Default MeteorType

            var defaultUnit = _context.BD_Units.FirstOrDefault(m => m.UnitName == "ZOGLAB");
            if (defaultUnit == null)
            {
                var seedUnits = new List<BD_Unit>
                {
                    new BD_Unit{
                        UnitName="ZOGLAB",Address="杭州西溪",Contact="Admin",ContactTel="1990579",Email="ZOGLAB@Gmail.com",FaxNumber="123456"
                    },
                    new BD_Unit{
                        UnitName="上海",Address="商洛区百家园路70号昆仑科技园A座南1-2层",Contact="陈凌江",ContactTel="1990579",Email="ShangHai@Gmail.com",FaxNumber="123456"
                    },
                    new BD_Unit{
                        UnitName="浙江",Address="杭州",Contact="张三",ContactTel="1990579",Email="ZheJiang@Gmail.com",FaxNumber="123456"
                    },
                    new BD_Unit{
                        UnitName="陕西",Address="西安",Contact="李四",ContactTel="1990579",Email="ShanXi@Gmail.com",FaxNumber="123456"
                    }
                };

                foreach (var item in seedUnits)
                {
                    _context.BD_Units.Add(item);
                }
                _context.SaveChanges();     //Step 03
            }

        }
    }
}
