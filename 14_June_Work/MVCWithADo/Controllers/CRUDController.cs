using MVCWithADo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADo.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
           //DataTable dt= mdl.DisplayBook();
            DataTable dt = mdl.DisplayAuthor();
            return View("Home",dt);
        }
        public ActionResult Insert()
        {
            return View("Create");
        }
        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if(action=="Submit")
            {
                CRUDModel mdl = new CRUDModel();
                //string Title = frm["txtTitle"];
                //int aid = Convert.ToInt32(frm["txtaid"]);
                //double Price = Convert.ToDouble(frm["txtPrice"]);
                //int rowIns = mdl.NewBook(Title, aid, Price);
                string AuthorName = frm["txtAuthorName"];
                int rowIns = mdl.NewAuthor(AuthorName);
                return RedirectToAction("Index");  
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}