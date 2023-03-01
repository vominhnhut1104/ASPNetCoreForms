using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreForms.Models
{
    public class ProductEditModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        public decimal? Rate { get; set; }
        public int Rating { get; set; }

        [EmailAddress] // sử dung DataAnnotation
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }  
    }
}
