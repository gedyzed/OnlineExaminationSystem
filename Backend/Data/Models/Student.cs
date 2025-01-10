namespace Backend.Data.Models;

public class Student
{
    public string StudentId { get; set; }
    public string Department { get; set; }
    public DateOnly Enrollment { get; set; }
    public string Semester { get; set; }
    
    //Navigation Property
    public User User { get; set; }
    public List<Report> Reports { get; set; }
    
}
