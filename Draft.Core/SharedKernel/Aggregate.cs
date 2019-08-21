using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Draft.Core.SharedKernel
{
    public abstract class Aggregate : Entity
    {
        [NotMapped]
        public List<DomainEvent> Events { get; set; }
    }
}