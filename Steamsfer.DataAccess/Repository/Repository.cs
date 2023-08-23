using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository.IRepository;

namespace Steamsfer.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Fields
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;

        //Constructor, dependency injection
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //like _db.Categories = dbSet;
        }

            //GET Methods
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public List<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        //Operation Methods
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
