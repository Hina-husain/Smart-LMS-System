using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SmartLMS.Interfaces
{
    // CONCEPT: Interface Segregation Principle & Separation of Concerns
    // This service interface handles the "File Upload System" logic requested.
    // Real implementation would save to Azure Blob, AWS S3, or Local Disk.
    public interface IFileUploadService
    {
        Task<string> UploadVideoAsync(IFormFile file, string courseId);
        Task<string> UploadAssignmentAsync(IFormFile file, string assignmentId);
        Task<byte[]> GenerateCertificatePdfAsync(string studentName, string courseName);
    }
}
