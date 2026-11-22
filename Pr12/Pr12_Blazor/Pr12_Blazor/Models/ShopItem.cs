namespace Pr12_Blazor.Models
{
    public class ShopItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Current { get; set; } = false;
        public bool Owned { get; set; } = false;
        public decimal Multiplier { get; set; }
        public int Level { get; set; } = 1;
    }
}
