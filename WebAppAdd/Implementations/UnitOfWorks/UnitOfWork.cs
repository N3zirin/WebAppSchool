using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Abstraction.IUnitOfWorks;
using WebAppAdd.Data;
using WebAppAdd.Entities;
using WebAppAdd.Implementations.Repositories;

namespace WebAppAdd.Implementations.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebAppAddDbContext _webAppAddDbContext;
        private readonly Dictionary<Type, object> _repositories;
        public UnitOfWork(WebAppAddDbContext webAppAddDbContext)
        {
            _webAppAddDbContext = webAppAddDbContext;
        }
        public void Dispose()
        {
            _webAppAddDbContext.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))//bele bir key var yoxsa yox onu tapir
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];//key in qarsiligi olan value ni qaytarir  
            }
            IRepository<TEntity> repository = new Repository<TEntity>(_webAppAddDbContext);
            _repositories.Add(typeof(TEntity), repository);//yoxdusa da elave edir
            return repository;
        }

        public async Task<int> SaveChangesAsync()//affected row sayi
        {
            return await _webAppAddDbContext.SaveChangesAsync();    
        }
    }
}
