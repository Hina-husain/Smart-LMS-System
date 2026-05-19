using SmartLMS.Interfaces;
using SmartLMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLMS.Services
{
    // CONCEPT: Single Responsibility Principle (SRP)
    // Only handles Quiz-related business logic and calculations.
    public class QuizService : IQuizService
    {
        private readonly IGenericRepository<Quiz> _quizRepository;

        // CONCEPT: Dependency Injection
        public QuizService(IGenericRepository<Quiz> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesByCourseAsync(string courseId)
        {
            var allQuizzes = await _quizRepository.GetAllAsync();
            // CONCEPT: LINQ (Language Integrated Query) for filtering
            return allQuizzes.Where(q => q.CourseId == courseId).ToList();
        }

        public async Task<Quiz> GetQuizByIdAsync(string id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task CreateQuizAsync(Quiz quiz)
        {
            await _quizRepository.CreateAsync(quiz);
        }

        // CONCEPT: Business Logic Encapsulation
        public int CalculateScore(Quiz quiz, List<int> userAnswers)
        {
            int score = 0;
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                if (i < userAnswers.Count && quiz.Questions[i].CorrectOptionIndex == userAnswers[i])
                {
                    score++;
                }
            }
            return score;
        }
    }
}
