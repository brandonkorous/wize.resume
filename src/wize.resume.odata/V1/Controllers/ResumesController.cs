using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using wize.common.tenancy.Interfaces;
using wize.resume.data;
using wize.resume.data.V1;
using wize.resume.data.V1.Models;

namespace wize.resume.odata.V1.Controllers
{
    [ODataRoutePrefix("Resumes")]
    [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxNodeCount = 400, MaxAnyAllExpressionDepth = 2)]
    public partial class ResumesController : BaseODataController<Guid, Resume>
    {
        private readonly WizeContext _context;
        private readonly ITenantProvider _tenantProvider;
        public ResumesController(ILogger<BaseODataController<Guid, Resume>> logger, IActionDescriptorCollectionProvider actionProvider, WizeContext context, ITenantProvider tenantProvider)
            : base(logger, actionProvider, context, tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }
    }
}