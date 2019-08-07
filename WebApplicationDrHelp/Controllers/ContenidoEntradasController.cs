using Capa.AccesoDatos;
using Capa.Presentacion.Extensions;
using Capa.Presentacion.Models;
using Capa.ServiciosDistribuidos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ContenidoEntradasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private RAEGlobonetEntities rAEGlobonetEntities = new RAEGlobonetEntities();
        private EntradaRepositorios entradaRepositorios = new EntradaRepositorios();

        // GET: ContenidoEntradas
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEntrada()
        {
            var entrada = entradaRepositorios.All();
            List<EntradaModels> lstObj = new List<EntradaModels>();



            foreach (var item in entrada)
            {
                EntradaModels item1 = new EntradaModels();
                item1.Id = item.Id;
                item1.Titulo = item.Titulo;
                item1.Autor = item.Autor;

                lstObj.Add(item1);
            }
            return Json(entrada, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEntradas()
        {
            var entrada = entradaRepositorios.All();
            List<EntradaModels> lstObj = new List<EntradaModels>();



            foreach (var item in entrada)
            {
                EntradaModels item1 = new EntradaModels();
                item1.Id = item.Id;
                item1.Titulo = item.Titulo;
        

                lstObj.Add(item1);
            }
            return Json(lstObj, JsonRequestBehavior.AllowGet);
        }
    }
}