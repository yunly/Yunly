using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }

            yield return "/Views/Legacy/{1}/{0}/View.cshtml";
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //throw new System.NotImplementedException();
        }
    }
}
