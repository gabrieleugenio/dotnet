using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class PersonBusiness : IPersonBusiness
    {

        private IPersonRepository repository;

        public PersonBusiness(IPersonRepository repository)
        {
            this.repository = repository;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Person create(Person person)
        {
            return this.repository.create(person);
        }

        // Método responsável por retornar uma pessoa
        public Person findById(long id)
        {
            return this.repository.findById(id);
        }

        // Método responsável por retornar todas as pessoas
        public List<Person> findAll()
        {
            return this.repository.findAll();
        }

        // Método responsável por atualizar uma pessoa
        public Person update(Person person)
        {
            return this.repository.update(person);
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void delete(long id)
        {
            this.repository.delete(id);
        }

    }
}
