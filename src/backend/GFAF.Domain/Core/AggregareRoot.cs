using GFAF.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Core
{
    public abstract class AggregareRoot<T>: Entity<T>, IAggregateRoot
        where T: struct, IEquatable<T>
    {
        private readonly List<EventBase> _domainEvents = new();

        [NotMapped]
        public List<EventBase> DomainEvents { get => this._domainEvents; }

        public void AddDomainEvent(EventBase @event) => this._domainEvents.Add(@event);

        public void RemoveDomainEvent(EventBase @event) => this._domainEvents.Remove(@event);

        public void ClearDomainEvents() => this._domainEvents.Clear();
    }
}
