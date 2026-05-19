using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartLMS.Models
{
    public class Enrollment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string StudentId { get; set; } = string.Empty;
        
        public string CourseId { get; set; } = string.Empty;
        
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        
        public double ProgressPercentage { get; set; } = 0;
        
        public bool IsCompleted { get; set; } = false;
    }
}
