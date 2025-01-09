namespace Backend.Data.Models;

public class Exam
{
    public string ExamID { get; set; }
    public string Departement { get; set; }
    public string Course { get; set; }
    public string Status {get; set;}
    
    //Navigation Property
    public List<Report> Reports { get; set; }
    public List<Question> Questions { get; set; }
    public List<Choice> Choices { get; set; }
}