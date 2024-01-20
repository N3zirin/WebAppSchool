using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Data;
using WebAppAdd.Entities;

namespace WebAppAdd.Implementations.Repositories.EntitiesRepos
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(WebAppAddDbContext webAppAddDbContext) : base(webAppAddDbContext)
        {
        }
    }
}
