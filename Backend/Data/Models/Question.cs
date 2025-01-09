namespace Backend.Data.Models;

public class Question
{
    public string QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string Answer { get; set; }
    
    //Navigation Property
    public string ExamId { get; set; }
    public Exam Exam { get; set; }
    public List<Choice> Choices { get; set; }
    
}