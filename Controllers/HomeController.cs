using CardAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardAPI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		DeckDAL api = new DeckDAL();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			string deckID = api.GetDeck();
			CurrentDeck c = api.DrawCards(deckID);
			return View(c);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}