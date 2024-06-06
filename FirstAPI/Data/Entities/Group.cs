using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Data.Entities
{
    public class Group:AuditEntity
    {
        [MaxLength(15)]
        public string No { get; set; }
        public byte Limit { get; set; }
        public List<Student> Students { get; set; }

    }
}
