using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SafeBoda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]  // Only users with Admin role can access
    public class AdminController : ControllerBase
    {
        [HttpGet("dashboard")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new { message = "Welcome to Admin Dashboard!", data = "Sensitive admin data here" });
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok(new { message = "List of all users", users = new[] { "User1", "User2", "User3" } });
        }
    }
}