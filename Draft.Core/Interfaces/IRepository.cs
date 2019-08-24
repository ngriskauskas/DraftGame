using System.Collections.Generic;
using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity;
        T Get<T>(ISpecification<T> spec = null) where T : Entity;
        List<T> List<T>(ISpecification<T> spec = null) where T : Entity;
        T Add<T>(T entity) where T : Entity;
        IEnumerable<T> AddRange<T>(IEnumerable<T> entities) where T : Entity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }
}