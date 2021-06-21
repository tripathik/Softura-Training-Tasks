using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleDropDownList.Models
{
    public class MultipleDDModel
    {
        public MultipleDDModel()
        {
            
            this.ProductCategories = new List<SelectListItem>();
            this.ProductSubcategories = new List<SelectListItem>();
        }

      
        public List<SelectListItem> ProductCategories { get; set; }
        public List<SelectListItem> ProductSubcategories { get; set; }

      
        public int ProductCategoryID { get; set; }
        public int ProductSubcategoryID { get; set; }
    }
}