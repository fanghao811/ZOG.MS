using System;
using System.Collections.Generic;
using System.Linq;
using ZOGLAB.MMMS.BD;
using ZOGLAB.MMMS.EntityFramework;
using static ZOGLAB.MMMS.BD.BD_CheckType;

namespace ZOGLAB.MMMS.Migrations.Seed.BD
{
    public class InstrumentCreator
    {
        private readonly MMMSDbContext _context;

        public InstrumentCreator(MMMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateInstruments();
        }

        private void CreateInstruments()
        {
            //https://stackoverflow.com/questions/14257360/linq-select-objects-in-list-where-exists-in-a-b-c
            //var allowedStatus = new[] { "A", "B", "C" };
            //var filteredOrders = orders.Order.Where(o => allowedStatus.Contains(o.StatusCode));
            //Default MeteorType

            var checkLists = _context.BD_CheckType.ToList();
            //var checkListR = checkLists.Where(c => new long[3] { 1, 2, 3 }.Contains(c.Id)).ToList();
            var checkListR = new List<BD_CheckType>
            {
                new BD_CheckType{
                    CalibrationType = Calibration_Type.检定,
                    CheckName = "温度检定"
                },
                new BD_CheckType{
                    CalibrationType = Calibration_Type.检定,
                    CheckName = "湿度检定"
                },
                 new BD_CheckType{
                     CalibrationType = Calibration_Type.检定,
                     CheckName = "气压检定"
                }
            };


            var checkListB = checkLists.Where(c => new long[3] { 1, 2, 3 }.Contains(c.Id)).ToList();

            var meteorTypes = _context.BD_MeteorType.ToList();
            var meteorTypesR = meteorTypes.Where(c => new long[3] { 1, 2, 3 }.Contains(c.Id)).ToList();
            var meteorTypesW = meteorTypes.Where(c => new long[3] { 4, 5, 6 }.Contains(c.Id)).ToList();
            var meteorTypesB = meteorTypes.Where(c => new long[3] { 5, 6, 7 }.Contains(c.Id)).ToList();


            var defaultUnit = _context.BD_Instruments.OrderBy(i => i.Name).FirstOrDefault(m => m.Name == "地温传感器");
            if (defaultUnit == null)
            {
                var seedUnits = new List<BD_Instrument>
                {
                    new BD_Instrument
                    {
                        SN="TEST013A",Name="地温传感器",Model="PT100",Grade="2",Scope="(-30～500)℃",Power="0.1℃",
                        Manufacturer ="杭州仪器厂",Mark="测试时间：12/24/2018",CheckTypes=checkListR,MeteorTypes=meteorTypesR
                    },
                    new BD_Instrument
                    {
                        SN="TEST014B",Name="地温传感器",Model="PT200",Grade="3",Scope="(-50～600)℃",Power="0.2℃",
                        Manufacturer ="杭州仪器厂",Mark="测试时间：12/24/2018",CheckTypes=checkListR,MeteorTypes=meteorTypesW
                    },
                    new BD_Instrument
                    {
                        SN="TEST015C",Name="地温传感器",Model="PT300",Grade="4",Scope="(-30～100)℃",Power="0.1℃",
                        Manufacturer ="杭州仪器厂",Mark="测试时间：12/24/2018",CheckTypes=checkListB,MeteorTypes=meteorTypesB
                    },
                    new BD_Instrument
                    {
                        SN="TEST016D",Name="地温传感器",Model="PT400",Grade="5",Scope="(-20～200)℃",Power="0.3℃",
                        Manufacturer ="杭州仪器厂",Mark="测试时间：12/24/2018",CheckTypes=checkListB,MeteorTypes=meteorTypesB
                    },
                    new BD_Instrument
                    {
                        SN="TEST017E",Name="地温传感器",Model="PT500",Grade="6",Scope="(-10～300)℃",Power="0.5℃",
                        Manufacturer ="杭州仪器厂",Mark="测试时间：12/24/2018",CheckTypes=checkListR,MeteorTypes=meteorTypesR
                    }
                };

                foreach (var item in seedUnits)
                {
                    _context.BD_Instruments.Add(item);
                }
                _context.SaveChanges();     //Step 03
            }

        }
    }
}
