using Microsoft.AspNetCore.Mvc;
using UsersAPI.Core.Interfaces.Services;
using UsersAPI.Core.Models.Requests;

namespace UsersAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> CreateNewUser(NewUserRequest request)
        {
            try
            {
                return await _userService.AddUser(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
