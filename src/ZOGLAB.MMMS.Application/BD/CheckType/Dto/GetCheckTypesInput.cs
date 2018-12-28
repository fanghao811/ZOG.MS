using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.BD
{
    public class GetCheckTypesInput: PagedAndSortedInputDto
    {
        //2	MeteorType_ID 气象要素 INT 外
        public long? MeteorTypeId { get; set; }

        //3	CheckName 检测项目   VARCHAR(20)
        public string CheckName { get; set; }

        //5	UserName 操作者 VARCHAR(20)
        public string UserName { get; set; }

        //7	strFlag 是否自动检测  INT
        public bool StrFlag { get; set; }

        public bool IsDeleted { get; set; }

    }
}
