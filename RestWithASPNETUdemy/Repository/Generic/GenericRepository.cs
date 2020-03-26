using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext context;
        private DbSet<T> dataset;
        public  GenericRepository(MySQLContext context){
            this.context = context;
            dataset = this.context.Set<T>();
        }
        public T create(T item)
        {
           try
           {
              this.dataset.Add(item);
              this.context.SaveChanges(); 
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return item;
        }

        public void delete(long id)
        {
            var result = this.dataset.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if(result != null) this.dataset.Remove(result);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool exists(long? id)
        {
            return this.dataset.Any(item => item.Id.Equals(id));
        }

        public List<T> findAll()
        {
            return this.dataset.ToList();
        }

        public T findById(long id)
        {
            return this.dataset.SingleOrDefault( item => item.Id.Equals(id));
        }

        public T update(T item)
        {   
            if (!exists(item.Id)) return null;
            var result = this.dataset.SingleOrDefault(b => b.Id == item.Id);
            if(result != null)
            try
            {
                this.context.Entry(result).CurrentValues.SetValues(item);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }
    }
}