using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Book> repository;
        private readonly BookConverter converter;
        public BookBusiness(IRepository<Book> repository){
            this.repository = repository;
            this.converter = new BookConverter();
        }
        public BookVO create(BookVO book)
        {
            var bookEntity = this.converter.Parse(book);
            bookEntity = this.repository.create(bookEntity);
            return this.converter.Parse(bookEntity);
        }

        // Método responsável por retornar uma pessoa
        public BookVO findById(long id)
        {
            return this.converter.Parse(this.repository.findById(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<BookVO> findAll()
        {
            return this.converter.ParseList(this.repository.findAll());
        }

        // Método responsável por atualizar uma pessoa
        public BookVO update(BookVO book)
        {
            var bookEntity = this.converter.Parse(book);
            bookEntity = this.repository.update(bookEntity);
            return this.converter.Parse(bookEntity);
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void delete(long id)
        {
            this.repository.delete(id);
        }
    }
}