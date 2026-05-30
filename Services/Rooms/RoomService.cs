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
            Capacity = 3,
            CurrentStudents = 0,
            Floor = 1
        }
    };

    public Room[] GetAllRooms()
    {
        return rooms;
    }

    public Room GetRoomByNumber(int roomNumber)
    {
        foreach (Room room in rooms)
        {
            if (room.RoomNumber == roomNumber)
                return room;
        }

        return null;
    }

    public bool ModifyRoom(int roomNumber, Room room)
    {
        if (roomNumber <= indexOfRoom && roomNumber <= 10)
        {
            rooms[roomNumber] = room;
            return true;
        }

        return false;
    }

    public Room[] GetEmptyRoom()
    {
        Room[] emptyRooms = new Room[rooms.Length];
        int indexOfEmptyRoom = 0;

        foreach (Room room in rooms)
        {
            if (room.CurrentStudents == 0)
                emptyRooms[indexOfEmptyRoom ++] = room;
        }

        return emptyRooms;
    }
}