using Microsoft.AspNetCore.Mvc;
using Backend.Services;
using Backend.DTO;

namespace Backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private TeacherApi _teacherApi;

    public TeacherController(TeacherApi teacherApi)
    {
        _teacherApi = teacherApi;
    }

    [HttpPost("AddQuestion")]
    public IActionResult AddQuestion([FromBody]QuestionDTO question)
    {
        try
        {
            _teacherApi.AddQuestion(question);
            return Ok(new { message = "Question added successfully!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
}