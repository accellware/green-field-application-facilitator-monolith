using GFAF.Domain.Core;
using GFAF.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Infrastructure.Events.Madiator
{
    public class DomainEventDispatcher: IDomainEventDispatcher
    {
        private readonly IMediator mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task DispatchAndClearEvents(IEnumerable<IAggregateRoot> entities)
        {
            throw new NotImplementedException();
        }
    }
}
