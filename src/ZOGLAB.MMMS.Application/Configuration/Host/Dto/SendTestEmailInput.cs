using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using ZOGLAB.MMMS.Authorization.Users;

namespace ZOGLAB.MMMS.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}