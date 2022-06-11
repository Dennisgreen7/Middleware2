using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareHW2
{
    public class ClassMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool isStudentsPath;
            string classId;
            try
            {
                isStudentsPath = (context.Request.Path.Value).Split('/')[1].ToLower().Contains("students");
            }
            catch
            {
                isStudentsPath = false;
            }

            try
            {
                classId = (context.Request.Path.Value).Split('/')[2];
                if(classId == null || classId == "")
                {
                    classId = "undefined";
                }
            }
            catch
            {
                classId = "Undefined";
            }

            if (isStudentsPath)
            {
                await context.Response.WriteAsync($"Class: {classId}\n");
                await next(context);
            }
            else
            {
                await context.Response.WriteAsync("Not student path\n");
            }
        }
    }
}
