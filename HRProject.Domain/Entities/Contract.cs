namespace HRProject.Domain.Entities
{
    public class Contract : BaseEntity
    {
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; } 
        public string PDF { get; set; }
        public string Status { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
