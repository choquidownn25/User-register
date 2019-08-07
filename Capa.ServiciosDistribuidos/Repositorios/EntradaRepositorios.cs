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
    public class EntradaRepositorios : IRepository<Entrada>
    {

        RAEGlobonetEntities context = new RAEGlobonetEntities();

        public void Add(Entrada entity)
        {

            Entrada entrada = new Entrada
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Autor = entity.Autor

            };

            context.Entrada.Add(entrada);
            context.SaveChanges();
        }

        public IEnumerable<Entrada> All()
        {
            try
            {
                List<Entrada> lstObj = new List<Entrada>();
                var result = (from item in context.Entrada
                              select new
                              {
                                  item.Id,
                                  item.Titulo,
                                  item.Autor
                                 

                              }).ToList();

                foreach (var item in result)
                {
                    Entrada item1 = new Entrada();

                    item1.Id = item.Id;
                    item1.Titulo = item.Titulo;
                    item1.Autor = item.Autor;
                



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

        public void Delete(Entrada entity)
        {
         
            context.Entrada.Remove(entity);
            context.SaveChanges();
        }

        public Entrada FindById(int id)
        {
            var consulta = (from r in context.Entrada where r.Id == id select r).FirstOrDefault();
            return consulta;
        }

        public void Update(Entrada entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
