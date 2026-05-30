using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Students;

public class StudentService : IStudentService
{
    private int indexOfStudent = 0;
    private int capacity = 4;
    private Student[] students = new Student[10];

    public bool CreateStudent(Student student)
    {
        if (indexOfStudent < 10)
        {
            students[indexOfStudent ++] = student;
            return true;
        }

        return false;
    }

    public bool DeleteStudent(int studentId)
    {
        if (studentId >= 0 && studentId < indexOfStudent)
        {
            students[studentId] = null;
            Array.Resize(ref students, indexOfStudent);

            return true;
        }

        return false;
    }
}