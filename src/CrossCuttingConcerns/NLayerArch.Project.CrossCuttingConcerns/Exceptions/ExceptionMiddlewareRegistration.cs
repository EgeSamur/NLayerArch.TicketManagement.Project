using Microsoft.AspNetCore.Builder;

namespace NLayerArch.Project.CrossCuttingConcerns.Exceptions
{
    public static class ExceptionMiddlewareRegistration
    {

        public static void AddConfigureGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }

}
