using System.Configuration;
using MongoDB.Driver;

namespace BeaconService.Helpers
{
	public static class MongoHelper
	{
		public static IMongoDatabase GetDatabase()
		{
			var client = new MongoClient(GetConnectionString());
			return client.GetDatabase("Beacons");
		}

		public static string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MongoDb"].ToString();
		}
	}
}