using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Data;
using WebAppAdd.Entities;

namespace WebAppAdd.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly WebAppAddDbContext _webAppAddDbContext;

        public Repository(WebAppAddDbContext webAppAddDbContext)
        {
            _webAppAddDbContext = webAppAddDbContext;
        }
        public DbSet<T> TEntity => _webAppAddDbContext.Set<T>();//db da olan table i getirir


        public async Task<bool> AddAsync(T entity)//t tipinde model alib bura elave edir
        {
            EntityEntry<T> entityEntry = await TEntity.AddAsync(entity);
            return entityEntry.State == EntityState.Added;//sets => crud(enum)
        }

        public IQueryable<T> GetAll()//entity - query formasinda getirsin ve tolist etsem onur ienumerable
        {
            var query = TEntity.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(int id) => await TEntity.FirstOrDefaultAsync(entity => entity.Id == id);

        public bool Remove(T data)//bu student in her seyi var, o cur data gelse isledirem
        {
            EntityEntry<T> entityEntry = TEntity.Remove(data);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveById(int id)
        {
            T data = await TEntity.FindAsync(id);
            return Remove(data);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = TEntity.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }


}
