﻿using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using wize.common.tenancy.Interfaces;
using wize.resume.data;
using wize.resume.data.V1;
using wize.resume.data.V1.Models;

namespace wize.resume.odata.V1.Controllers
{
    [ODataRoutePrefix("ExperienceItems")]
    public partial class ExperienceItemsController : BaseODataController<int, ExperienceItem>
    {
        private readonly WizeContext _context;
        private readonly ITenantProvider _tenantProvider;
        public ExperienceItemsController(ILogger<BaseODataController<int, ExperienceItem>> logger, IActionDescriptorCollectionProvider actionProvider, WizeContext context, ITenantProvider tenantProvider)
            : base(logger, actionProvider, context, tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }
    }
}