using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Progra620241_Assets_JosueVargasM2.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        private readonly string _apiKey = "P6Apikey";


        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {

                context.Result = new ContentResult()
                {

                    StatusCode = 401,
                    Content = "The http request doesnt contain security information"

                };
                return;

            }


            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            if (ApiKeyValue != null && !ApiKeyValue.Equals(ApiSalida))
            {

                context.Result = new ContentResult()
                {

                    StatusCode = 401,
                    Content = "Incorrect Apikey Data...."


                };
                return;

            }

            await next();

        }







    }
}
