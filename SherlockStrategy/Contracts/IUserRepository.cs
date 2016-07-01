using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        bool StatusChange(bool Status);
    }
}
