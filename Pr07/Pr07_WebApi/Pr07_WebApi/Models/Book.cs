using System.ComponentModel.DataAnnotations;

namespace Pr07_WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public  string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double SalesPrice { get; set; }

        [Required]
        public double PurchasePrice { get; set; } 
    }
}
