namespace Backend.DTO;

public class ScheduleDTO
{
    public string ExamId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int AdminId { get; set; }
}