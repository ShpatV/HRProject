namespace HRProject.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
