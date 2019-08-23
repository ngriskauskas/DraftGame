using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Draft.Core.SharedKernel
{
    public abstract class Entity
    {
        public int Id { get; set; }
        [NotMapped]
        public List<DomainEvent> Events { get; } = new List<DomainEvent>();
    }
}