using Microsoft.AspNetCore.Mvc;
using Shopsy.Core.DTOs;
using Shopsy.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shopsy.UI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("users")]
        public async Task<IActionResult> Index()
        {
            var dtoUsers = await _userService.GetAllUsersAsync();

            var users = dtoUsers.Select(x => new UserResponseDTO
            {
                Id = x.Id,
                PersonName = x.PersonName,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,
                LockoutEnabled = x.LockoutEnabled
            }).ToList();   

            return View(users);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
