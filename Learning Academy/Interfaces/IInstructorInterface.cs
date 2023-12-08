using Learning_Academy.DTO.Instructor;
using Learning_Academy.Models;

namespace Learning_Academy.Interfaces
{
    public interface IInstructorInterface
    {
        Task<List<InstructorCardDTO>> GetAllInstructorAsync();
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task CreateInstructorAsync(CreateInstructorDTO dto);
        Task UpdateInstructorAsync(UpdateInstructorDTO dto);
        Task DeleteInstructorAsync(int id);
    }
}
