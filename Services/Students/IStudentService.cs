using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Students;

public interface IStudentService
{
    bool CreateStudent(Student student);
}