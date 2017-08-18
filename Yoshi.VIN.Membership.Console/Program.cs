using Microsoft.EntityFrameworkCore;
using System;
using Yoshi.VIN.Membership.Data.EF;

namespace Yoshi.VIN.Membership.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MemberContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Vin.Membership;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework");
            using (var ctx = new MemberContext(optionsBuilder.Options))
            {
                DbInitializer.Initialize(ctx);
            }
        }
    }
}
