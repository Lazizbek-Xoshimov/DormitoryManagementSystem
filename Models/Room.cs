namespace DormitoryManagementSystem.Models;

public class Room
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public Student[] CurrentStudents { get; set; }
    public int Floor { get; set; }
}