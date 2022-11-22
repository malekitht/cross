using System.ComponentModel.DataAnnotations;

namespace laba34.Models
{
    public class laba3
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

    }
}
