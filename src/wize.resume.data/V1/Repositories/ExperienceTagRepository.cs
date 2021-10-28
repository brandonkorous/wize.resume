using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;
using System.Threading.Tasks;
using System.Linq;

namespace wize.resume.data.V1.Repositories
{
    public class ExperienceTagRepository : RepositoryBase<int, ExperienceTag>, IExperienceTagRepository
    {
        private readonly WizeContext _context;
        public ExperienceTagRepository(ILogger<IExperienceTagRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }
    }
}