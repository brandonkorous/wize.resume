using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;

namespace wize.resume.data.V1.Repositories
{
    public class ProjectRepository : RepositoryBase<int, Project>, IProjectRepository
    {
        public ProjectRepository(ILogger<IProjectRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}