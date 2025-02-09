using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.DTOs
{
    public class TodoDto
    {
        public Guid? Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public bool Completed { get; set; } 

    }
}
