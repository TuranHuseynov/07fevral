using System.Web;
using System.Web.Mvc;

namespace BookLibrary_2._7._18_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
