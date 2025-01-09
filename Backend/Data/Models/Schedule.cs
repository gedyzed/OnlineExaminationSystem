namespace Backend.Data.Models;

public class Schedule
{
    public string ExamId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    
    //Navigation Property
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}