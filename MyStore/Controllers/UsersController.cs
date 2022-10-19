﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.AuthHelpers;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserAppService userService;

        public UsersController(IUserAppService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetById(string id)
        {
            var user = await userService.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateUser(CreateUserDto user)
        {
            await userService.CreateAsync(user);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserDto user)
        {
            await userService.UpdateAsync(user);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                await userService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetGenderValues()
        {
            var gender = userService.GetGenderValues();

            return Ok(gender);
        }
    }
}