using WebAppAdd.Abstraction.IRepositories;
using WebAppAdd.Data;
using WebAppAdd.Entities;

namespace WebAppAdd.Implementations.Repositories.EntitiesRepos
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(WebAppAddDbContext webAppAddDbContext) : base(webAppAddDbContext)
        {
        }
    }
}
