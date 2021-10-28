using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;

namespace wize.resume.data.V1.Repositories
{
    public class TagRepository : RepositoryBase<int, Tag>, ITagRepository
    {
        public TagRepository(ILogger<ITagRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}