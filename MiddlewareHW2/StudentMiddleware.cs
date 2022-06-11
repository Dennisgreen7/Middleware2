using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareHW2
{
    public class StudentMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool isStudentsPath;
            string studentId;
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
                studentId = (context.Request.Path.Value).Split('/')[3];
            }
            catch
            {
                studentId = "Undefined";
            }
            if (isStudentsPath)
            {
                await context.Response.WriteAsync($"Student: {studentId}\n");
            }
            else
            {
                await context.Response.WriteAsync("Not student path\n");
            }
        }
    }
}
