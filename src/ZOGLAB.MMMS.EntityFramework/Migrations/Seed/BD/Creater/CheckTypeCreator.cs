using System;
using System.Collections.Generic;
using System.Linq;
using ZOGLAB.MMMS.BD;
using ZOGLAB.MMMS.EntityFramework;
using static ZOGLAB.MMMS.BD.BD_CheckType;

namespace ZOGLAB.MMMS.Migrations.Seed.BD
{
    public class CheckTypeCreator
    {
        private readonly MMMSDbContext _context;

        public CheckTypeCreator(MMMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCheckType();
        }

        private void CreateCheckType()
        {
            //Default MeteorType

            var defaultMeteorType = _context.BD_MeteorType.FirstOrDefault(m => m.Name == "温度");
            if (defaultMeteorType == null)
            {
                var seedMeteorTypes = new List<BD_MeteorType>
                {
                    new BD_MeteorType{
                        Name="温度",Mark="1"
                    },
                    new BD_MeteorType{
                        Name="湿度",Mark="2"
                    },
                    new BD_MeteorType{
                        Name="温湿度",Mark="3"
                    },
                    new BD_MeteorType{
                        Name="气压",Mark="4"
                    },
                    new BD_MeteorType{
                        Name="风速",Mark="5"
                    },
                    new BD_MeteorType{
                        Name="雨量",Mark="6"
                    },
                    new BD_MeteorType{
                        Name="其他",Mark="7"
                    }
                };

                foreach (var item in seedMeteorTypes)
                {
                    _context.BD_MeteorType.Add(item);

                }
                _context.SaveChanges();     //Step 03
            }

            //Default BD_CheckType

            var defaultCheckType = _context.BD_CheckType.FirstOrDefault(s => s.CheckName == "辐射检定");    //Step 01      
            if (defaultCheckType == null)    //Step 02
            {
                var seedMeteorTypes = _context.BD_MeteorType.ToList();
                var checkTypes = new List<BD_CheckType>
                {
                    new BD_CheckType{
                        MeteorTypeId =seedMeteorTypes[1].Id,
                        CalibrationType =Calibration_Type.检定,
                        CheckName="温度检定"
                    },
                    new BD_CheckType{
                        MeteorTypeId=seedMeteorTypes[1].Id,
                        CalibrationType =Calibration_Type.校准,
                        CheckName="温度校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[1],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="温度核查"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[2],
                        CalibrationType =Calibration_Type.检定,
                        CheckName="湿度检定"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[2],
                        CalibrationType =Calibration_Type.校准,
                        CheckName="湿度校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[2],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="湿度核查"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[3],
                        CalibrationType =Calibration_Type.检定,
                        CheckName="温湿度检定"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[3],
                        CalibrationType =Calibration_Type.校准,
                        CheckName="温湿度校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[3],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="温湿度核查"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[4],
                        CalibrationType =Calibration_Type.检定,
                        CheckName="气压检定"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[4],
                        CalibrationType =Calibration_Type.校准,
                        CheckName="气压校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[4],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="气压核查"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[5],
                        CalibrationType =Calibration_Type.检定,
                        CheckName="风速检定"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[5],
                        CalibrationType =Calibration_Type.校准,
                        CheckName="风速校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[5],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="风速核查"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[6],
                        CalibrationType =Calibration_Type.检定,
                        CheckName="雨量检定"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[6],
                        CalibrationType =Calibration_Type.校准,
                        CheckName="雨量校准"
                    },
                    new BD_CheckType{
                        MeteorType=seedMeteorTypes[6],
                        CalibrationType =Calibration_Type.核查,
                        CheckName="雨量核查"
                    }
                };

                foreach (var item in checkTypes)
                {

                    _context.BD_CheckType.Add(item);

                }
                _context.SaveChanges();     //Step 03
            }
        }
    }
}
