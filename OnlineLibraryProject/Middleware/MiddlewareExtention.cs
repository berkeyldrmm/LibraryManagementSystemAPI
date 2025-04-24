namespace OnlineLibraryProject.WebApi.Middleware
{
    public static class MiddlewareExtention
    {
        public static IApplicationBuilder MiddlewareRegister(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
