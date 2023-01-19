using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using wize.common.tenancy.Interfaces;
using wize.resume.data;
using wize.resume.data.V1;
using wize.resume.data.V1.Models;

namespace wize.resume.odata.V1.Controllers
{
    [ODataRoutePrefix("Resumes")]
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


        /// <summary>
        /// OData based GET operation.
        /// This method will return the requested Dataset.
        /// </summary>
        /// <returns>IQueryable of requested type.</returns>
        [Authorize("list:resume")]
        [ODataRoute]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxNodeCount = 400, MaxAnyAllExpressionDepth = 2)]
        public override ActionResult<IQueryable<Resume>> Get()
        {
            return base.Get();
        }
    }
}