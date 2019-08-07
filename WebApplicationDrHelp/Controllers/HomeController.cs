using System.Collections.Generic;
using System.Web.Mvc;
using Capa.Presentacion.Models;

namespace Capa.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        //private DrHelpEntities db = new DrHelpEntities();
        //private CitasRepositorios citasRepositorios = new CitasRepositorios();

        public ActionResult DashboardV1()
        {
            return View();
        }
        public ActionResult DashboardV2()
        {
            return View();
        }


    }
}