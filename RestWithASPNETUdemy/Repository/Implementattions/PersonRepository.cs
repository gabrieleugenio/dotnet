using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementattions
{
    public class PersonRepository : IPersonRepository
    {
        
        private MySQLContext context;

        public PersonRepository(MySQLContext context)
        {
            this.context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Person create(Person person)
        {
            try
            {
                this.context.Add(person);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        // Método responsável por retornar uma pessoa
        public Person findById(long id)
        {
            return this.context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Person> findAll()
        {
            return this.context.Persons.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Person update(Person person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!exists(person.Id)) return new Person();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = this.context.Persons.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(person);
                    this.context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void delete(long id)
        {
            var result = this.context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    this.context.Persons.Remove(result);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool exists(long? id)
        {
            return this.context.Persons.Any(p => p.Id.Equals(id));
        }
    
    }
}