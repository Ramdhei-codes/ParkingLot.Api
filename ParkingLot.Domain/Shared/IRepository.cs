using System.Linq.Expressions;

namespace ParkingLot.Domain.Shared
{
    public interface IRepository<T> where T : class
    {
        public Task<T> InsertAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        public Task SaveChangesAsync();
    }
}
