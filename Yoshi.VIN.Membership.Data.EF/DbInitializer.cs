using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoshi.VIN.Membership.Data.EF
{
    public static class DbInitializer
    {
        public static void Initialize(MemberContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
