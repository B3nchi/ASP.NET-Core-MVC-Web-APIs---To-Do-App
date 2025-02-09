using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100), Column(TypeName = "NVARCHAR(100)")]
        public string Title { get; set; } = string.Empty;

        public bool Completed { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
