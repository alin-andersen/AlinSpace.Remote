using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlinSpace.Remote.Server.AspNetCore
{
    /// <summary>
    /// Represents extensions for <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    public static class EndpointRouteBuilderExtensions
    {
        static Lazy<JsonSerializerOptions> serializerOptions = new Lazy<JsonSerializerOptions>(() =>
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        });

        public static void MapService(
            this IEndpointRouteBuilder endpointRouteBuilder,
            Type serviceType,
            Func<HttpContext, Task>? beforeMethodInvocation = null,
            Func<HttpContext, Task>? afterMethodInvocation = null,
            Func<HttpContext, Exception, Task<bool>>? exceptionHandler = null)
        {
            var methodInfos = serviceType
                .GetMethods()
                .Where(x => x.IsPublic);

            foreach (var methodInfo in methodInfos)
            {
                (HttpMethod httpMethod, string path) = GetHttpMethodAndPath(methodInfo);

                var parameters = methodInfo.GetParameters();

                switch(httpMethod.Method)
                {
                    case "GET":

                        endpointRouteBuilder
                            .MapGet(path, new RequestDelegate(async context
                                => await HandleRequest(
                                    serviceType,
                                    methodInfo,
                                    parameters,
                                    context,
                                    beforeMethodInvocation,
                                    afterMethodInvocation,
                                    exceptionHandler)))
                            .WithName(path);

                        break;

                    case "POST":

                        endpointRouteBuilder
                            .MapPost(path, new RequestDelegate(async context
                                => await HandleRequest(
                                    serviceType,
                                    methodInfo,
                                    parameters,
                                    context,
                                    beforeMethodInvocation,
                                    afterMethodInvocation,
                                    exceptionHandler)))
                            .WithName(path);

                        break;

                    case "PUT":

                        endpointRouteBuilder
                            .MapPut(path, new RequestDelegate(async context
                                => await HandleRequest(
                                    serviceType,
                                    methodInfo,
                                    parameters,
                                    context,
                                    beforeMethodInvocation,
                                    afterMethodInvocation,
                                    exceptionHandler)))
                            .WithName(path);

                        break;

                    default:
                        break;
                }
            }
        }

        static (HttpMethod, string) GetHttpMethodAndPath(MethodInfo methodInfo)
        {
            var httpMethodAttribute = methodInfo.GetCustomAttribute<Refit.HttpMethodAttribute>();

            if (httpMethodAttribute == null)
            {
                throw new Exception();
            }

            return (httpMethodAttribute.Method, httpMethodAttribute.Path);
        }

        static async Task HandleRequest(
            Type serviceType,
            MethodInfo methodInfo,
            IEnumerable<ParameterInfo> parameterInfos,
            HttpContext context,
            Func<HttpContext, Task>? beforeMethodInvocation,
            Func<HttpContext, Task>? afterMethodInvocation,
            Func<HttpContext, Exception, Task<bool>>? exceptionHandler)
        {
            try
            {
                // Get scoped service.
                var service = context
                    .RequestServices
                    .GetRequiredService(serviceType);

                //var cancellationToken = context
                //    .RequestServices
                //    .GetService<CancellationToken>();

                #region Read and deserialize 

                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
                var jsonData = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(jsonData))
                    jsonData = "{}";

                var parameter = JsonSerializer.Deserialize(jsonData, parameterInfos.First().ParameterType, serializerOptions.Value);

                if (parameter == null)
                {
                    throw new Exception("Request parameter can not be null.");
                }

                #endregion

                if (beforeMethodInvocation != null)
                {
                    await beforeMethodInvocation.Invoke(context);
                }

                #region Invoke service

                var t = methodInfo.Invoke(service, parameters: new object[] { parameter, new CancellationToken() });

                if (t == null)
                {
                    throw new Exception("Response parameter can not be null.");
                }

                var task = (Task)t;

                // Invoke.
                await task.ConfigureAwait(false);

                #endregion

                #region Serialize and write output

                var resultProperty = task.GetType().GetProperty("Result"); // not perfect but works

                if (resultProperty == null)
                {
                    throw new Exception("Response parameter can not be null.");

                }

                var result = resultProperty.GetValue(task);
                await context.Response.WriteAsync(JsonSerializer.Serialize(result, serializerOptions.Value));

                #endregion

                if (afterMethodInvocation != null)
                {
                    await afterMethodInvocation.Invoke(context);
                }
            }
            catch (Exception e)
            {
                if (exceptionHandler != null)
                {
                    if (await exceptionHandler(context, e))
                        return;
                }

                throw;
            }
        }

        public static void MapService<TService>(
            this IEndpointRouteBuilder endpointRouteBuilder,
            Func<HttpContext, Task>? beforeMethodInvocation = null,
            Func<HttpContext, Task>? afterMethodInvocation = null,
            Func<HttpContext, Exception, Task<bool>>? exceptionHandler = null)
        {
            MapService(endpointRouteBuilder, typeof(TService), beforeMethodInvocation, afterMethodInvocation, exceptionHandler);
        }

        public static void MapServices(
            this IEndpointRouteBuilder endpointRouteBuilder,
            IEnumerable<Type> serviceTypes,
            Func<HttpContext, Task>? beforeMethodInvocation = null,
            Func<HttpContext, Task>? afterMethodInvocation = null,
            Func<HttpContext, Exception, Task<bool>>? exceptionHandler = null)
        {
            foreach(var serviceType in serviceTypes)
            {
                MapService(
                    endpointRouteBuilder: endpointRouteBuilder,
                    serviceType: serviceType,
                    beforeMethodInvocation: beforeMethodInvocation,
                    afterMethodInvocation: afterMethodInvocation,
                    exceptionHandler: exceptionHandler);
            }
        }
    }
}
