using System.Runtime.CompilerServices;
using DormitoryManagementSystem.Models;
using DormitoryManagementSystem.Services.Rooms;
using DormitoryManagementSystem.Services.Students;

namespace DormitoryManagementSystem.Menus;

public class RoomMenu
{
    IStudentService studentService = new StudentService();
    IRoomService roomService = new RoomService();

    public void BaseMenu()
    {
        Console.WriteLine("Welcome to Dormitory Management System");
        Console.WriteLine("1. Putting Student in a room");
        Console.WriteLine("2. View the list of rooms in the dormitory");
    }

    public void MenuSelection(int option)
    {
        switch (option)
        {
            case 1:
                this.PuttingStudentMenu();
                break;
            case 2:
                this.ViewRoomsMenu();
                break;
            default:
                Console.WriteLine("You have selected the wrong menu.");
                break;
        }
    }

    public void PuttingStudentMenu()
    {
        Console.Write("Enter which room you would like to stay in: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Room room = roomService.GetRoomByNumber(roomNumber);

        if (room is null)
            Console.WriteLine("No such room number found.");
        else
        {
            Student student = new Student();

            Console.Write("Enter the student's full name: ");
            student.FullName = Console.ReadLine();

            Console.Write("Enter the student's age: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter the student's faculty: ");
            student.Faculty = Console.ReadLine();

            Console.Write("Enter the student's course: ");
            student.Course = int.Parse(Console.ReadLine());

            student.RoomNumber = roomNumber;

            room.CurrentStudents ++;
            

            roomService.ModifyRoom(roomNumber, room);

            bool isAdded = studentService.CreateStudent(student);

            if (isAdded)
                Console.WriteLine($"{student.FullName} was placed in room {roomNumber}.");
            else
                Console.WriteLine("Student database is full.");
        }
    }

    public void ViewRoomsMenu()
    {
        Room[] rooms = roomService.GetAllRooms();

        foreach(Room room in rooms)
        {
            Console.WriteLine($"Room number: {room.RoomNumber}");
            Console.WriteLine($"Room capacity: {room.Capacity}");
            Console.WriteLine($"Number of students in the room: {room.CurrentStudents}");
            Console.WriteLine($"Room floor: {room.Floor}");
        }
    }
}