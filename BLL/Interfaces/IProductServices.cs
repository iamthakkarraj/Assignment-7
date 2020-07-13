using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ViewModels;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces {

    public interface IProductServices {

        List<ProductModel> Get();

        ProductModel Get(int id);

        bool Add(ProductModel product);

        bool Update(ProductModel product);

        bool Delete(int id);

        List<ProductCategoryModel> GetCategories();

        bool AddCategory(ProductCategoryModel productCategory);

    }

}