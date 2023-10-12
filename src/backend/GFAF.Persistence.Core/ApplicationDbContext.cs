using GFAF.Domain.Core;
using GFAF.Domain.Events;
using GFAF.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Persistence.Core
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventDispatcher dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
          IDomainEventDispatcher dispatcher)
            : base(options) => this.dispatcher = dispatcher;

        public async new Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            bool success = await base.SaveChangesAsync(cancellationToken) > 0;

            // ignore events if no dispatcher provided
            if (this.dispatcher == null) return success;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<IAggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await this.dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return success;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
