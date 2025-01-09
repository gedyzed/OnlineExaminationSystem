namespace Backend.Data.Models;

public class User
{   
    public string UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public string phoneNumber { get; set; }
    
    //Navigation Property
    public Student Student { get; set; }
    public Admin Admin { get; set; }
    public Teacher Teacher { get; set; }
    
}