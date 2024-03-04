using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DaneshkarShop.Presentation.Areas.Admin.ActionFilterAttributes;

public class CheckUserIsAdmin : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService))!;

        base.OnActionExecuting(context);

        #region Check User Access


        var userId = (int)context.HttpContext.User.GetUserId();

        var result = service.IsUserAdmin(userId);

        if (result == false)
        {
            context.HttpContext.Response.Redirect("/");
        }

        #endregion
    }
}

