using Course.Sevices.Catalog.API.Dtos;
using Course.Sevices.Catalog.API.Models;
using Course.Share.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Course.Sevices.Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
    }
}
