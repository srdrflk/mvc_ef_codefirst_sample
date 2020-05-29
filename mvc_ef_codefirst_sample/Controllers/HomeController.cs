using mvc_ef_codefirst_sample.Models.Managers;
using mvc_ef_codefirst_sample.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ef_codefirst_sample.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            //var li = db.Kisiler.ToList();

            IndexViewModels model = new IndexViewModels();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();

            return View(model);
        }
    }
}