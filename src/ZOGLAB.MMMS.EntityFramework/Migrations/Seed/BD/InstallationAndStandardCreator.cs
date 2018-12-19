using System;
using System.Collections.Generic;
using System.Linq;
using ZOGLAB.MMMS.BD;
using ZOGLAB.MMMS.Editions;
using ZOGLAB.MMMS.EntityFramework;

namespace ZOGLAB.MMMS.Migrations.Seed.BD
{
    public class InstallationAndStandardCreator
    {
        private readonly MMMSDbContext _context;

        public InstallationAndStandardCreator(MMMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateInstallationAndStandard();
        }

        private void CreateInstallationAndStandard()
        {
            //Default Installationss

            var defaultInstallation = _context.BD_Installations.FirstOrDefault(i => i.Equipment_Name == "湿度检定装置");
            if (defaultInstallation == null)
            {
                var seedInstallations = new List<BD_Installation>
                {
                    new BD_Installation{
                        Standard_SN="4113803",Equipment_Name="二等铂电阻温度计标准装置",Equipment_Model="3000",TestRange="（-30～+80）℃",Accurate="二级",
                        CertificateId="[2016]桂量标气象证字第006号",ValidateDate="43840",Organization="广西壮族自治区质量技术监督局",Mark="湿度检定装置"
                    },
                    new BD_Installation
                    {   Standard_SN= "12417601",Equipment_Name = " 0.01级数字压力计标准装置",Equipment_Model ="12417601",TestRange = "（500~1100）hPa℃",Accurate="二级",
                        CertificateId= "[2016]桂量标气象证字第003号",ValidateDate= "43840",Organization= "广西壮族自治区质量技术监督局",Mark="湿度检定装置"
                    },
                    new BD_Installation
                    {
                        Standard_SN="46514500",Equipment_Name="湿度检定装置",Equipment_Model="3000",TestRange="（0-100)%RH",Accurate="二级",
                        CertificateId="[86]陕量标气证字第002号",ValidateDate="43840",Organization="陕西省质量技术监督局",Mark="湿度检定装置"
                    },
                    new BD_Installation{
                        Standard_SN="46514500",Equipment_Name="湿度计检定装置",Equipment_Model="3001",TestRange="（（0～70）℃ （-40～50）℃DP	±0.1℃ ±0.2℃DP",Accurate="二级",
                        CertificateId="[2011]冀社量标授证字第104号",ValidateDate="42363",Organization="河北省质量技术监督局",Mark="湿度计检定装置" },
                    new BD_Installation{
                        Standard_SN="4114702",Equipment_Name="水银温度计标准装置",Equipment_Model="4000",TestRange="(-30～80)℃	U=0.04 ℃",Accurate="二级",
                        CertificateId="[2011]冀量标授证字第105号",ValidateDate="42363",Organization="河北省质量技术监督局",Mark="水银温度计标准装置" }
                };

                foreach (var item in seedInstallations)
                {
                    _context.BD_Installations.Add(item);

                }
                _context.SaveChanges();     //Step 03
            }

            //Default Standards

            var defaultStandard = _context.BD_Standards.FirstOrDefault(s => s.StrName == "精密温湿度测试仪");    //Step 01      

            if (defaultStandard == null)    //Step 02
            {
                var installations = _context.BD_Installations.Where(i=>i.Id<4).ToList();
                var seedStandards = new List<BD_Standard>
                {
                    new BD_Standard{
                        StrName ="气压表（计）检定箱",FactoryNum="3",StrSpec="YE-LQ-98-1型",Manufactor="辽宁气象装备公司",ManufactorTel="0551-2290348",
                        CaliFactory="安徽省气象计量检定站",CaliFactoryMan="周昌文",CaliFactoryTel="0551-2290348",Installation=installations[0],ResponsibleMan="魏根宝",
                        ValidateDate =new DateTime(2012,4,24),TestRange ="（（500-1100）hPa ",Accurate="0.14hPa",StrK="1",CertNum="",
                        StrType=true,Mark="标准器"
                    },
                    new BD_Standard{
                        StrName ="精密温湿度测试仪",FactoryNum="3",StrSpec="DHT-2000",Manufactor="天津气象仪器厂",ManufactorTel="010-68407036",
                        CaliFactory="国家气象计量检定站",CaliFactoryMan="赵旭",CaliFactoryTel="010-68407036",Installation=installations[1],ResponsibleMan="李建英",
                        ValidateDate =new DateTime(2012,4,26),TestRange ="（10-100）%RH",Accurate="二等",StrK="1",CertNum="",
                        StrType=true,Mark="标准器"
                    },
                    new BD_Standard{
                        StrName ="自校式铂电阻数字测温仪",FactoryNum="4027",StrSpec="RCY-1A",Manufactor="河北省高碑店市兴华电子仪器厂",ManufactorTel="010-68407036",
                        CaliFactory="国家气象计量站",CaliFactoryMan="赵旭",CaliFactoryTel="010-68407036",Installation=installations[2],ResponsibleMan="李建英",
                        ValidateDate =new DateTime(2012,3,31),TestRange ="(-60～+80)℃",Accurate="二等",StrK="1",CertNum="",
                        StrType=true,Mark="标准器"
                    }
                };

                foreach (var item in seedStandards)
                {
                    _context.BD_Standards.Add(item);

                }
                _context.SaveChanges();     //Step 03

            }
        }
    }
}
