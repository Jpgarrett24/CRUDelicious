using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Dish name is required")]
        [Display(Name = "Dish Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chef is required")]
        [Display(Name = "Chef's Name: ")]
        public string Chef { get; set; }

        [Required(ErrorMessage = "Calories is required")]
        [Range(1, 2147483646, ErrorMessage = "Calories must be greater than 0")]
        [Display(Name = "Calories: ")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Tastiness is required")]
        [Range(1, 5, ErrorMessage = "Tastiness level must be between 1 and 5")]
        [Display(Name = "Tastiness Level: ")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}