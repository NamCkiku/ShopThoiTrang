using System.Web;
using System.Web.Mvc;

namespace PJ3ShopThoiTrang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}