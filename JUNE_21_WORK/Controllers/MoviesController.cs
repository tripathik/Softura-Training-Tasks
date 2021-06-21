using MVCusgDPR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace MVCusgDPR.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<MoviesModel> MvList = new List<MoviesModel>();
            using(IDbConnection dbcon=new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                MvList= dbcon.Query<MoviesModel>("select * from tbl_Movies").ToList();
            }
            return View(MvList);
        }

     
        public ActionResult Details(int num)
        {
            MoviesModel bk = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<MoviesModel>("select * from tbl_Movies where Number=" + num, new { num }).SingleOrDefault();
            }
            return View(bk);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(MoviesModel bmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string SqlQry = "insert into tbl_Movies(Movie_Name)values('" + bmodel.Movie_Name + "')";
                int rowins = dbcon.Execute(SqlQry);
            }


            return RedirectToAction("Index");

        }

      
        public ActionResult Edit(int num)
        {
            MoviesModel bk = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<MoviesModel>("select * from tbl_Movies where Number=" + num, new { num }).SingleOrDefault();
            }
            return View(bk);
        }

     
        [HttpPost]
        public ActionResult Edit(MoviesModel bk)
        {

            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string SqlQry = "update tbl_Books set Movie_Name='" + bk.Movie_Name + "' where Number=" + bk.Number;
                int rowins = dbcon.Execute(SqlQry);
            }
            return RedirectToAction("Index");

        }

     
        public ActionResult Delete(int num)
        {
            MoviesModel bk = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<MoviesModel>("select * from tbl_Movies where Number=" + num, new { num }).SingleOrDefault();
            }
            return View(bk);
            
        }

        [HttpPost]
        public ActionResult Delete(int num, FormCollection collection)
        {
            MoviesModel bk = new MoviesModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<MoviesModel>("delete from tbl_Movies where Number=" + num, new { num }).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }
    }
}
