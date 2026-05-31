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
        bool isDeleted = false;

        for (int i = 0; i < students.Length; i ++)
        {
            if (students[i] is null)
                continue;
            else if (students[i].RoomNumber == roomNumber)
            {
                students[i].RoomNumber = 0;
                students[i] = null;

                isDeleted = true;
            }
        }

        return isDeleted;
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