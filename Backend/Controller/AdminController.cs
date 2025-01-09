using Microsoft.AspNetCore.Mvc;
using Backend.Services;
using Backend.DTO;
namespace Backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private AdminApi _adminApi;

    public AdminController(AdminApi adminApi)
    {
        _adminApi = adminApi;
    }
    
    
}