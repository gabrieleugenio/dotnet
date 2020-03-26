using System.Collections.Generic;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO create(BookVO book);
        BookVO findById(long id);
        List<BookVO> findAll();
        BookVO update(BookVO book);
        void delete(long id);
         
    }
}