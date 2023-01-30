using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Models.User;
using HVEXText.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HVEXTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) =>
            _userService = userService;

        [HttpGet]
        public async Task<List<UserDto>> GetUsersAsync() =>
            await _userService.GetUsersById();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<UserDto>> GetUserAysnc(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto newUser)
        {
            var response = await _userService.AddUser( newUser);

            return CreatedAtAction(nameof(GetUserAysnc), new { id = response.Id }, response);

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, UserDto updatedUser)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            var userDto = await _userService.UpdatedUser(id, updatedUser);

            if (userDto is not null) return NoContent();

            else return BadRequest();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}