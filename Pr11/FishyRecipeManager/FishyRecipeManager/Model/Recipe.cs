namespace FishyRecipeManager.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrepTime { get; set; }
        public int Servings { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
