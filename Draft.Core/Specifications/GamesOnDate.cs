using System;
using System.Linq.Expressions;
using Draft.Core.Entities;

namespace Draft.Core.Specifications
{
    public class GamesOnDate : BaseSpecification<Game>
    {
        public GamesOnDate(DateTime date) : base(g => g.Date == date)
        {
        }
    }

}
