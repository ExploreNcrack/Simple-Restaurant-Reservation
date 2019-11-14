using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Utilities.Attributes
{
    public class ValidReservationDateTimeAttribute : ValidationAttribute
    {
      
        private readonly string _comparisonProperty;

        public ValidReservationDateTimeAttribute(string comparisonProperty)
        {

            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var start = (DateTime)value;

            var endProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (endProperty == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            var end = (DateTime)endProperty.GetValue(validationContext.ObjectInstance);

            if (start > end)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }
}
