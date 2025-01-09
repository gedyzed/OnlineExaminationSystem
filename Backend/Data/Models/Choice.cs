namespace Backend.Data.Models;

public class Choice
{
    public string ChoiceId { get; set; }
    public string Choice_A {get; set;}
    public string Choice_B {get; set;}
    public string Choice_C {get; set;}
    public string Choice_D {get; set;}
    
    //Navigation property
    public string ExamId { get; set; }
    public Exam Exam { get; set; }
    public string QuestionId { get; set; }
    public Question Question { get; set; }
}