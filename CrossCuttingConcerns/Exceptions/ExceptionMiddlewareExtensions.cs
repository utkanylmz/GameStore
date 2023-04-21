using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
       public static void  ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) 
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
//IApplicationBuilder Extend edip Hata yonetim sinifini programa dahil eder.
