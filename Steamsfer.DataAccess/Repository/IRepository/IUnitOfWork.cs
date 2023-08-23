using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository.IRepository
{
    internal interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        void Save();

    }
}
