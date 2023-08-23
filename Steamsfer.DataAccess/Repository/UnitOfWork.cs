using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public ICategoryRepository Category { get; private set; }

        ICategoryRepository IUnitOfWork.CategoryRepository => throw new NotImplementedException();

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
