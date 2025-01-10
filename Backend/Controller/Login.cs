using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO.StudentDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller

{
    [Route("/login")]
    [ApiController]

    public class Login:ControllerBase
    {
       private readonly ExamDbContext _context;
       public Login(ExamDbContext context)
       {
        _context=context;
       }

        [HttpPost("/")]
        public IActionResult LoginM([FromBody] LoginDto loginData)
        {
            try
            {
                // Validate input
                if (loginData == null || string.IsNullOrWhiteSpace(loginData.UserID) || string.IsNullOrWhiteSpace(loginData.Password))
                {
                    return BadRequest(new { message = "Invalid login data provided." });
                }

                // Hash the password
                var hashedPassword = HashPassword(loginData.Password);

                // Query the database for the user
                var user = _context.Users
                                   .FirstOrDefault(e => e.UserID == loginData.UserID && e.Password == hashedPassword);

                if (user != null)
                {
                    HttpContext.Session.SetString("StudentId", user.UserID);
                    return Ok(new { userId = user.UserID, role = user.Role });
                }
                else
                {
                    // User not found
                    return Unauthorized(new { message = "Invalid username or password." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (not shown here)
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

    }
}