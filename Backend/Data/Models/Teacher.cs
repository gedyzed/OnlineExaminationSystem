namespace Backend.Data.Models;

public class Teacher
{
    public string TeacherId { get; set; }
    public string ExamId { get; set; }
    
    //Navigation Property
    public string UserID { get; set; }
    public User User { get; set; }
}