using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Rooms;

public class RoomService : IRoomService
{
    private int indexOfRoom = 101;

    Room[] rooms = new Room[]
    {
        new Room
        {
            RoomNumber = 101,
            Capacity = 4,
            CurrentStudents = 0,
            Floor = 1
        },

        new Room
        {
            RoomNumber = 102,
            Capacity = 4,
            CurrentStudents = 0,
            Floor = 1
        },
        new Room
        {
            RoomNumber = 201,
            Capacity = 3,
            CurrentStudents = 0,
            Floor = 2
        },
        new Room
        {
            RoomNumber = 202,
            Capacity = 3,
            CurrentStudents = 0,
            Floor = 2
        },
        new Room
        {
            RoomNumber = 301,
            Capacity = 2,
            CurrentStudents = 0,
            Floor = 3
        },
        new Room
        {
            RoomNumber = 302,
            Capacity = 2,
            CurrentStudents = 0,
            Floor = 3
        },
        new Room
        {
            RoomNumber = 303,
            Capacity = 2,
            CurrentStudents = 0,
            Floor = 3
        }
    };

    public Room[] GetAllRooms()
    {
        return rooms;
    }

    public Room GetRoomByNumber(int roomNumber)
    {
        Room returnedRoom = new Room();

        foreach (Room room in rooms)
        {
            if (room.RoomNumber == roomNumber)
                returnedRoom = room;
        }

        return returnedRoom;
    }

    public bool ModifyRoom(int roomNumber, Room room)
    {
        bool isModified = false;

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].RoomNumber == roomNumber)
            {
                rooms[i] = room;    
                isModified = true;
            }
        }

        return isModified;
    }

    public Room[] GetEmptyRoom()
    {
        Room[] emptyRooms = new Room[rooms.Length];
        int indexOfEmptyRoom = 0;

        foreach (Room room in rooms)
        {
            if (room.CurrentStudents < room.Capacity)
                emptyRooms[indexOfEmptyRoom ++] = room;
        }

        return emptyRooms;
    }
}