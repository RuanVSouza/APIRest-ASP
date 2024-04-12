using APIRest_ASP.Model;
using APIRest_ASP.Model.Base;
using APIRest_ASP.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace APIRest_ASP.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext _context;

        private DbSet<T> dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataSet = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByID(long id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        
        public bool Exists(long id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }
    }
}
