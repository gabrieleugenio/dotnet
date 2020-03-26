using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO create(PersonVO person);
        PersonVO findById(long id);
        List<PersonVO> findAll();
        PersonVO update(PersonVO person);
        void delete(long id);
    }
}
