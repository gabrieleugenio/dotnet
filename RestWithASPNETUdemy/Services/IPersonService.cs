using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person create(Person person);
        Person findById(long id);
        List<Person> findAll();
        Person update(Person person);
        void delete(long id);
    }
}
