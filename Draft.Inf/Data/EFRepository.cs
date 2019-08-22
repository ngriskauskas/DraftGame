using System.Collections.Generic;
using System.Linq;
using Draft.Core.Interfaces;
using Draft.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

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
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }
        public T GetById<T>(int id) where T : Entity
        {
            return _db.Set<T>().SingleOrDefault(e => e.Id == id);
        }
        public T Get<T>(ISpecification<T> spec) where T : Entity
        {
            return _db.Set<T>().SingleOrDefault(spec.Criteria);
        }
        public IEnumerable<T> AddRange<T>(IEnumerable<T> entities) where T : Entity
        {
            _db.Set<T>().AddRange(entities);
            _db.SaveChanges();
            return entities;
        }
        public void Delete<T>(T entity) where T : Entity
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }
        public List<T> List<T>(ISpecification<T> spec = null) where T : Entity
        {
            var query = _db.Set<T>().AsQueryable();
            if (spec != null)
                query = query.Where(spec.Criteria);
            return query.ToList();
        }
        public void UpdateRange<T>(IEnumerable<T> entities) where T : Entity
        {
            foreach (var entity in entities)
                _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Update<T>(T entity) where T : Entity
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}