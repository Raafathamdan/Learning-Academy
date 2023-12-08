using Learning_Academy.DTO.Course;
using Learning_Academy.Models;

namespace Learning_Academy.Interfaces
{
    public interface ICourseInterface
    {
        Task<List<CourseCardDTO>> GetAllCourseAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task CreateCourseAsync(CreateCourseDTO dto);
        Task UpdateCourseAsync(UpdateCourseDTO dto);
        Task DeleteCourseAsync(int id);
    }
}
