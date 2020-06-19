﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels {

    public class LoginModel {

        [Required(ErrorMessage = "Please Enter your Email.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
            ErrorMessage = "Please enter a valid Email.")]
        [Display(Name = "Your Email Address.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$", 
            ErrorMessage = "Password must contain a capital letter, a small letter and a special symbol.")]
        [Required(ErrorMessage = "Please Enter your password.")]
        [Display(Name = "Your Pasdword.")]
        public string Password { get; set; }

    }

}