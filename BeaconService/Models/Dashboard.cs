using System.Collections.Generic;

namespace BeaconService.Models
{
	public class Dashboard
	{
		public List<SightingDocument> Sightings { get; set; }
		public string ErrorMessage { get; set; }
	}
}