using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        public List<T> GetAll();
        public T GetSingle<T>() where T:class;
        public List<T> GetWhere(Expression<Func<T, bool>> method);




    }
}
