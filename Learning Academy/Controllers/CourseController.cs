using Learning_Academy.Context;
using Learning_Academy.DTO.Course;
using Learning_Academy.Interfaces;
using Learning_Academy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase, ICourseInterface
    {
        private readonly LearningAcademyDbConext _context;

        public CourseController(LearningAcademyDbConext context)
        {
            _context = context;
        }
        #region HttpGet
        [HttpGet]
        [Route("GetAllCourse")]
        public async Task<List<CourseCardDTO>> GetAllCourseAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            var result = from C in courses
                         select new CourseCardDTO
                         {
                             Name = C.Name,
                             Description = C.Description,
                             Capacity = C.Capacity,
                             Location = C.Location,
                             StartDate = C.StartDate,
                             EndDate = C.EndDate

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetCourseById/{Id}")]
        public async Task<Course> GetCourseByIdAsync(int Id)
        {
            var result = await _context.Courses.FindAsync(Id);
            return result;
        }
        #endregion
        [HttpPost]
        [Route("CreateCourse")]
        public async Task CreateCourseAsync([FromBody]CreateCourseDTO dto)
        {
            Course course = new Course();
            course.Name = dto.Name;
            course.Description = dto.Description;
            course.Capacity = dto.Capacity;
            course.StartDate = dto.StartDate;
            course.EndDate = dto.EndDate;
            course.Location = dto.Location;
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
        }
       
        [HttpPut]
        [Route("UpdateCourse")]
        public async Task UpdateCourseAsync(UpdateCourseDTO dto)
        {
            var result = await _context.Courses.FindAsync(dto.CourseId);
            if (result!=null)
            {
                result.Name = dto.Name;
                result.Description = dto.Description;
                result.Capacity = dto.Capacity;
                result.Location = dto.Location;
                result.StartDate = dto.StartDate;
                result.EndDate = dto.EndDate;
                _context.Update(result);
               await _context.SaveChangesAsync();
            }
        }

        [HttpDelete]
        [Route("DeleteCourse/{Id}")]
        public async Task DeleteCourseAsync(int Id)
        {
            var result = await _context.Courses.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
