// TOLGA CAGLAYAN C# BASIC 2026/01

// Inventory Manager to handle product operations
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class InventoryManager
    {
        private readonly List<Product> _products = [];

    // Add a new product to the inventory
    public void AddProduct(string name, decimal price, int stock)
    {
        _products.Add(new Product(name, price, stock));
    }

    // Retrieve all products
    public IReadOnlyList<Product> GetAll() => _products;
    // Retrieve a product by its ID
    public Product? GetById(int id) => _products.Find(p => p.Id == id);

    // Remove a product by its ID
    public bool RemoveProduct(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _products.Remove(product);
            return true;
        }
        return false;
    }

    // Sell a specified amount of a product
    public bool SellProduct(int id, int amount, out string message)
    {
        if (amount <= 0)
        {
            message = "Amount must be greater than zero.";
            return false;
        }
        var p = GetById(id);
        if (p == null)
        {
            message = "Product not found.";
            return false;
        }
        if (p.Stock < amount)
        {
            message = "Insufficient stock.";
            return false;
        }

        p.Stock -= amount;
        message = "Sale completed successfully.";
        return true;
    }

    // Restock a specified amount of a product
    public bool RestockProduct(int id, int amount, out string message)
    {
        if (amount <= 0)
        {
            message = "Amount must be greater than zero.";
            return false;
        }
        var p = GetById(id);
        if (p == null)
        {
            message = "Product not found.";
            return false;
        }
        p.Stock += amount;
        message = "Restock completed successfully.";
        return true;
    }

    // Update product details
    public bool UpdateProduct(int id, string? newName, decimal? newPrice, int? newStock, out string message)
    {
        var p = GetById(id);
        if (p == null)
        {
            message = "Product not found.";
            return false;
        }

        if (!string.IsNullOrWhiteSpace(newName))
        {
            p.Name = newName.Trim();
        }

        if (newPrice.HasValue)
        {
            if (newPrice.Value < 0)
            {
                message = "Price cannot be negative.";
                return false;
            }
            p.Price = newPrice.Value;
        }

        if (newStock.HasValue)
        {
            if (newStock.Value < 0)
            {
                message = "Stock cannot be negative.";
                return false;
            }
            p.Stock = newStock.Value;
        }

        message = "Product updated successfully.";
        return true;
    }
    }
}
