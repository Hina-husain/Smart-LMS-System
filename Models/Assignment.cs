using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartLMS.Models
{
    public class Assignment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CourseId { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string FileUrl { get; set; } = string.Empty; // For downloading assignment details
        
        public DateTime DueDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
