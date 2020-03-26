using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Book> repository;
        public BookBusiness(IRepository<Book> repository){
            this.repository = repository;
        }
        public Book create(Book book)
        {
            return this.repository.create(book);
        }

        // Método responsável por retornar uma pessoa
        public Book findById(long id)
        {
            return this.repository.findById(id);
        }

        // Método responsável por retornar todas as pessoas
        public List<Book> findAll()
        {
            return this.repository.findAll();
        }

        // Método responsável por atualizar uma pessoa
        public Book update(Book book)
        {
            return this.repository.update(book);
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void delete(long id)
        {
            this.repository.delete(id);
        }
    }
}