using System.Collections.Generic;


namespace Capa.DominioDatos.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> All();
        T FindById(int id);
    }
}
