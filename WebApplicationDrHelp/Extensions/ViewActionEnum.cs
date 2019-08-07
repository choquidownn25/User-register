using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Capa.Presentacion.Extensions
{
    public enum ViewActionEnum
    {
        [Description("Nuevo")]
        Create,

        [Description("Eliminar")]
        Delete,

        [Description("Detalle")]
        Detail,

        [Description("Editar")]
        Edit
    }
}