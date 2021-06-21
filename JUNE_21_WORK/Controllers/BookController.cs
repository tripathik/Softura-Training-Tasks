using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using MVCusgDPR.Models;
using System.Data;

namespace MVCusgDPR.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> Bklist = new List<BookModel>();
            using(IDbConnection dbcon=new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                Bklist = dbcon.Query<BookModel>("select * from tbl_Books").ToList();
            }
            return View(Bklist);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where bookid=" +id,new { id}).SingleOrDefault();
            }
            return View(bk);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string SqlQry = "insert into tbl_Books(Title,AuthorId,Price)values('" + bmodel.Title + "'," + bmodel.AuthorId + "," + bmodel.Price + " )";
                int rowins = dbcon.Execute(SqlQry);
            }


            return RedirectToAction("Index");
            
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where bookid=" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookModel bk)
        {

            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string SqlQry = "update tbl_Books set Title='" + bk.Title + "',AuthorId=" + bk.AuthorId + ",Price=" + bk.Price + " where BookId="+bk.BookId;
                int rowins = dbcon.Execute(SqlQry);
            }
            return RedirectToAction("Index");
            
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where bookid=" + id, new { id }).SingleOrDefault();
            }
            return View(bk);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("delete from tbl_Books where bookid=" + id, new { id }).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }
    }
}
