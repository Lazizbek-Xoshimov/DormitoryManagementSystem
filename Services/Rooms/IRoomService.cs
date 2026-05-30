using DormitoryManagementSystem.Models;

namespace DormitoryManagementSystem.Services.Rooms;

public interface IRoomService
{
    Room[] GetAllRooms();
    Room GetRoomByNumber(int roomNumber);
    Room[] GetEmptyRoom();

    bool ModifyRoom(int roomNumber, Room room);
}