//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContenidoEntradas
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public string Contenido { get; set; }
    
        public virtual Entrada Entrada { get; set; }
    }
}