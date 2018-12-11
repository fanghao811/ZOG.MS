using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}