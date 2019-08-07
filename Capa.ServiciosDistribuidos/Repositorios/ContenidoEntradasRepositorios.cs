using Capa.AccesoDatos;
using Capa.DominioDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.ServiciosDistribuidos.Repositorios
{
    public class ContenidoEntradasRepositorios : IRepository<ContenidoEntradas>
    {
        RAEGlobonetEntities context = new RAEGlobonetEntities();

        public void Add(ContenidoEntradas entity)
        {
            ContenidoEntradas entradaContenido = new ContenidoEntradas
            {
                Id = entity.Id,
                IdEntrada = entity.IdEntrada,
                Contenido = entity.Contenido

            };

            context.ContenidoEntradas.Add(entradaContenido);
            context.SaveChanges();
        }

        public IEnumerable<ContenidoEntradas> All()
        {

            try
            {
                List<ContenidoEntradas> lstObj = new List<ContenidoEntradas>();
                var result = (from item in context.ContenidoEntradas
                              select new
                              {
                                  item.Id,
                                  item.IdEntrada,
                                  item.Contenido,


                              }).ToList();

                foreach (var item in result)
                {
                    ContenidoEntradas item1 = new ContenidoEntradas();

                    item1.Id = item.Id;
                    item1.IdEntrada = item.IdEntrada;
                    item1.Contenido = item.Contenido;




                    lstObj.Add(item1);
                }


                //return context.Categorias.OrderBy(e => e.id).ToList();
                return lstObj;
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;

            }


        }

        public void Delete(ContenidoEntradas entity)
        {
            context.ContenidoEntradas.Remove(entity);
            context.SaveChanges();
        }

        public ContenidoEntradas FindById(int id)
        {
            var consulta = (from r in context.ContenidoEntradas where r.Id == id select r).FirstOrDefault();
            return consulta;
        }

        public void Update(ContenidoEntradas entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
