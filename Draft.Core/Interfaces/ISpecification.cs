using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}