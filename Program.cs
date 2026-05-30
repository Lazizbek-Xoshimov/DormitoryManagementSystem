using DormitoryManagementSystem.Menus;

namespace DormitoryManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        RoomMenu roomMenu = new RoomMenu();

        string prorgamFlow = string.Empty;

        do
        {
            roomMenu.BaseMenu();
            
            Console.Write("Select the neccesary section: ");
            int option = int.Parse(Console.ReadLine());
            roomMenu.MenuSelection(option);

            Console.WriteLine("Do you want to exit the program?");
            Console.Write("(yes/no): ");
            prorgamFlow = Console.ReadLine();
        } while (prorgamFlow.Equals("no"));
    }
}