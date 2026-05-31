using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Students;

public interface IStudentService
{
    bool CreateStudent(Student student);
    Student[] ViewStudentsInRoom(int roomNumber);
    bool DeleteStudents(int roomNumber);
}