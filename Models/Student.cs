namespace DormitoryManagementSystem.Models;

public class Student
{
    public int StudentId { get; set; } = 0;
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Faculty { get; set; }
    public int Course { get; set; }
    
    public int RoomNumber { get; set; }
}