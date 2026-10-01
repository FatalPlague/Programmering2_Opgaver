using System.ComponentModel.DataAnnotations;

namespace Pr02_MovieMania01.Models
{
    public class Movie
    { 
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "Must be under 100")]
        public string? Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Required")]
        [Range(1888, 2026, ErrorMessage = "Release year have to be between 1888 and 2026")]
        public int? ReleaseYear { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, Double.MaxValue, ErrorMessage = "Negative numbers is not allowed")]
        public int? DurationInMinutes { get; set; }

        [StringLength(500, ErrorMessage = "Must be under 500")]
        public string? Description { get; set; }

        [Range(1, 10, ErrorMessage = "Must be between 1 and 10")]
        public int? Rating { get; set; }

        [Required]
        [Display(Name = "Director")]
        public int? DirectorId { get; set; }
        public Director? Director { get; set; }
    }
}
