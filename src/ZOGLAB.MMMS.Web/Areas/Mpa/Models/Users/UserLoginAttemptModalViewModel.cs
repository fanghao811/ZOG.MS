using System.Collections.Generic;
using ZOGLAB.MMMS.Authorization.Users.Dto;

namespace ZOGLAB.MMMS.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}