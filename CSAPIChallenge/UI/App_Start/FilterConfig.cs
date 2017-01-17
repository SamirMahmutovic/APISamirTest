using System.Web;
using System.Web.Mvc;
using UI.Filters;

namespace UI {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new DiagnosticInfo());

            DiagnosticFilterProvider provider = new DiagnosticFilterProvider();
            provider.Add("Post", "Create");
            provider.Add("Post", "Edit");
            provider.Add("*", "Index");
            FilterProviders.Providers.Add(provider);

        }
    }
}
