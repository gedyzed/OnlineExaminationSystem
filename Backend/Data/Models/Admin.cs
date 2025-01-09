namespace Backend.Data.Models;

public class Admin
{
    public int AdminId { get; set; }
    public string Department { get; set; }
    
    //Navigation Property
    public string UserID { get; set; }
    public User User { get; set; }
    public List<Schedule> Schedules { get; set; }
}