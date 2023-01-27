using System.Web;
using System.Web.Mvc;

namespace Proyecto_Gabriel_Ulate_Melany_Vargas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
