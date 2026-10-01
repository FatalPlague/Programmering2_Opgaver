using System.ComponentModel.DataAnnotations;

namespace Pr02_MovieMania01.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(200, ErrorMessage = "Must be under 200")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Required")]
        [StringLength(200, ErrorMessage = "Must be under 200")]
        public string LastName { get; set; } = string.Empty;
        public string Fullname{ get { return FirstName + " " + LastName; } }
    }
}
