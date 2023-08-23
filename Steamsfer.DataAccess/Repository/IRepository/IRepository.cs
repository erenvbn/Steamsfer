using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Select Methods
        public IEnumerable<T> GetAll();
        public List<T> GetWhere(Expression<Func<T, bool>> method);

        //Get with LINQ expression delegation
        public T Get(Expression<Func<T, bool>> filter);

        //Operation Methods
        public void Add(T entity);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entity);
    }
}
