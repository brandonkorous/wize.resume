using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;
using System.Threading.Tasks;
using System.Linq;
using System;
using wize.common.use.paging.Interfaces;
using wize.common.use.repository.Extensions;
using wize.common.use.repository.Operators;
using wize.common.use.paging.Models;

namespace wize.resume.data.V1.Repositories
{
    public class ExperienceRepository : RepositoryBase<int, Experience>, IExperienceRepository
    {
        private readonly WizeContext _context;
        public ExperienceRepository(ILogger<IExperienceRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

    }
}