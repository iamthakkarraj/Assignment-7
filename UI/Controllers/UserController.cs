using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Services;
using BLL.Interfaces;
using System.Web.Mvc;

namespace UI.Controllers {

    public class UserController : Controller {

        private IUserServices UserServices;

        public UserController() {
            UserServices = new UserServices();
        }

        public ActionResult Login() {
            if (Session["IsAuthenticated"] != null) {
                return RedirectToAction("Index", "Product");
            } else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel) {            
            if (UserServices.VerifyCredentials(loginModel)) {
                Session["IsAuthenticated"] = UserServices.GetUserId(loginModel.Email);
                TempData["Success"] = "Login Successfully !";
                return RedirectToAction("Index", "Product");
            } else {
                TempData["Error"] = "Error Login Into Your Account !";
                return View();
            }
        }
        
        public ActionResult SignUp() {
            if (Session["IsAuthenticated"] != null) {
                return RedirectToAction("Index", "Product");
            } else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel signUpModel) {
            if (UserServices.SignUp(signUpModel)) {
                TempData["Success"] = "User Created Successfully !";
                return RedirectToAction("Index", "Product");
            } else {
                TempData["Error"] = "Could Not Create Your Account !";
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetCountries() {
            return Json(UserServices.GetCountries(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStates(int id) {
            return Json(UserServices.GetStates(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCities(int id) {
            return Json(UserServices.GetCities(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout() {
            if (Session["IsAuthenticated"] != null) {
                Session["IsAuthenticated"] = false;
            }
            return RedirectToAction("Login");
        }

    }

}