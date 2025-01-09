namespace Backend.Data.Models;

public class Report
{
    public float Score { get; set; }
    public char Grade { get; set; }
    public string Status { get; set; }
    
    //Navigation Property
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string ExamId { get; set; }
    public Exam Exam { get; set; }
}
