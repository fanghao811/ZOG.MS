using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace ZOGLAB.MMMS.BD
{
    [AutoMap(typeof(BD_Standard))]
    public class StandardEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }
        
        public bool IsDefault { get; set; }
    }
}