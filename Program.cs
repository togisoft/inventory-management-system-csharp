// TOLGA CAGLAYAN C# BASIC 2026/01

using InventoryManagementSystem.Services;
using InventoryManagementSystem.UI;


public class Program
{
    public static void Main(string[] args)
    {
        var inventory = new InventoryManager();
        var ui = new ConsoleUI(inventory);
        ui.Run();
    }
}
