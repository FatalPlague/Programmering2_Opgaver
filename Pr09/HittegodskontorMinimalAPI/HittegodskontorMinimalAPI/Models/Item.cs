using System.ComponentModel.DataAnnotations;

namespace HittegodskontorMinimalAPI.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LocationFound { get; set; } = string.Empty;

        [Required]
        public DateTime DateFound { get; set; }

        [Required]
        public bool IsClaimed { get; set; }

    }
}
