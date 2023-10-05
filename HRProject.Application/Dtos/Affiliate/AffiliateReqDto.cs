using System.ComponentModel.DataAnnotations;

namespace HRProject.Application.Dtos.Affiliate
{
    public class AffiliateReqDto
    {
        [Required]
        public string Name { get; set; }
    }
}
