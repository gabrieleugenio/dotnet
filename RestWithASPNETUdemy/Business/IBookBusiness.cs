using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book create(Book book);
        Book findById(long id);
        List<Book> findAll();
        Book update(Book book);
        void delete(long id);
         
    }
}