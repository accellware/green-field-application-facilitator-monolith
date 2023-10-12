using GFAF.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Core
{
    public interface IAggregateRoot
    {
        List<EventBase> DomainEvents { get; }

        void AddDomainEvent(EventBase @event);
        void ClearDomainEvents();
        void RemoveDomainEvent(EventBase @event);
    }
}
