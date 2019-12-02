using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApplicationAPI.API.Data;
using DatingApplicationAPI.API.Dtos;
using DatingApplicationAPI.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            //validate request

            userForRegisterDTO.Username=userForRegisterDTO.Username.ToLower();
            if(await _repo.UserExists(userForRegisterDTO.Username))
            return BadRequest("Username already exists");
            var userToCreate=new User{
                Username=userForRegisterDTO.Username
            };
            var createdUser= await _repo.Register(userToCreate,userForRegisterDTO.Password);
            return StatusCode(201);
        }

    }
}