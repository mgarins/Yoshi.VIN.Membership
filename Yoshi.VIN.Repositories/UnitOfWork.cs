using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoshi.VIN.Common;
using Yoshi.VIN.Membership.Data.EF;
using Yoshi.VIN.Membership.Repositories.Interfaces;

namespace Yoshi.VIN.Membership.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        internal MemberContext context;

        public UnitOfWork(IOptions<Connections> optionsAccessor)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MemberContext>();
            optionsBuilder.UseSqlServer(optionsAccessor.Value.Membership);
            context = new MemberContext(optionsBuilder.Options);

        }

        private IMemberRepository memberRepo;
        public IMemberRepository MemberRepository
        {
            get
            {
                if (memberRepo == null)
                {
                    memberRepo = new MemberRepository(context);
                }
                return memberRepo;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
