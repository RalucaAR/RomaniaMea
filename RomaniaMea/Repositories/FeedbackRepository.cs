using RomaniaMea.IRepositories;
using RomaniaMea.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomaniaMea.Repositories
{
   public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
