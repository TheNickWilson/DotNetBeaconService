using System;

namespace BeaconService.Models
{
	public class Sighting
	{
		public int ReceiverId { get; set; }
		public DateTime Timestamp { get; set; }
		public string RawData { get; set; }
	}
}