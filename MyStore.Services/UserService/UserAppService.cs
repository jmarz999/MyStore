using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Services.Utils;

namespace MyStore.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<User> userManager;

        public UserAppService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await userManager.Users.ToListAsync();

            return users.Select(x => x.EntityToDto()).ToList();
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            return user.EntityToDto();
        }

        public async Task CreateAsync(CreateUserDto user)
        {
            var result = await userManager.CreateAsync(user.DtoToEntity());
        }

        public async Task UpdateAsync(UserDto user)
        {
            try
            {
                var entity = user.DtoToEntity();
                
                var result = await userManager.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(User user)
        {
            var result = await userManager.DeleteAsync(user);
        }

        public List<string> GetGenderValues()
        {
            var gender = EnumExtensions.GetValues<Gender>();

            return gender.Select(x => x.GetDisplayName()).ToList();
        }
    }
}