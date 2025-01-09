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
    
    [HttpGet("exams/{examId}/questions")]
    public IActionResult GetAllQuestions(string examId)
    {
        try
        {
            var questions = _teacherApi.GetAllQuestions(examId);
            if (questions == null || !questions.Any())
            {
                return NotFound(new { Message = "No questions found for the specified exam." });
            }
            return Ok(questions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
        }
    }


    [HttpGet("exams/{examId}/questions/{questionId}")]
    public IActionResult GetQuestionsById(string questionId, string examId)
    {
        try
        {
            var question = _teacherApi.GetQuestionById(questionId, examId);
            return Ok(question);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
        }
    }

    [HttpPut("Edit/exam/{examId}/Question/{questionId}")]
    public IActionResult EditQuestion(string examId, string questionId, [FromBody] QuestionDTO question)
    {
        var updatedQuestion = _teacherApi.EditQuestion(examId, questionId, question);
        return Ok(updatedQuestion);
    }

    [HttpDelete("Delete/{examId}/{questionId}")]
    public IActionResult DeleteQuestion(string examId, string questionId)
    {
        _teacherApi.DeleteQuestion(examId, questionId);
        return Ok(new { message = "Question deleted successfully!" });
    }

    [HttpPost("AddExam/{teacherId}")]
    public IActionResult AddExam([FromBody]ExamDTO exam, string teacherId)
    {
        _teacherApi.AddExam(exam);
        _teacherApi.InsertToTeacher(exam.ExamID, teacherId);
        return Ok(new { message = "Exam added successfully!" });
    }
    [HttpGet("exams/all-exams")]
    public IActionResult GetAllExams()
    {
        try
        {
            var _exams = _teacherApi.GetAllExams(); 
            if (_exams == null || !_exams.Any())
            {
                return NotFound(new { message = "No exams found for the given ID." });
            }
            return Ok(_exams);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching exams.", error = ex.Message });
        }
    }

    [HttpGet("exams/{examId}")]
    public IActionResult GetExamById(string examId)
    {
        try
        {
            var _exam = _teacherApi.GetExamById(examId);
            if (_exam == null)
            {
                return NotFound(new { message = "Exam not found with the given ID." });
            }
            return Ok(_exam);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching the exam.", error = ex.Message });
        }
    }

    [HttpGet("view-Report")]
    public IActionResult GetViewReport()
    {
        try
        {
            var reports = _teacherApi.ViewReports();

            if (reports == null || !reports.Any())
            {
                return NotFound(new { message = "No reports available." });
            }

            return Ok(reports);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while fetching reports.", error = ex.Message });
        }
    }

    [HttpGet("GetExamsByTeacher/{teacherId}")]
    public IActionResult GetExamsByTeacher(string teacherId)
    {
        try
        {
            var exams = _teacherApi.GetExamsByTeacher(teacherId);

            if (exams == null || !exams.Any())
            {
                return NotFound(new { Message = $"No exams found for Teacher ID: {teacherId}" });
            }

            return Ok(exams);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving exams.", Details = ex.Message });
        }
    }
    
}