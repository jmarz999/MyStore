using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Helpers;
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
            try
            {
                var exists = await userManager.Users.AnyAsync(x => x.UserName == user.Username);

                if (exists)
                {
                    throw new AppExceptionHandler("User already exists.");
                }

                await userManager.CreateAsync(user.DtoToEntity(), user.Password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(UserDto user)
        {
            try
            {
                var entity = await userManager.FindByIdAsync(user.Id);
                entity.Surname = user.Surname;
                entity.UserName = user.Username;
                entity.Name = user.Name;
                entity.Email = user.Email;
                entity.Gender = user.Gender.ToEnum(Gender.Other);
                entity.DateOfBirth = user.DateOfBirth;

                var result = await userManager.UpdateAsync(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var entity = await userManager.FindByIdAsync(id);
                await userManager.DeleteAsync(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> GetGenderValues()
        {
            var gender = EnumExtensions.GetValues<Gender>();

            return gender.Select(x => x.GetDisplayName()).ToList();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
    }
}