using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModels {

    public class SignUpModel {

        public int UserId { get; set; }
        
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter your Email.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Please enter a valid Email.")]        
        public string Email { get; set; }

        [Display(Name="Contact No.")]
        [Required(ErrorMessage = "Please enter your contact number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }
        
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please select your city.")]
        public Nullable<int> CityId { get; set; }

        [Required(ErrorMessage = "Please enter your zipcode.")]
        [MaxLength(5,ErrorMessage = "Please enter a valid zipcode.")]
        public int ZipCode { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$",
            ErrorMessage = "Password must contain a capital letter, a small letter and a special symbol.")]
        [Required(ErrorMessage = "Please Enter your password.")]
        [Display(Name = "Your Pasdword.")]
        public string Password { get; set; }


    }

}