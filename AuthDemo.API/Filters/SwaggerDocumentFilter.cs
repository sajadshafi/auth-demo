using AuthDemo.API.Config;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AuthDemo.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var route in RouteConfig.HiddenRoutes)
            {
                swaggerDoc.Paths.Remove(route);
            }
        }
    }
}