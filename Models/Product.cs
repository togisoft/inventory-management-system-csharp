// TOLGA CAGLAYAN C# BASIC 2026/01

namespace InventoryManagementSystem.Models
{
    // Product class representing an item in the inventory
    public class Product(string name, decimal price, int stock)
    {
        // Auto-incrementing ID for products
        private static int _nextId = 1;

        // Properties
        public int Id { get; } = _nextId++;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public int Stock { get; set; } = stock;
    }
}
