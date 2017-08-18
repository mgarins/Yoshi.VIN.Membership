using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yoshi.VIN.Membership.Data.EF;
using Yoshi.VIN.Membership.Models;
using Yoshi.VIN.Membership.Repositories.Interfaces;

namespace Yoshi.VIN.Membership.Repositories
{
    public partial class MemberRepositoryAsync : GenericRepositoryAsync<Member>, IMemberRepositoryAsync
    {
        internal MemberContext ctx;
        public MemberRepositoryAsync(MemberContext context) : base(context)
        {
            ctx = context;
        }

    }
}
