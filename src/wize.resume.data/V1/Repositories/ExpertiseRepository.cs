using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;

namespace wize.resume.data.V1.Repositories
{
    public class ExpertiseRepository : RepositoryBase<int, Expertise>, IExpertiseRepository
    {
        public ExpertiseRepository(ILogger<IExpertiseRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}