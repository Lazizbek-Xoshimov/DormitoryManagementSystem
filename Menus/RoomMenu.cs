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
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Welcome to Dormitory Management System");
        Console.ResetColor();
        Console.WriteLine("1. Set Student in a room");
        Console.WriteLine("2. View the list of rooms in the dormitory");
        Console.WriteLine("3. View available rooms");
        Console.WriteLine("4. Clearing the room from students");
        Console.WriteLine("5. See the students in the room");
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
            case 3:
                this.ViewEmptyRoomsMenu();
                break;
            case 4:
                this.DeleteStudentsMenu();
                break;
            case 5:
                this.ViewStudentsInRoomMenu();
                break;
            default:
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("You have selected the wrong menu.");
                    Console.ResetColor();
                    break;
                }
        }
    }

    public void PuttingStudentMenu()
    {
        Console.Clear();
        Console.Write("Enter which room you would like to stay in: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Room room = roomService.GetRoomByNumber(roomNumber);

        if (room is null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("No such room number found.");
            Console.ResetColor();
        }
        else if (room.CurrentStudents >= room.Capacity)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Oops. Room {roomNumber} is full of students.");
            Console.ResetColor();
        }
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
            bool isModified = roomService.ModifyRoom(roomNumber, room);

            if (isModified)
            {
                bool isAdded = studentService.CreateStudent(student);

                if (isAdded)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{student.FullName} was placed in room {roomNumber}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Student database is full.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("No such room available.");
                Console.ResetColor();
            }
        }
    }

    public void ViewRoomsMenu()
    {
        Room[] rooms = roomService.GetAllRooms();

        Console.Clear();
        foreach(Room room in rooms)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Room {room.RoomNumber}");
            Console.ResetColor();
            Console.WriteLine($"Room capacity: {room.Capacity}");
            Console.WriteLine($"Number of students in the room: {room.CurrentStudents}");
            Console.WriteLine($"Room floor: {room.Floor}");
        }
    }

    public void ViewEmptyRoomsMenu()
    {
        Room[] emptyRooms = roomService.GetEmptyRoom();

        Console.Clear();
        if (emptyRooms is null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("No vacant rooms available.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("The vacant rooms are as follows: ");
            foreach (Room room in emptyRooms)
            {
                if (room is null)
                    continue;

                Console.WriteLine($"Room number: {room.RoomNumber} ({room.CurrentStudents}/{room.Capacity})");
            }
        }
    }

    public void DeleteStudentsMenu()
    {
        Console.Clear();
        Console.Write("Enter the student in which room you want to delete: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Room room = roomService.GetRoomByNumber(roomNumber);

        if (room is null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("No such room available.");
            Console.ResetColor();
        }
        else
        {
            room.CurrentStudents = 0;
            bool isThere = roomService.ModifyRoom(roomNumber, room);

            if (isThere)
            {
                bool isDeleted = studentService.DeleteStudents(roomNumber);
                
                if (isDeleted)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("The room was successfully vacated.");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Room {roomNumber} is empty.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("No such room available.");
                Console.ResetColor();
            }
        }
    }

    public void ViewStudentsInRoomMenu()
    {
        Console.Clear();
        Console.Write("Enter which room you want to see the students in: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Student[] students = studentService.ViewStudentsInRoom(roomNumber);

        bool isEmpty = true;

        foreach (Student student in students)
        {
            if (student is not null)
                isEmpty = false;
        }

        if (isEmpty)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"There are no students in room {roomNumber}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"The students in room {roomNumber} are: ");
            for (int i = 0; i < students.Length; i ++)
            {
                if (students[i] is null)
                    continue;

                Console.WriteLine($"{i + 1}. {students[i].FullName}");
            }
        }
    }
}