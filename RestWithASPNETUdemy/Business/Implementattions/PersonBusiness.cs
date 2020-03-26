using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class PersonBusiness : IPersonBusiness
    {

        private IRepository<Person> repository;
        private readonly PersonConverter converter;

        public PersonBusiness(IRepository<Person> repository)
        {
            this.repository = repository;
            this.converter = new PersonConverter();
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public PersonVO create(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            personEntity =  this.repository.create(personEntity);
            return this.converter.Parse(personEntity);
        }

        // Método responsável por retornar uma pessoa
        public PersonVO findById(long id)
        {
            return this.converter.Parse(this.repository.findById(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<PersonVO> findAll()
        {
            return this.converter.ParseList(this.repository.findAll());
        }

        // Método responsável por atualizar uma pessoa
        public PersonVO update(PersonVO person)
        {
            var personEntity = this.converter.Parse(person);
            personEntity =  this.repository.update(personEntity);
            return this.converter.Parse(personEntity);
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void delete(long id)
        {
            this.repository.delete(id);
        }

    }
}
