using Backend.Data;
using Backend.Data.Models;
using Backend.DTO;

namespace Backend.Services;

public class AdminApi
{
    private ExamDbContext _context;

    public AdminApi(ExamDbContext context)
    {
        _context = context;
    }
    
    
    
    
}