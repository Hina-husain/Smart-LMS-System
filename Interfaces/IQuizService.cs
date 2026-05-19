using SmartLMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Interfaces
{
    // CONCEPT: Interface Segregation Principle (SOLID)
    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> GetQuizzesByCourseAsync(string courseId);
        Task<Quiz> GetQuizByIdAsync(string id);
        Task CreateQuizAsync(Quiz quiz);
        int CalculateScore(Quiz quiz, List<int> userAnswers);
    }
}
