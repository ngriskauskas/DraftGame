using System;
using System.Linq.Expressions;
using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}