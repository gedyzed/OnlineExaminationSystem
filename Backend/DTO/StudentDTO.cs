namespace Backend.DTO;

public class StudentDTO 
{
    public string StudentId { get; set; }
    public string Department { get; set; }
    public DateOnly Enrollment { get; set; }
    public string Semester { get; set; }
}