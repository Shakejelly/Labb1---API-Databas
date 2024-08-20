using System.ComponentModel.DataAnnotations;

namespace Labb1___API_Databas.Models
{
    public class Menu
    {
        [Key]
        public int DishId { get; set; }
        public string  DishName { get; set; }
        public int DishPrice { get; set; }
        public string DishAvailable { get; set; } // Kanske en Bool?
    }
}
