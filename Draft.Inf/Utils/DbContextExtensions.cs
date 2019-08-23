using System.Linq;
using Draft.Core.SharedKernel;
using Draft.Inf.Data;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Utils
{
    public static class DbContextExtensions
    {
        public static void RemoveAll<T>(this AppDbContext db) where T : Entity
        {
            var records = db.Set<T>().ToList();
            db.Set<T>().RemoveRange(records);
            db.SaveChanges();
        }

    }
}