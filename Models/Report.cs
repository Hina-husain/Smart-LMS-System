using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartLMS.Models
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string ReportType { get; set; } = string.Empty; // e.g., "Financial", "UserActivity"
        
        public string GeneratedByAdminId { get; set; } = string.Empty;
        
        public string DataJson { get; set; } = string.Empty; // Storing serialized report data
        
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}
