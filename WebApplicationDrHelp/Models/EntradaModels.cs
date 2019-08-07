using Capa.AccesoDatos;
using Capa.Presentacion.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa.Presentacion.Models
{
    public class EntradaModels : Entrada
    {
        /// <summary>
        /// Accion Botom
        /// </summary>
        public ViewActionEnum ViewAction { get; set; }
        /// <summary>
        /// Listado de paises
        /// </summary>
        public IEnumerable<SelectListItem> NombrePais { get; set; }
    }
}