using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoshi.VIN.Membership.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IMemberRepository MemberRepository { get; }

    }
}
