using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SmartLMS.Models
{
    public class QuizResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string QuizId { get; set; } = string.Empty;
        
        public string StudentId { get; set; } = string.Empty;
        
        public int Score { get; set; }
        
        public int TotalQuestions { get; set; }
        
        public bool Passed { get; set; }
        
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
    }
}
