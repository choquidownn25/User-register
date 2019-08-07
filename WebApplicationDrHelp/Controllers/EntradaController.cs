using Capa.AccesoDatos;
using Capa.Presentacion.Extensions;
using Capa.Presentacion.Models;
using Capa.ServiciosDistribuidos.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    
  
    public class EntradaController : Controller
    {

        private readonly ApplicationDbContext _context;
        private RAEGlobonetEntities rAEGlobonetEntities = new RAEGlobonetEntities();
        private EntradaRepositorios entradaRepositorios = new EntradaRepositorios();
        // GET: Entrada
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EntradaDetail (Entrada entity)
        {
            
            
            EntradaModels entradaModels = new EntradaModels
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Autor = entity.Autor
                
            };
            
            return View(); 
        }


        [HttpGet]
        public ActionResult EntradaDetails (EntradaModels model)
        {
            Entrada entity = new Entrada
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Autor = model.Autor

            };
            switch (model.ViewAction)
            {
                case ViewActionEnum.Create:
                    this.entradaRepositorios.Add(entity);
                   
                    break;
                case ViewActionEnum.Delete:
                    this.entradaRepositorios.Delete(entity);
                    break;
                case ViewActionEnum.Detail:
                    int datoId = entity.Id;
                    this.entradaRepositorios.FindById(datoId);
                    break;
                case ViewActionEnum.Edit:
                    //this._PaisCatBL.Update(entity);
                    this.entradaRepositorios.Update(entity);
                    
                    break;
                
            }
            return RedirectToAction("Index") ;
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
    }
}