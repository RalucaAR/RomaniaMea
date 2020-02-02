using RomaniaMea;
using RomaniaMea.IRepositories;
using RomaniaMea.Models;
using RomaniaMea.Repositories;

namespace RomaniaMea.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
