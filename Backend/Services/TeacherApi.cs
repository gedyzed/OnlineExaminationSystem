using Backend.Data;
using Backend.Data.Models;
using Backend.DTO;

namespace Backend.Services;

public class TeacherApi
{
    private ExamDbContext _context;

    public TeacherApi(ExamDbContext context)
    {
        _context = context;
    }

    //Questions 
    public void AddQuestion(QuestionDTO question)
    {
        var _question = new Question()
        {
            QuestionId = question.QuestionId,
            ExamId = question.ExamId,
            QuestionText = question.QuestionText,
            Choice_A = question.Choice_A,
            Choice_B = question.Choice_B,
            Choice_C = question.Choice_C,
            Choice_D = question.Choice_D,
            Answer = question.Answer
        };
        _context.Questions.Add(_question);
        _context.SaveChanges();
    }

    public Question GetQuestionById(string questionId, string examId)
    {
        return _context.Questions.FirstOrDefault(x => x.QuestionId == questionId && x.ExamId == examId);
    }

    public List<Question> GetAllQuestions(string examId)
    {
        return _context.Questions.Where(x => x.ExamId == examId).ToList();
    }
    public Question EditQuestion(string examId, string questionId, QuestionDTO question)
    {
        var existingQuestion = _context.Questions
            .FirstOrDefault(q => q.QuestionId == questionId && q.ExamId == examId);

        if (existingQuestion == null)
        {
            throw new Exception("Question not found.");
        }
        
        existingQuestion.QuestionText = question.QuestionText;
        existingQuestion.Choice_A = question.Choice_A;
        existingQuestion.Choice_B = question.Choice_B;
        existingQuestion.Choice_C = question.Choice_C;
        existingQuestion.Choice_D = question.Choice_D;
        existingQuestion.Answer = question.Answer;
        
        _context.SaveChanges();

        return existingQuestion;
    }

    public void DeleteQuestion(string questionId, string examId)
    {
         var question  = _context.Questions.FirstOrDefault(q => q.QuestionId == questionId && q.ExamId == examId);

         if (question != null)
         {
             _context.Questions.Remove(question);
             _context.SaveChanges();
         }
     
    }
    
    //Exams 
    public void AddExam(ExamDTO exam)
    {
        var _exam = new Exam()
        {
            ExamID = exam.ExamID,
            Title = exam.Title,
            Course = exam.Course,
            Departement = exam.Departement,
            Status = exam.Status
        };
        _context.Exams.Add(_exam);
        _context.SaveChanges();
    }
    public List<Exam> GetAllExams() => _context.Exams.ToList();
    public Exam GetExamById(string examId) => _context.Exams.FirstOrDefault(e => e.ExamID == examId);
    public Exam EditExam(string examId, ExamDTO exam)
    {
        var existingExam = _context.Exams.FirstOrDefault(e => e.ExamID == exam.ExamID);

        if (existingExam == null)
        {
            throw new Exception("Exam not found.");
        }
        
        existingExam.Title = exam.Title;
        existingExam.Course = exam.Course;
        existingExam.Departement = exam.Departement;
        existingExam.Status = exam.Status;
        
        _context.SaveChanges();

        return existingExam;
    }

    public List<Exam> GetExamsByTeacher(string teacherId)
    {
        var exams = (from teacher in _context.Teachers
            join exam in _context.Exams
                on teacher.ExamId equals exam.ExamID
            where teacher.TeacherId == teacherId
            select new Exam
            {
                ExamID = exam.ExamID,
                Title = exam.Title,
                Departement = exam.Departement,
                Course = exam.Course,
                Status = exam.Status
            }).ToList();

        return exams;
    }

    public void EditTeacherExam(string examId, string teacherId)
    {
        var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
        
        if (teacher == null)
        {
            throw new Exception("Teacher not found.");
        }
        teacher.ExamId = examId;
        _context.SaveChanges();
    }

    
    //view student Results 
    public List<Report> ViewReports()
    {
        return _context.Reports.ToList();
    }
}