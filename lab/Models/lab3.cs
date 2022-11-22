using System.ComponentModel.DataAnnotations;

namespace lab.Models
{
    public class lab3
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
    }
}
