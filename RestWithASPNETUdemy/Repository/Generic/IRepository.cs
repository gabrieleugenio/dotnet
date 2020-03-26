using System.Collections.Generic;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T create(T item);
        T findById(long id);
        List<T> findAll();
        T update(T item);
        void delete(long id);
        bool exists(long? id);
    }
}