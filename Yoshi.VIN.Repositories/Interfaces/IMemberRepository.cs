using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoshi.VIN.Membership.Models;

namespace Yoshi.VIN.Membership.Repositories.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>, IGenericRepositoryAsync<Member>
    {
        bool MemberExists(int id);
        
    }
}
