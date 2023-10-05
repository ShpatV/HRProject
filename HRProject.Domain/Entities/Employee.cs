using System.ComponentModel.DataAnnotations;

namespace HRProject.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Skype { get; set; }
        public string CV { get; set; }
        public string Email { get; set; }

        public Guid AffiliateId { get; set; }
        public Affiliate Affiliate { get; set; }

        public Guid PositionId { get; set; }
        public Position Position { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Guid OfficeId { get; set; }
        public Office Office { get; set; }

        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
