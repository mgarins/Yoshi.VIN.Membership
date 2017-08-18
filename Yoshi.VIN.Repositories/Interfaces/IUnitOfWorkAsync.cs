using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoshi.VIN.Membership.Repositories.Interfaces
{
    public interface IUnitOfWorkAsync
    {
        Task CommitAsync();
        IMemberRepositoryAsync MemberRepositoryAsync { get; }

    }
}
