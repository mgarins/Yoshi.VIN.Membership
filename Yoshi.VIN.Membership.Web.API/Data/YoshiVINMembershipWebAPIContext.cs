using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yoshi.VIN.Membership.Models;

namespace Yoshi.VIN.Membership.Web.API.Models
{
    public class YoshiVINMembershipWebAPIContext : DbContext
    {
        public YoshiVINMembershipWebAPIContext (DbContextOptions<YoshiVINMembershipWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Yoshi.VIN.Membership.Models.Member> Member { get; set; }
    }
}
