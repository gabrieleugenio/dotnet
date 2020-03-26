using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person create(Person person);
        Person findById(long id);
        List<Person> findAll();
        Person update(Person person);
        void delete(long id);
        bool exists(long? id);
    }
}