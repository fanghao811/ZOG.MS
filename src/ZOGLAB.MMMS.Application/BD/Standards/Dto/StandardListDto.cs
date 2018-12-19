using System;
using Abp.Application.Services.Dto;


namespace ZOGLAB.MMMS.BD
{
    public class StandardListDto : EntityDto<long>
    {
        //1.出厂编号
        public string FactoryNum { get; set; }

        //2.标准器名称   
        public string StrName { get; set; }

        //3.标准器型号
        public string StrSpec { get; set; }

        //4.制造商
        public string Manufactor { get; set; }

        //5.厂家电话
        public string ManufactorTel { get; set; }

        //6.检定单位
        public string CaliFactory { get; set; }

        //7.检定单位联系人
        public string CaliFactoryMan { get; set; }

        //8.检定单位电话
        public string CaliFactoryTel { get; set; }

        //9.所属计量装置ID
        public string Installation { get; set; }
        public long? Installation_ID { get; set; }

        //10.责任人
        public string ResponsibleMan { get; set; }

        //11.有效日期
        public DateTime ValidateDate { get; set; }

        //12.测量范围
        public string TestRange { get; set; }

        //13.准确度
        public string Accurate { get; set; }

        //14.校准系数
        public string StrK { get; set; }

        //15.证书号
        public string CertNum { get; set; }

        //16.标准器类型
        public bool StrType { get; set; }

        //17.备注
        public string Mark { get; set; }


    }
}