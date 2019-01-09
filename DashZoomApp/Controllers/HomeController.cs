using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using DashZoomApp.Models;
using DashZoomApp.Api;


namespace DashZoomApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiHelper _apiHelper = new ApiHelper();

	    public IActionResult Index()
	    {
	        var list = _apiHelper.GetRooms().Result;

            return View(list);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
