using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Services
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task CreateAsync(CreateUserDto user);
        Task UpdateAsync(UserDto user);
        Task DeleteAsync(User user);
        List<string> GetGenderValues();
    }
}