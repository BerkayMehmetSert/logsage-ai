using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LogSage.Api.Filters;

public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.Name.Equals("Analyze", StringComparison.OrdinalIgnoreCase))
        {
            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = new Dictionary<string, OpenApiSchema>
                            {
                                ["File"] = new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "binary"
                                },
                                ["Query"] = new OpenApiSchema
                                {
                                    Type = "string"
                                }
                            },
                            Required = new HashSet<string> { "File", "Query" }
                        }
                    }
                }
            };
        }
    }
}