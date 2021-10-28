using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using wize.common.tenancy.Interfaces;
using wize.resume.data.V1;
using wize.resume.data.V1.Models;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace wize.resume.odata.V1.Controllers
{
    [ODataRoutePrefix("Educations")]
    [ApiVersion("1.0")]
    public partial class EducationsController : BaseODataController<int, Education>
    {
        private readonly WizeContext _context;
        private readonly ITenantProvider _tenantProvider;
        public EducationsController(ILogger<BaseODataController<int, Education>> logger, IActionDescriptorCollectionProvider actionProvider, WizeContext context, ITenantProvider tenantProvider)
            : base(logger, actionProvider, context, tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }
    }
}