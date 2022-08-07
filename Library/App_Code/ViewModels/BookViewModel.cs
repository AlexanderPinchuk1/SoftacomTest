using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Author { get; set; }

        [MaxLength(200)]
        [MinLength(1)]
        public string Description { get; set; }

        [DisplayName("Publishing date")]
        [Range(typeof(DateTime), "1/1/1700", "1/1/2100", ErrorMessage = "Publishing date is out of Range")]
        public DateTime PublishingDate { get; set; }
    }
}