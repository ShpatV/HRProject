namespace HRProject.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string StateName { get; set; }
        public string Timezone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
