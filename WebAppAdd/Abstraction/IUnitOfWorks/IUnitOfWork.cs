using WebAppAdd.Abstraction.IRepositories;//using yaziram ki disposible olsun
using WebAppAdd.Entities;

namespace WebAppAdd.Abstraction.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable//bu bize dispose methodu versin deye bundan toredirik
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
