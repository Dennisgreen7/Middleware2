using Microsoft.AspNetCore.Builder;

namespace MiddlewareHW2
{
    public static class ExtensionMethodMiddleware
    {
        public static IApplicationBuilder GetClassNumber(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClassMiddleware>();
        }

        public static IApplicationBuilder GetStudentNumber(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StudentMiddleware>();
        }
    }
}
