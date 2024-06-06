namespace FirstAPI.Data.Entities
{
    public class AuditEntity:BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set;}
        public bool IsDeleted { get; set; } = false;
    }
}
