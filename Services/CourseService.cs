using SmartLMS.Interfaces;
using SmartLMS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Services
{
    // CONCEPT: Business Logic Layer (Separation of Concerns)
    // Controllers call this service, and this service calls the repository.
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;

        // CONCEPT: Dependency Injection
        public CourseService(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            // Business Logic: You could filter out unpublished courses here if needed
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(string id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task CreateCourseAsync(Course course)
        {
            course.CreatedAt = DateTime.UtcNow; // Business Logic: set creation date
            await _courseRepository.CreateAsync(course);
        }

        public async Task UpdateCourseAsync(string id, Course course)
        {
            await _courseRepository.UpdateAsync(id, course);
        }

        public async Task DeleteCourseAsync(string id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }
}
