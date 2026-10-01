using System.ComponentModel.DataAnnotations;

namespace Pr02_MovieMania01.Validators
{
    public class YearNotInFuture : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not int year)
            {
                return ValidationResult.Success; //Hvis det IKKE er int er vi ligeglade.
            }
            if (year > DateTime.UtcNow.Year)
            {
                return new ValidationResult("Year cannot be in the future");
            }

            return ValidationResult.Success; //Hvis det IKKE er int er vi ligeglade.
        }
    }
}
