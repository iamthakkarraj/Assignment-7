using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ViewModels;
using BLL.Interfaces;
using BLL.Services;
using System.Web.Mvc;
using System.IO;

namespace UI.Controllers {

    public class ProductController : Controller {


        private IProductServices ProductServices;

        public ProductController() {
            ProductServices = new ProductServices();
        }

        public ActionResult Index() {
            return View(ProductServices.Get());
        }

        public ActionResult Details(int id) {
            return View(ProductServices.Get(id));
        }

        [HttpGet]
        public ActionResult Create() {
            ProductModel productModel = new ProductModel() {                                
                CategoryList = ProductServices.GetCategories()
            };
            return View(productModel);
        }

        [HttpPost]
        public ActionResult Create(ProductModel productModel) {
            productModel.CreatedBy = (int?) Session["IsAuthenticated"];
            productModel.CreatedDate = DateTime.Now;

            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string path = Server.MapPath("~/Uploads/");            

            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

            productModel.ImagePath = timestamp + Path.GetExtension(productModel.ProductImage.FileName);
            productModel.ProductImage.SaveAs(path + productModel.ImagePath);
            
            if (ProductServices.Add(productModel)) {
                TempData["Success"] = "Product Added Successfully";
                return RedirectToAction("Index");
            } else {
                ProductModel getModel = new ProductModel() {
                    CategoryList = ProductServices.GetCategories()
                };
                return View(getModel);
            }
        }

        public ActionResult Edit(int id) {
            ProductModel productModel = ProductServices.Get(id);
            productModel.CategoryList = ProductServices.GetCategories();
            return View(productModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel productModel) {            
            productModel.ModifiedDate = DateTime.Now;

            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string path = Server.MapPath("~/Uploads/");

            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

            productModel.ImagePath = timestamp + Path.GetExtension(productModel.ProductImage.FileName);
            productModel.ProductImage.SaveAs(path + productModel.ImagePath);

            if (ProductServices.Update(productModel)) {
                TempData["Success"] = "Login Successfully !";
                return RedirectToAction("Index");
            } else {
                TempData["Error"] = "Error Login Into Your Account !";
                return View();
            }
        }

        public ActionResult Delete(int id) {
            ProductServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteMultiple(FormCollection items) {
            try {
                string[] ids = items["for-delete"].Split(new char[] { ',' });
                foreach (var item in ids) {
                    ProductServices.Delete(int.Parse(item));
                }
                return RedirectToAction("Index");
            } catch {
                return RedirectToAction("Index");
            }
        }

        public JsonResult GetCategories() {
            return Json(ProductServices.GetCategories(), JsonRequestBehavior.AllowGet);
        }

    }

}