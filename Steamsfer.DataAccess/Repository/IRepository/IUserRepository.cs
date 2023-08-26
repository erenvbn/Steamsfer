using Steamsfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        public void Update(User obj);
    }
}
