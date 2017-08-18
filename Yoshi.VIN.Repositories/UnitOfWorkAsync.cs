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
    public class UnitOfWorkAsync : IUnitOfWorkAsync, IDisposable
    {
        internal MemberContext context;

        public UnitOfWorkAsync(IOptions<Connections> optionsAccessor)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MemberContext>();
            optionsBuilder.UseSqlServer(optionsAccessor.Value.Membership);
            context = new MemberContext(optionsBuilder.Options);

        }

        private IMemberRepositoryAsync memberRepo;
        public IMemberRepositoryAsync MemberRepositoryAsync
        {
            get
            {
                if (memberRepo == null)
                {
                    memberRepo = new MemberRepositoryAsync(context);
                }
                return memberRepo;
            }
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
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
