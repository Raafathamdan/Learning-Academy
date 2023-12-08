using Learning_Academy.DTO.Category;
using Learning_Academy.Models;

namespace Learning_Academy.Interfaces
{
    public interface ICategoryInterface
    {
        Task <List<CategoryCardDTO>> GetAllCategoryAsync();
        Task <Category> GetCategoryByIdAsync(int Id);
        Task<List<CategoryCardDTO>> SearchCategoryAsync(string? title, string? discription);
        Task<int> CreateCategoryAsync(CreateCategoryDTO dto  );
        Task UpdateCategoryAsync(UpdateCategoryDTO dto);
        Task DeleteCategoryAsync(int Id);

    }
}
