using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoshi.VIN.Membership.Models;

namespace Yoshi.VIN.Membership.Data.EF
{
    public static class DbInitializer
    {
        public static void Initialize(MemberContext context)
        {
            context.Database.EnsureCreated();
            // Add Users
            if (!context.Members.Any())
            {
                var members = new Member[]
                {
                    new Member {  UserName = "mGarins",FirstName="Martin", LastName="Garins", DOB= new DateTime(1970,12,1), Email = "mgarins@example.com"},
                    new Member {  UserName = "fFlintstone", FirstName="Fred", LastName="Flintstone",  DOB= new DateTime(1947,10,11),  Email = "fflintstone@example.com"},
                    new Member {  UserName = "bRubble", FirstName="Barney", LastName="Rubble",  DOB= new DateTime(1932,9,17),  Email = "brubble@example.com"}
                };

                foreach (Member m in members)
                {
                    context.Members.Add(m);
                }
                context.SaveChanges();

            }
        }
    }
}
