using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI {

    public class AuthenticationAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {

            bool IsAuthenticated = (bool)
                (filterContext
                .HttpContext
                .Session["IsAuthenticated"] != null
                &&
                (bool)filterContext
                .HttpContext
                .Session["IsAuthenticated"] == true) ? true : false;

            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();

            redirectTargetDictionary.Add("action", "Login");
            redirectTargetDictionary.Add("controller", "User");
            redirectTargetDictionary.Add("area", "");

            if (IsAuthenticated) {
                base.OnActionExecuting(filterContext);
            } else {
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }


        }

    }

}