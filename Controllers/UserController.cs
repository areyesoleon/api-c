using MasterAPI.Models;
using MasterAPI.tools;
using Microsoft.AspNetCore.Mvc;

namespace MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private ApiCollection<UserModel> db = new ApiCollection<UserModel>("users");

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            await db.Post(user);

            return Created("created", true);
        }
    }
}