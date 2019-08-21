using System.Linq;
using Draft.Core.SharedKernel;
using Draft.Inf.Data;
using Microsoft.EntityFrameworkCore;

namespace Draft.Inf.Utils
{
    public static class DbContextExtensions
    {
        public static void RemoveAll<T>(this AppDbContext db, DbSet<T> set) where T : Entity
        {
            var records = set.ToList();
            set.RemoveRange(records);
            db.SaveChanges();
        }

    }
}