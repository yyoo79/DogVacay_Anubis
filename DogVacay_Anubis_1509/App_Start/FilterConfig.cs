using System.Web;
using System.Web.Mvc;

namespace DogVacay_Anubis_1509
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
