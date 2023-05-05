using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        public string ProductBarcCode { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
