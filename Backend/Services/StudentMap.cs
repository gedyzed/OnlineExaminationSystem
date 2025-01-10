using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data.Models;
using Backend.DTO;
using Backend.DTO.Controllers;
using Backend.DTO.StudentDto;

namespace Backend.Services
{
    public static class StudentMap
    {
        
        public static ExamDto ToExamDto(this Exam e){
            return new ExamDto{
             ExamID =e.ExamID,
             Title=e.Title,
             Departement =e.Departement,
              Course=e.Course,
              Status =e.Status,
              Schedule=e.Schedule
    };
        }
        
        public static StudenQuestionDTO ToQuestionDto(this Question e)
        {
            return new StudenQuestionDTO
            {
                ExamId =e.ExamId,
                QuestionId =e.QuestionId,
                QuestionText=e.QuestionText,
                Choice_A =e.QuestionText,
                Choice_B =e.Choice_B,
                Choice_C=e.Choice_C,
                Choice_D =e.Choice_D
    };
        }
    }
}