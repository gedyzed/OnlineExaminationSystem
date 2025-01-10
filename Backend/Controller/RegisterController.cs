using Microsoft.AspNetCore.Mvc;
using Backend.Services;
using Backend.DTO;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly RegisterApi _register;

    public RegistrationController(RegisterApi register)
    {
        _register = register;
    }
    
    [HttpPost("register-user")]
    public IActionResult RegisterUser([FromBody] UserDTO userDto)
    {
        try
        {
            var userId = _register.RegisterUser(userDto);
            return Ok(new { Message = "User registered successfully.", UserID = userId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("register-student/{studentId}")]
    public IActionResult RegisterStudent(string studentId, [FromBody] StudentDTO studentDto)
    {
        try
        {
            _register.RegisterStudent(studentId, studentDto);
            return Ok(new { Message = "Student registered successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("register-teacher/{teacherId}")]
    public IActionResult RegisterTeacher(string teacherId, [FromBody] TeacherDTO teacherDto)
    {
        try
        {
            _register.RegisterTeacher(teacherId, teacherDto);
            return Ok(new { Message = "Teacher registered successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpPost("register-admin/{adminId}")]
    public IActionResult RegisterAdmin(string adminId, [FromBody] AdminDTO adminDto)
    {
        try
        {
            _register.RegisterAdmin(adminId, adminDto);
            return Ok(new { Message = "Admin registered successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
