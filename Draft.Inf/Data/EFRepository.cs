using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Entities;
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

        public T GetById<T>(int id) where T : Entity
        {
            return _db.Set<T>().SingleOrDefault(e => e.Id == id);
        }
        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            return await _db.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }
        public T Get<T>(ISpecification<T> spec) where T : Entity
        {
            return ApplySpecification(spec).SingleOrDefault();
        }
        public async Task<T> GetAsync<T>(ISpecification<T> spec) where T : Entity
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }
        public void Add<T>(T entity) where T : Entity
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }
        public async Task AddAsync<T>(T entity) where T : Entity
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        public void AddRange<T>(IEnumerable<T> entities) where T : Entity
        {
            _db.Set<T>().AddRange(entities);
            _db.SaveChanges();
        }
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : Entity
        {
            await _db.Set<T>().AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }
        public void Delete<T>(T entity) where T : Entity
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }
        public async Task DeleteAsync<T>(T entity) where T : Entity
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : Entity
        {
            return ApplySpecification(spec).ToList();
        }
        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec = null) where T : Entity
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public void UpdateRange<T>(IEnumerable<T> entities) where T : Entity
        {
            foreach (var entity in entities)
                _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public async Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : Entity
        {
            foreach (var entity in entities)
                _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public void Update<T>(T entity) where T : Entity
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : Entity
        {
            return SpecificationEvaluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);
        }
    }
}