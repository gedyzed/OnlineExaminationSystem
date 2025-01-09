namespace Backend.DTO;

public class QuestionDTO
{
    public string ExamId { get; set; }
    public string QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string Choice_A {get; set;}
    public string Choice_B {get; set;}
    public string Choice_C {get; set;}
    public string Choice_D {get; set;}
    public string Answer { get; set; }
}