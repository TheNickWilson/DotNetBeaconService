using System.Web.Mvc;
using BeaconService.Helpers;
using BeaconService.Models;
using MongoDB.Driver;

namespace BeaconService.Controllers
{
    public class DashboardController : Controller
    {
		private readonly IMongoDatabase _database;

		public DashboardController()
		{
			_database = MongoHelper.GetDatabase();
		}

		// GET: Dashboard
		public ActionResult Index()
        {
			var collection = _database.GetCollection<SightingDocument>("Sightings");
			var items = collection.Find(x => true).ToList();
			return View(items);
        }
    }
}