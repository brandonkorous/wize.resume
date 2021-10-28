using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wize.resume.odata.Config
{
    public class OpenAPIParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var apiDescription = context.ApiDescription;

            operation.Deprecated |= apiDescription.IsDeprecated();

            if(operation.Parameters != null)
            {
                foreach(var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                    if (parameter.Description == null)
                        parameter.Description = description.ModelMetadata?.Description;

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                        parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

                    parameter.Required |= description.IsRequired;
                }
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ducks-referrer",
                In = ParameterLocation.Header,
                Description = "something",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                }
            });
        }
    }
}
