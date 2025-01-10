using Backend.Data.Models;

namespace Backend.DTO.Controllers;

public class ExamDto
{
    public string ExamID { get; set; }
    public string Title { get; set; }
    public string Departement { get; set; }
    public string Course { get; set; }
    public string Status {get; set;}

    public Schedule Schedule { get; set; }

}