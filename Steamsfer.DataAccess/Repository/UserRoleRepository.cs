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
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private ApplicationDBContext _db;
        public UserRoleRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserRole obj)
        {
            _db.SaveChanges();
        }
    }
}
