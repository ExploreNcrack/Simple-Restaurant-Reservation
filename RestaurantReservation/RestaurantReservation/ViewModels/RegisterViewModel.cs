using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels
{
    public class RegisterViewModel
    {
        [Required] // required field
        [EmailAddress]  // email address validation
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // As we type the password in the password text box on the UI, we do not want to display the typed characters instead we want to mask those characters, for that we use the password validation attribute
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
