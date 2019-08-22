using System.Collections.Generic;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;

namespace Draft.Inf.Data
{
    public class EFRepository : IRepository
    {
        private readonly AppDbContext _db;

        public EFRepository(AppDbContext db)
        {
            _db = db;
        }
        public T Add<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> AddRange<T>(IEnumerable<T> entities) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : Entity
        {
            throw new System.NotImplementedException();
        }
        public void Update<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }
    }
}