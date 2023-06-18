using System.ComponentModel.DataAnnotations;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Validation
{
    /// <summary>
    /// ValidationAttribute class to ensure URLs are valid and live
    /// </summary>
	public class ValidUrl : ValidationAttribute
	{
        /// <summary>
        /// Constructor for ValidUrl. No parameters to initialize.
        /// </summary>
		public ValidUrl()
            : base("{0} does not contain a valid url! Remember to include 'HTTP://' or 'HTTPS://'.")
		{
		}

        /// <summary>
        /// Validation method for data annotation. Checks if url is properly formatted and live
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="validationContext">Context of where validation is occurring</param>
        /// <returns>ValidtionResult is successful or holds an error message</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            // Format base error message
            string errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value == null)
            {
                return new ValidationResult(errorMessage);
            }

            // Convert object to string
            var valueString = value.ToString();

            if(UrlCheckerService.ValidateUrl(valueString))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(errorMessage);
        }

        /// <summary>
        /// public wrapper class for testing validation
        /// </summary>
        /// <param name="value">Value to be checked if it is a url</param>
        /// <param name="validationContext">The context in which the validation is performed</param>
        /// <returns>ValidtionResult is successful or holds an error message</returns>
        public ValidationResult IsValidPublicAccess(object value, ValidationContext validationContext)
        {
            return this.IsValid(value, validationContext);
        }
    }
}