using MultipleDropDownList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleDropDownList.Controllers
{
    public class MultipleDDController : Controller
    {
        public ActionResult Index()
        {
            MDDLEntity entities = new MDDLEntity();
            MultipleDDModel model = new MultipleDDModel();
            foreach (var product in entities.ProductCategories)
            {
                model.ProductCategories.Add(new SelectListItem { Text = product.Name, Value = product.ProductCategoryID.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? ProductCategoryID, int? ProductSubcategoryID)
        {
            MultipleDDModel model = new MultipleDDModel();
            MDDLEntity entities = new MDDLEntity();
            foreach (var product in entities.ProductCategories)
            {
                model.ProductCategories.Add(new SelectListItem { Text = product.Name, Value = product.ProductCategoryID.ToString() });
            }

            if (ProductCategoryID.HasValue)
            {
                var subcats = (from ProductSubcategory in entities.ProductSubcategories
                              where ProductSubcategory.ProductCategoryID == ProductCategoryID.Value
                              select ProductSubcategory).ToList();
                foreach (var ProductSubcategory in subcats)
                {
                    model.ProductSubcategories.Add(new SelectListItem { Text = ProductSubcategory.Name, Value = ProductSubcategory.ProductSubcategoryID.ToString() });
                }
            }

            return View(model);
        }
    }
}