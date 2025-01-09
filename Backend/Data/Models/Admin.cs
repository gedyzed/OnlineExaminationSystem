namespace Backend.Data.Models;

public class Admin
{
    public string AdminId { get; set; }
    public string Department { get; set; }
    
    //Navigation Property
   
    public User User { get; set; }
    public List<Schedule> Schedules { get; set; }
}