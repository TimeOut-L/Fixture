using FixtureManagement.filter;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginCheckFilter());
        }
    }
}
