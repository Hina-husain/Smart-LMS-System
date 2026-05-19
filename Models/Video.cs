using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartLMS.Models
{
    public class Video
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CourseId { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public string VideoUrl { get; set; } = string.Empty;
        
        public int DurationMinutes { get; set; }
        
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
