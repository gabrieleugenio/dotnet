using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person create(Person person);
        Person findById(long id);
        List<Person> findAll();
        Person update(Person person);
        void delete(long id);
    }
}
