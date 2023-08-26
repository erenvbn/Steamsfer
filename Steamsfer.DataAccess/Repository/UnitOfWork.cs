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
        public ICategoryRepository CategoryRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IUserRoleRepository UserRoleRepository { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            UserRepository = new UserRepository(_db);
            UserRoleRepository = new UserRoleRepository(_db); 
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
