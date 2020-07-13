using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Database.EDMX;
using DAL.Repository;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services {

    public class ProductServices : IProductServices {

        private IProductRepository ProductRepository;

        public ProductServices() {
            ProductRepository = new ProductRepository();
        }

        public List<ProductModel> Get() {            
            List<ProductModel> destination = new List<ProductModel>();
            foreach (var product in ProductRepository.Get()) {
                destination.Add(ModelMapperServices.Map<Product, ProductModel>(product));
            }
            return destination;
        }

        public ProductModel Get(int id) {
            return ModelMapperServices.Map<Product, ProductModel>(ProductRepository.Get(id));
        }

        public bool Add(ProductModel product) {            
            return ProductRepository.Add(ModelMapperServices.Map<ProductModel, Product>(product));
        }

        public bool Update(ProductModel product) {
            return ProductRepository.Update(ModelMapperServices.Map<ProductModel, Product>(product));
        }

        public bool Delete(int id) {
            return ProductRepository.Delete(id);
        }

        public List<ProductCategoryModel> GetCategories() {            
            List<ProductCategoryModel> destination = new List<ProductCategoryModel>();
            foreach (var category in ProductRepository.GetCategories()) {
                destination.Add(ModelMapperServices.Map<ProductCategory, ProductCategoryModel>(category));
            }
            return destination;
        }

        public bool AddCategory(ProductCategoryModel productCategory) {
            return ProductRepository.AddCategory(ModelMapperServices.Map<ProductCategoryModel,ProductCategory>(productCategory));
        }
        
    }

}