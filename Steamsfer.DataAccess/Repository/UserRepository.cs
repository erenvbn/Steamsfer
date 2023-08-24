using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository.IRepository;
using Steamsfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User obj)
        {
            _db.Update(obj);
        }
    }
}
