using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Data.Models;
using Backend.DTO;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.Controller
{
    [Route("api/student")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        private readonly ExamDbContext _context;
        public StudentController(ExamDbContext context)
        
        {
            _context=context;
        }

       








        [HttpGet("/ExamList")]
        public IActionResult GetExams(){
            try{


    var data = _context.Exams
     .Select(dto => new
     {
         dto.ExamID,
         dto.Departement,
         dto.Course,
         dto.Status,
         dto.Title,
         dto.Schedule // Include the Schedule here
     })
     .ToList();
                return Ok(data);
            }
            catch(Exception ex){
                return NotFound();
            }
        }


        [HttpGet("TakeExam/{ExamId}")]

        public IActionResult GetExamById([FromRoute] String ExamId){
            try{
               var data=_context.Questions.Where(e=>e.ExamId==ExamId).Select(e=>e.ToQuestionDto());
               return Ok(data);
            }
            catch(Exception ex){
                return NotFound();

            }
        }

        [HttpPost("ExamAnswerSummition")]
        public IActionResult GetStudentAns([FromBody] List<QuestionDTO> studAns)

        {

           
            // Validate input
            if (studAns == null || !studAns.Any())
                return BadRequest("Student answers cannot be null or empty.");

            // Get ExamId from the first question
            string examId = studAns.First().ExamId;

            // Fetch all correct answers for the exam at once to minimize queries
            var correctAnswers = _context.Questions
                .Where(q => q.ExamId == examId)
                .ToDictionary(q => q.QuestionId, q => q.Answer);

            // Calculate correct answers
            float correctAns = studAns.Count(ans =>
                correctAnswers.ContainsKey(ans.QuestionId) && correctAnswers[ans.QuestionId] == ans.Answer);

            // Get StudentId from the session
            var studId = HttpContext.Session.GetString("StudentId");
            if (string.IsNullOrEmpty(studId))
                 return Unauthorized("Student ID is missing from the session.");

            // Calculate grade (placeholder logic)
            string grade = CalculateGrade(correctAns, studAns.Count);




        // Create a new report
        Report addNew = new Report
            {
            StudentId = studId,
            ExamId = examId,
            Score = correctAns,
            Grade = Convert.ToChar(grade),
            Status = "Taken"
            };

            // Save the report
            _context.Reports.Add(addNew);
            _context.SaveChanges();

            // Return the created report
            return Ok(new
            {
                StudentId = addNew.StudentId,
                ExamId = addNew.ExamId,
                Score = addNew.Score,
                Grade = addNew.Grade,
                Status = addNew.Status
            });
        }

        // Helper method to calculate grade
        private string CalculateGrade(float score, int totalQuestions)
        {
            double percentage = (double)score / totalQuestions * 100;

            if (percentage >= 90) return "A";
            if (percentage >= 80) return "B";
            if (percentage >= 70) return "C";
            if (percentage >= 60) return "D";
            return "F";
        }

        
        [HttpGet("Profile/{id}")]
        public IActionResult GetProfile([FromRoute] String id)
        {
            try
            { var data = _context.Users
            .Where(u => u.UserID == id) // Adjust the filter if needed
            .Include(u => u.Student)    // Include the related Student table
            .Select(e => new
            {
                e.UserID,
                e.FirstName,
                e.LastName,
                e.Email,
                e.Gender,
                e.PhoneNumber,
                e.Student // This will now include related data
            })
            .FirstOrDefault();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        [HttpGet("/Report")]
        public IActionResult getReports(){

            try{
            var studId = HttpContext.Session.GetString("StudentId");
            var data=_context.Reports.Where(e=>e.StudentId=="31");
            return Ok(data);
            }catch(Exception ex){
                return NotFound();
            }
        }

    }
}