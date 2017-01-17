using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace UI.Filters
{
    public class DiagnosticFilterProvider : IFilterProvider
    {
        IList<ControllerAction> permittedActions = new List<ControllerAction>();

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            foreach (ControllerAction ca in permittedActions)
            {
                if (ControllerNameMatches(ca, actionDescriptor)
                    && ActionNameMatches(ca, actionDescriptor))
                {
                    yield return new Filter(new DiagnosticInfo(), FilterScope.First, null);
                    break;
                }
            }
            yield break;
        }

        private bool ControllerNameMatches(ControllerAction ca, ActionDescriptor ad)
        {
            return ca.ControllerName == ad.ControllerDescriptor.ControllerName 
                || ca.ControllerName == "*";
        }

        private bool ActionNameMatches(ControllerAction ca, ActionDescriptor ad)
        {
            return ca.ActionName == ad.ActionName 
                || ca.ActionName == "*";
        }


        public void Add(string controllerName, string actionName)
        {
            permittedActions.Add(
                new ControllerAction()
                {
                    ControllerName = controllerName,
                    ActionName = actionName
                });
        }



    }

    internal class ControllerAction
    {
        internal string ControllerName { get; set; }
        internal string ActionName { get; set; }
    }

}