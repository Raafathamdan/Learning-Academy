using Learning_Academy.Context;
using Learning_Academy.DTO.Category;
using Learning_Academy.Interfaces;
using Learning_Academy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Learning_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryInterface
    {
        private readonly LearningAcademyDbConext _context;

        public CategoryController(LearningAcademyDbConext context)
        {
            _context = context;
        }
        #region httpGet
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<List<CategoryCardDTO>>GetAllCategoryAsync()
        {
            var category = await _context.Categories.ToListAsync();
            var result = from c in category
                         select new CategoryCardDTO
                         {
                             Title = c.Title,
                             Discription = c.Discription
                         };
            return (result.ToList());
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<Category> GetCategoryByIdAsync(int Id)
        {
            var result = await _context.Categories.FindAsync(Id);
            return result;
        }
        [HttpGet]
        [Route("SearchCategory")]
        public async Task<List<CategoryCardDTO>> SearchCategoryAsync(string? title, string? discription)
        {
            var category = await _context.Categories.ToListAsync();
            if (title != null)
                category = category.Where(x => x.Title.Contains(title)).ToList();
            if (discription != null)
                category = category.Where(x => x.Discription.Contains(discription)).ToList();
            var result = from c in category
                         select new CategoryCardDTO
                         {
                             Title = c.Title,
                             Discription = c.Discription
                         };
            return (result.ToList());
        }
        #endregion
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<int> CreateCategoryAsync([FromBody]CreateCategoryDTO dto)
        {
            Category category = new Category();
            category.Title = dto.Title;
            category.Discription = dto.Discription;
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }
        [HttpDelete]
        [Route("DeleteCategory/{Id}")]
        public async Task DeleteCategoryAsync([FromRoute] int Id)
        {
            var result = await _context.Categories.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        [HttpPost]
        [Route("UpdateCategory")]
        public async Task UpdateCategoryAsync(UpdateCategoryDTO dto)
        {
                var result = await _context.Categories.FindAsync(dto.CategoryId);
                if (result != null)
                {
                    result.Discription = dto.Discription;
                    result.Title = dto.Title;
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
        }

       
    }
}
