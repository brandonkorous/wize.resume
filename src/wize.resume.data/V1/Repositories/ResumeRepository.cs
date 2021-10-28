using wize.resume.data.V1.Models;
using wize.resume.data.V1.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using wize.common.use.repository.Models;
using wize.resume.data.V1;
using System;
using System.Threading.Tasks;

namespace wize.resume.data.V1.Repositories
{
    public class ResumeRepository : RepositoryBase<Guid, Resume>, IResumeRepository
    {
        private readonly ILogger<ResumeRepository> _logger;
        private readonly WizeContext _context;
        public ResumeRepository(ILogger<ResumeRepository> logger, WizeContext context) : base(logger, context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _logger = logger;
            _context = context;
        }

        public async Task<Resume> GetResumeCompleteAsync(Guid id)
        {
            var resume = await _context.Resumes
                .Include(r => r.Awards)
                .Include(r => r.Education)
                .Include(r => r.Experiences)
                .ThenInclude(e => e.Items)
                .ThenInclude(i => i.Children)
                .Include(r => r.Experiences)
                .ThenInclude(e => e.TagLinks)
                .ThenInclude(tl => tl.Tag)
                .FirstOrDefaultAsync(r => r.ResumeId == id);
            //var reduced = links.Select(LambdaBuilder.BuildSelect<Link>(fields));
            //var sculpted = reduced.ShapeData(fields);
            return resume;
        }
    }
}