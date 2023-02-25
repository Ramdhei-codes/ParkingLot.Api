using Microsoft.EntityFrameworkCore;
using ParkingLot.Domain.Shared;
using ParkingLot.Infrastructure.Database;
using System.Linq.Expressions;

namespace ParkingLot.Infrastructure.Shared
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ParkingLotDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(ParkingLotDbContext dbContext, DbSet<T> dbSet)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await Task.Factory.StartNew(() =>
            {
                dbSet.Remove(entity);
            });

            return entity;
        }

        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);

            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Factory.StartNew(() =>
            {
                dbSet.Update(entity);
            });

            return entity;
        }
    }
}
