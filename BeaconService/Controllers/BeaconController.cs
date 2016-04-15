using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using BeaconService.Helpers;
using BeaconService.Models;
using MongoDB.Driver;

namespace BeaconService.Controllers
{
	[RoutePrefix("beacon")]
    public class BeaconController : ApiController
	{
		private readonly IMongoDatabase _database;

		public BeaconController()
		{
			_database = MongoHelper.GetDatabase();
		}

		[Route("seen/{receiverId:int}")]
	    public void Post(int receiverId, [FromBody] string value)
	    {
			var sighting = new SightingDocument {RawData = value, Timestamp = DateTime.UtcNow, ReceiverId = receiverId};
			
		    var collection = _database.GetCollection<SightingDocument>("Sightings");
			collection.InsertOne(sighting);
			var count = collection.Count(x => true);

			var content = new StringContent(count.ToString(), Encoding.UTF8, "application/json");
			Ok(content);
	    }

		[Route("seen/current-status")]
		public IHttpActionResult Get()
		{
			var collection = _database.GetCollection<SightingDocument>("Sightings");
			var items = collection.Find(x => true);
			return Ok(items);
		}
	}
}
