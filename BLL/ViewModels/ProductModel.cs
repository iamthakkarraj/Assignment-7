using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.ViewModels {

    public class ProductModel {

        public int ProductId { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Code")]
        public int Code { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public Nullable<bool> Status { get; set; }

        [Display(Name = "Discount")]
        public Nullable<int> Discount { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase ProductImage { get; set; }

        [NotMapped]
        public IEnumerable<ProductCategoryModel> CategoryList { get; set; }

    }

}
