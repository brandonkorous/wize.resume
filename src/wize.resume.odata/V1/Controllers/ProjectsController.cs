using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using wize.common.tenancy.Interfaces;
using wize.resume.data;
using wize.resume.data.V1;
using wize.resume.data.V1.Models;

namespace wize.resume.odata.V1.Controllers
{
    [ODataRoutePrefix("Projects")]
    public partial class ProjectsController : BaseODataController<int, Project>
    {
        private readonly WizeContext _context;
        private readonly ITenantProvider _tenantProvider;
        public ProjectsController(ILogger<BaseODataController<int, Project>> logger, IActionDescriptorCollectionProvider actionProvider, WizeContext context, ITenantProvider tenantProvider)
            : base(logger, actionProvider, context, tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }
    }
}