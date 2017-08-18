using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoshi.VIN.Membership.Data.EF
{
    public class MemberContextFactory : IDesignTimeDbContextFactory<MemberContext>

    {
        public MemberContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MemberContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Vin.Membership;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework");

            return new MemberContext(optionsBuilder.Options);    
        }
    }
}
