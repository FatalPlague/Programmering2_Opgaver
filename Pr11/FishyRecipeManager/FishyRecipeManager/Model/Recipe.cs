using System.ComponentModel.DataAnnotations;

namespace FishyRecipeManager.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PrepTime { get; set; }
        [Required]
        public int Servings { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
