using System.ComponentModel.DataAnnotations;

namespace TalentPortalAPI.CustomAnnotations
{
    public class ApplicationStatusLimitationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "submitted" || Convert.ToString(value) == "rejected" || Convert.ToString(value) == "selected")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);

        }
    }
}

