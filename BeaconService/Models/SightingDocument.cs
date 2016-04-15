using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeaconService.Models
{
	[BsonDiscriminator("envelopes")]
	public class SightingDocument
	{
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("receiver_id")]
		public int ReceiverId { get; set; }

		[BsonElement("timestamp")]
		public BsonDateTime Timestamp { get; set; }
		
		[BsonElement("raw_data")]
		public string RawData { get; set; }

		public DateTime LocalTimestamp => Timestamp.ToLocalTime();

	}
}