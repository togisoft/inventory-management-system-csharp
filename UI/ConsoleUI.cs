// TOLGA CAGLAYAN C# BASIC 2026/01

using System;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.UI
{
    public class ConsoleUI
    {
        private readonly InventoryManager _inventory;

        public ConsoleUI(InventoryManager inventory)
        {
            _inventory = inventory;
        }

        public void Run()
        {
            while (true)
            {
                // Display menu
                Console.Clear();
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List All Products");
                Console.WriteLine("3. Sell Product");
                Console.WriteLine("4. Restock Product");
                Console.WriteLine("5. Update Product");
                Console.WriteLine("6. Remove Product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice = ReadInt();
                // Handle menu choices
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AddFlow();
                        break;
                    case 2:
                        ListFlow();
                        break;
                    case 3:
                        SellFlow();
                        break;
                    case 4:
                        RestockFlow();
                        break;
                    case 5:
                        UpdateFlow();
                        break;
                    case 6:
                        RemoveFlow();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Pause();
                        break;
                }
            }
        }

        // Add product flow
        private void AddFlow()
        {
            string name = ReadNonEmptyString("Enter product name: ");
            decimal price = ReadDecimal("Enter product price (>=0): ", min: 0);
            int stock = ReadInt("Enter product stock (>=0): ", min: 0);

            _inventory.AddProduct(name, price, stock);

            Console.WriteLine("Product added successfully.");
            Pause();
        }

        // List all products flow
        private void ListFlow()
        {
            var products = _inventory.GetAll();
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                Pause();
                return;
            }

            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");
            }
            Pause();
        }

        private void SellFlow()
        {
            int id = ReadInt("Enter product ID to sell: ");
            int amount = ReadInt("Enter amount to sell (>0): ");

            _inventory.SellProduct(id, amount, out string msg);
            Console.WriteLine(msg);
            Pause();
        }

        // Restock product flow
        private void RestockFlow()
        {
            int id = ReadInt("Enter product ID to restock: ");
            int amount = ReadInt("Enter amount to restock: ");

            _inventory.RestockProduct(id, amount, out string msg);
            Console.WriteLine(msg);
            Pause();
        }

        // Update product flow
        private void UpdateFlow()
        {
            int id = ReadInt("Enter product ID to update: ");
            var p = _inventory.GetById(id);

            if (p == null)
            {
                Console.WriteLine("Product not found.");
                Pause();
                return;
            }
            Console.WriteLine($"Current Name: {p.Name}");
            Console.WriteLine($"Current Price: ${p.Price}");
            Console.WriteLine($"Current Stock: {p.Stock}");

            Console.Write("Enter new name (Enter to keep): ");
            string? newName = Console.ReadLine();
            decimal? newPrice = ReadOptionalDecimal("Enter new price (Enter to keep): ");
            int? newStock = ReadOptionalInt("Enter new stock (Enter to keep): ");

            _inventory.UpdateProduct(id, newName, newPrice, newStock, out string msg);
            Console.WriteLine(msg);
            Pause();
        }

        // Remove product flow
        private void RemoveFlow()
        {
            int id = ReadInt("Enter product ID to remove: ");

            if (_inventory.RemoveProduct(id))
            {
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Pause();
        }

        // Helpers
        // Pauses execution until a key is pressed
        private static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Reads an integer from console with optional prompt and minimum value
        private static int ReadInt(string? prompt = null, int? min = null)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(prompt))
                {
                    Console.Write(prompt);
                }

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (min.HasValue && value < min.Value)
                    {
                        Console.WriteLine($"Value must be >= {min.Value}");
                        continue;
                    }
                    return value;
                }

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        // Reads a decimal from console with optional prompt and minimum value
        private static decimal ReadDecimal(string prompt, decimal? min = null)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    if (min.HasValue && value < min.Value)
                    {
                        Console.WriteLine($"Value must be >= {min.Value}.");
                        continue;
                    }
                    return value;
                }

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        // Reads a non-empty string from console with a prompt
        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(s))
                {
                    return s.Trim();
                }
                Console.WriteLine("Input cannot be empty. Try again.");
            }
        }

        // Reads an optional decimal from console with a prompt
        private static decimal? ReadOptionalDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (decimal.TryParse(input, out decimal value))
                {
                    return value;
                }

                Console.WriteLine("Invalid number. Try again or press Enter to keep current.");
            }
        }

        // Reads an optional integer from console with a prompt
        private static int? ReadOptionalInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Invalid number. Try again or press Enter to keep current.");
            }
        }
    }
}
