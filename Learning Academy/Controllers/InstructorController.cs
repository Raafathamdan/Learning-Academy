using Learning_Academy.Context;
using Learning_Academy.DTO.Instructor;
using Learning_Academy.Interfaces;
using Learning_Academy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase , IInstructorInterface
    {
        private readonly LearningAcademyDbConext _context;

        public InstructorController(LearningAcademyDbConext context)
        {
            _context = context;
        }
        #region HttpGet
        [HttpGet]
        [Route("GetAllInstructor")]
        public async Task<List<InstructorCardDTO>> GetAllInstructorAsync()
        {
            var instructor = await _context.Instructors.ToListAsync();
            var result = from I in instructor
                         select new InstructorCardDTO()
                         {
                             InstructorName = I.InstructorName,
                             Expertise = I.Expertise,
                             JoinDate = I.JoinDate

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetInstructorById/Id")]
        public async Task<Instructor> GetInstructorByIdAsync(int Id)
        {
            var result = await _context.Instructors.FindAsync(Id);
            return result;
        }
        #endregion
        [HttpPost]
        [Route("CreateInstructor")]
        public async Task CreateInstructorAsync(CreateInstructorDTO dto)
        {
            Instructor instructor = new Instructor();
            instructor.InstructorName = dto.InstructorName;
            instructor.InstructorEmail = dto.InstructorEmail;
            instructor.InstructorPhoneNumber = dto.InstructorPhoneNumber;
            instructor.JoinDate = DateTime.Now;
            await _context.AddAsync(instructor);
            await _context.SaveChangesAsync();

        }
               
        [HttpPut]
        [Route("UpdateInstructor")]
        public async Task UpdateInstructorAsync(UpdateInstructorDTO dto)
        {
            var result = await _context.Instructors.FindAsync(dto.InstructorId);
            if (result!=null)
            {
                result.InstructorName = dto.InstructorName;
                result.InstructorEmail = dto.InstructorEmail;
                result.InstructorPhoneNumber = dto.InstructorPhoneNumber;
                result.Expertise = dto.Expertise;
                _context.Update(result);
                await _context.SaveChangesAsync();
                
            }
        }
        [HttpDelete]
        [Route("DeleteInstructor/{Id}")]
        public async Task DeleteInstructorAsync(int Id)
        {
            var result = await _context.Instructors.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }

        }
    }

}
