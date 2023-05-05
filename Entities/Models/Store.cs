using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Store name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        public string Address { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
