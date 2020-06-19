using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ViewModels;
using System.Web.Mvc;

namespace CSharpAssignment.Controllers{

    public class ProductController : Controller{
        
        public ActionResult Index(){
            return View();
        }

        public JsonResult Details(int id) {
            return Json(null);
        }

        public ActionResult Post() {
            return View();
        }

        public ActionResult Post(ProductModel productModel) {
            return View();
        }

        public ActionResult Edit(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductModel productModel) {
            return View();
        }

        public JsonResult Delete(int it) {
            return Json(null);
        }        

    }

}