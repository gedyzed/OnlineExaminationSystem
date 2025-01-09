namespace Backend.Data.Models;

public class Teacher
{
    public string TeacherId { get; set; }
    public string ExamId { get; set; }
    
    //Navigation Property
   
    public User User { get; set; }
}