using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.MiddleWare
{
    public class JwtCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext ctx)
        {
           
            if (ctx.Session!= null && ctx.Session.Keys.Contains("JWToken"))
            {
                    string bearerToken = String.Format("Bearer {0}", ctx.Session.GetString("JWToken"));
                    ctx.Request.Headers.Add("Authorization", bearerToken);
            }
            return this._next(ctx);
        }
    }
    public static class JwtCookieMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtCookie(this IApplicationBuilder build)
        {
            return build.UseMiddleware<JwtCookieMiddleware>();
        }
    }
}
