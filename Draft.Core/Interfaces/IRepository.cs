using System.Collections.Generic;
using System.Threading.Tasks;
using Draft.Core.SharedKernel;

namespace Draft.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : Entity;
        Task<T> GetByIdAsync<T>(int id) where T : Entity;
        T Get<T>(ISpecification<T> spec) where T : Entity;
        Task<T> GetAsync<T>(ISpecification<T> spec) where T : Entity;
        List<T> List<T>(ISpecification<T> spec = null) where T : Entity;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec = null) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        Task AddAsync<T>(T entity) where T : Entity;
        void AddRange<T>(IEnumerable<T> entities) where T : Entity;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : Entity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : Entity;
        Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(T entity) where T : Entity;

    }
}