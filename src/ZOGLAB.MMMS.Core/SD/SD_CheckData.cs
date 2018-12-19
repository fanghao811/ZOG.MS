using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 7，检测数据表（SD_CheckData）
    /// </summary>
    [Table("SD_CheckData")]
    public class SD_CheckData : CreationAuditedEntity<long>, ISoftDelete
    {
        public const int MaxLength_10 = 10;
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;

        // 2	Instrument_ID 设备ID    INT
        public int Instrument_ID { get; set; }

        //3	ComNum 检测序号    INT
        public int ComNum { get; set; }

        //4	CheckDrop 检测点 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string CheckDrop { get; set; }

        //5	StandardValue 标准值 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string StandardValue { get; set; }

        //6	CorrectedValue 标准修正值   VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string CorrectedValue { get; set; }

        //7	StandardCorrected 标准器修正后值 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string StandardCorrected { get; set; }

        //9	IndicatingValue 示值  VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string IndicatingValue { get; set; }

        //10	ErrorValue 误差值 VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string ErrorValue { get; set; }

        //11	CreateDate 检测时间    VARCHAR(20)
        [MaxLength(MaxLength_20)]
        public string CreateDate { get; set; }

        //12	CheckUser 检测者 VARCHAR(10)
        [MaxLength(MaxLength_10)]
        public string CheckUser { get; set; }

        public bool IsDeleted { get; set; }
    }

}
