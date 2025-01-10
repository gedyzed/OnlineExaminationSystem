using Backend.Data;
using Backend.Data.Models;
using Backend.DTO;
using System.Security.Cryptography;

namespace Backend.Services;

public class RegisterApi
{
    
    private string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    
    private ExamDbContext _context;

    public RegisterApi(ExamDbContext context)
    {
        _context = context;
    }
    
    public string RegisterUser(UserDTO userDto)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
        if (existingUser != null)
        {
            throw new Exception("A user with this email already exists.");
        }

        var newUser = new User
        {
            UserID = userDto.UserID,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = HashPassword(userDto.Password),
            Role = userDto.Role,
            Gender = userDto.Gender,
            PhoneNumber = userDto.PhoneNumber,
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return newUser.UserID;
    }
    public void RegisterStudent(string studentId, StudentDTO studentDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserID == studentId);
        if (user == null || user.Role != "Student")
        {
            throw new Exception("Invalid user ID or user is not a Student.");
        }

        var newStudent = new Student
        {
            StudentId = studentId,
            Department = studentDto.Department,
            Enrollment = studentDto.Enrollment,
            Semester = studentDto.Semester,
        };

        _context.Students.Add(newStudent);
        _context.SaveChanges();
    }
    public void RegisterAdmin(string adminId, AdminDTO adminDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserID == adminId);
        if (user == null || user.Role != "Admin")
        {
            throw new Exception("Invalid user ID or user is not an Admin.");
        }

        var newAdmin = new Admin
        {
            AdminId = user.UserID,
            Department = adminDto.Department,
        };

        _context.Admins.Add(newAdmin);
        _context.SaveChanges();
    }
    public void RegisterTeacher(string teacherId, TeacherDTO teacherDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserID == teacherId);
        if (user == null || user.Role != "Teacher")
        {
            throw new Exception("Invalid user ID or user is not a Teacher.");
        }

        var newTeacher = new Teacher
        {
            TeacherId = user.UserID,
        };
            newTeacher.ExamId = null;

        _context.Teachers.Add(newTeacher);
        _context.SaveChanges();
    }
    
}