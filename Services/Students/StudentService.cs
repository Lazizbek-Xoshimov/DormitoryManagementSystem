using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Students;

public class StudentService : IStudentService
{
    private int indexOfStudent = 0;
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

    public bool DeleteStudents(int roomNumber)
    {
        for (int i = 0; i < students.Length; i ++)
        {
            if (students[i] is null)
                continue;
            
            if (students[i].RoomNumber == roomNumber)
                students[i] = null;
        }

        return true;
    }

    public Student[] ViewStudentsInRoom(int roomNumber)
    {
        Student[] studentsInRoom = new Student[students.Length];
        int indexStudentInRoom = 0;

        foreach (Student student in students)
        {
            if (student is null)
                continue;

            if (student.RoomNumber == roomNumber)
                studentsInRoom[indexStudentInRoom ++] = student;
        }

        return studentsInRoom;
    }
}