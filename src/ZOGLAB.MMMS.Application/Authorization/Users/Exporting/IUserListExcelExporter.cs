using System.Collections.Generic;
using ZOGLAB.MMMS.Authorization.Users.Dto;
using ZOGLAB.MMMS.Dto;

namespace ZOGLAB.MMMS.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}