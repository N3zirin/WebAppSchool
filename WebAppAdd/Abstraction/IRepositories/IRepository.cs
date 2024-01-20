using Microsoft.EntityFrameworkCore;
using WebAppAdd.Entities;

namespace WebAppAdd.Abstraction.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> TEntity { get; }
        Task<bool> AddAsync(T entity);
        Task<bool> RemoveById(int id);
        bool Update(T entity);
        bool Remove(T data);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);


    }
}
