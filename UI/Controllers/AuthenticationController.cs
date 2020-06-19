using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Services;
using BLL.Interfaces;
using System.Web.Mvc;

namespace CSharpAssignment.Controllers {

    public class AuthenticationController : Controller {

        private IAuthenticationServices AuthenticationServices;

        public AuthenticationController() {
            AuthenticationServices = new AuthenticationServices();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel) {
            if (AuthenticationServices.VerifyCredentials(loginModel)) {
                return RedirectToAction("Index", "Product");
            } else {
                return View();
            }
        }
        
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel signUpModel) {
            if (AuthenticationServices.SignUp(signUpModel)) {
                return RedirectToAction("Index", "Product");
            } else {
                return View();
            }
        }

    }

}