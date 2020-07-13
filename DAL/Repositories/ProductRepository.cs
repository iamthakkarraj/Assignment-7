using DAL.Database.EDMX;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository {

    public class ProductRepository : IProductRepository {

        private CSharpAssignmentEntities DBContext;

        public ProductRepository() {
            DBContext = new CSharpAssignmentEntities();
        }

        public List <Product> Get() {
            return DBContext.Products.OrderBy(x => x.ProductId).ToList();
        }

        public Product Get(int id) {
            return DBContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public bool Add(Product product) {
            try {
                DBContext.Products.Add(product);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool Update(Product product) {
            try {
                DBContext.Entry(product).State = System.Data.Entity.EntityState.Modified;
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public bool Delete(int id) {
            try {
                DBContext.Products.Remove(DBContext.Products.Where(x => x.ProductId == id).FirstOrDefault());
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

        public List<ProductCategory> GetCategories() {
            return DBContext.ProductCategories.OrderBy(x => x.Name).ToList();
        }

        public bool AddCategory(ProductCategory productCategory) {
            try {
                DBContext.ProductCategories.Add(productCategory);
                DBContext.SaveChanges();
                return true;
            } catch {
                return false;
            }
        }

    }

}