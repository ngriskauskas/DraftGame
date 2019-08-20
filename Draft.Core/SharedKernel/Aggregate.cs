using System.Collections.Generic;

namespace Draft.Core.SharedKernel
{
    public abstract class Aggregate : Entity
    {
        public List<DomainEvent> Events { get; set; }
    }
}