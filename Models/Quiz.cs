using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SmartLMS.Models
{
    // CONCEPT: Object-Oriented Programming (Classes and Objects)
    public class Question
    {
        public string Text { get; set; } = string.Empty;
        
        // CONCEPT: Using Collections
        public List<string> Options { get; set; } = new List<string>();
        
        public int CorrectOptionIndex { get; set; }
    }

    public class Quiz
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CourseId { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public int TimeLimitMinutes { get; set; } = 30; // Default 30 min timer
        
        // CONCEPT: Composition (A Quiz has many Questions)
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
