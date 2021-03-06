﻿using System;
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
    public partial class MemberRepository : GenericRepository<Member>, IMemberRepository
    {

        internal MemberContext ctx;
        public MemberRepository(MemberContext context) : base(context)
        {
            ctx = context;
        }

        public IEnumerable<Member> GetAll()
        {
            return ctx.Members.ToList();
        }

        public bool MemberExists(int id)
        {
            return ctx.Members.Any(m => m.ID == id);
        }
    }
}
