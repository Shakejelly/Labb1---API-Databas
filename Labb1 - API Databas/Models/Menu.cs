using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Menu
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string DishName { get; set; }

        [Required] 
        public string Description { get; set; }

        [Required]
        public int DishPrice { get; set; }
        public int DishAvailable { get; set; } // Kanske en Bool?
    }
}
