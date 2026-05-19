using SmartLMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Interfaces
{
    // CONCEPT: Single Responsibility Principle (SOLID)
    // This interface focuses purely on Course business logic.
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(string id);
        Task CreateCourseAsync(Course course);
        Task UpdateCourseAsync(string id, Course course);
        Task DeleteCourseAsync(string id);
    }
}
