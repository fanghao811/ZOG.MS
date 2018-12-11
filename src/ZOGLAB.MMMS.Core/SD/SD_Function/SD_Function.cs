using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// 4.操作功能表(SD_Function)
    /// </summary>
    [Table("SD_Function")]
    public class SD_Function : Entity<long>, IHasCreationTime,IDeletionAudited
    {
        public const int MaxLength_20 = 20;
        public const int MaxLength_50 = 50;
        public const int MaxLength_100 = 100;

        //1.功能项编码
        [MaxLength(MaxLength_20)]
        public string Code { get; set; }

        //2.功能项名称
        [MaxLength(MaxLength_50)]
        public string Name { get; set; }

        //3.父项ID
        public long Parent_ID { get; set; }

        //4.界面路径
        [MaxLength(MaxLength_100)]
        public string FormPath { get; set; }

        //5.Web页面URL
        [MaxLength(MaxLength_100)]
        public string PageUrl { get; set; }

        //6.菜单项图标文件路径
        [MaxLength(MaxLength_100)]
        public string IconPath { get; set; }

        //7.是否WinForm页面
        /// <summary>
        /// 若为1仅在窗体模式下展示;
        /// </summary>
        public bool IsWinForm { get; set; }

        //8.是否WebForm页面
        /// <summary>
        /// 若为1仅在网页模式下展示;
        /// </summary>
        public bool IsWebForm { get; set; }

        //9.是否为移动手机页面
        /// <summary>
        /// 若若为1仅在手机、便携设备模式下展示;
        /// </summary>
        public bool IsMobileForm { get; set; }

        //10.功能项描述
        [MaxLength(MaxLength_100)]
        public string Description { get; set; }

        //11.是否有效
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }

        //12.序号
        public int Order { get; set; }

        //13.菜单类型
        public byte Type { get; set; }

        //14.创建时间
        public DateTime CreationTime { get; set; }

        //15.备注
        public SD_Function()
        {
            CreationTime = DateTime.Now;
        }
    }
}

