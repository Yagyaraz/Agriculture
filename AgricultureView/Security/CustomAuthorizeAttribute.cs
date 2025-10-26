using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AgricultureView.Security
{
    public class CustomAuthorizeAttribute : IAsyncAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;
        public AuthorizationPolicy Policy { get; }

        public CustomAuthorizeAttribute(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
            Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

           

            bool isAuthorized = _httpcontextAccessor.HttpContext.Session.GetString("user") != null;
            var area = context.RouteData.Values["area"];
            var controller = context.RouteData.Values["controller"] ?? "";
            var action = context.RouteData.Values["action"];

            var result = new UnauthorizedResult();
            if (HasAllowAnonymous(context))
            {
                // Allow anonymous access
                return;
            }
            if (isAuthorized)
            {
                //string key = _httpcontextAccessor.HttpContext.Session.Keys.ElementAt(0);
                //if (string.Equals(key, "User", StringComparison.OrdinalIgnoreCase))
                //{
                //    if (area != null && !area.Equals("Identity"))
                //    {
                //        context.Result = new UnauthorizedResult();
                //    }
                //    if (controller.Equals("Common"))
                //    {
                //        context.Result = new UnauthorizedResult();
                //    }

                //    return;
                //}
                //else
                //{

                return;
                //}
            }
            else
            {
                context.Result = new RedirectResult("/Account/Index");
            }

            return;
        }

        private static bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(x => x is IAllowAnonymousFilter))
                return true;

            // When doing endpoint routing, MVC does not add AllowAnonymousFilters for AllowAnonymousAttributes that
            // were discovered on controllers and actions. To maintain compat with 2.x,
            // we'll check for the presence of IAllowAnonymous in endpoint metadata.
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }

            return false;
        }

    }
}
