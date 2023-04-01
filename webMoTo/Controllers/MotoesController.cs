using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMoTo.Models;
using System.Web.Mvc;

namespace webMoTo.Controllers
{
    public class MotoesController : Controller
    {
        // GET: Motoes
        MyDataDataContext Data =new MyDataDataContext();

        public ActionResult Index()
        {
            var allMoTo = from tt in Data.MoTos select tt;
            return View(allMoTo);
        }
    }
}