using System;
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
			try
			{
				var collection = _database.GetCollection<SightingDocument>("Sightings");
				var model = new Dashboard {Sightings = collection.Find(x => true).ToList()};
				
				return View(model);
			}
			catch (Exception ex)
			{
				var errorModel = new Dashboard {ErrorMessage = ex.Message};
				return View(errorModel);
			}
        }
    }
}