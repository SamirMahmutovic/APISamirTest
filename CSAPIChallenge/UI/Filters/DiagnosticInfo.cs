using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Infrastructure;

namespace UI.Filters
{
    public class DiagnosticInfo : ActionFilterAttribute
    {
        Stopwatch timer = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Start();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();

            var browser = filterContext.HttpContext.Request.Browser;
            using (var monitorDb = new MonitorDbContext())
            {
                var diagnostic = new Diagnostic
                {
                    DiagnosticID = Guid.NewGuid(),
                    ApplicationName = "QA Forum",
                    WebServer = HttpContext.Current.Request.ServerVariables["SERVER_NAME"],
                    Browser = browser.Browser + "-" + browser.Version,
                    TargetController = filterContext.RouteData.Values["controller"].ToString(),
                    TargetAction = filterContext.RouteData.Values["action"].ToString(),
                    DiagnosticTime = DateTime.Now,
                    ExecutionTime = timer.ElapsedMilliseconds
                };

                monitorDb.Diagnostics.Add(diagnostic);
                monitorDb.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}