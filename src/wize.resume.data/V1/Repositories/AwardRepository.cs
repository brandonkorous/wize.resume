using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;

namespace wize.resume.data.V1.Repositories
{
    public class AwardRepository : RepositoryBase<int, Award>, IAwardRepository
    {
        private readonly WizeContext _context;
        public AwardRepository(ILogger<IAwardRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}