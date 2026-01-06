# Inventory Management System

A simple console-based inventory management system built in C#.

This project was created as a refresher to revisit core C# concepts and as an introductory exercise for the Microsoft Full Stack Developer course. It focuses on reinforcing object-oriented programming (OOP), console application development, and structured program flow.

## Features

- Add products with name, price, and stock
- List all products
- Sell products (reduce stock)
- Restock products (increase stock)
- Update product details
- Remove products

## How to Run

1. Make sure you have .NET SDK installed.
2. Clone the repository.
3. Navigate to the project directory.
4. Run `dotnet run`.

## Project Structure

- `Models/`: Data models (Product)
- `Services/`: Business logic (InventoryManager)
- `UI/`: User interface (ConsoleUI)
- `Program.cs`: Entry point

## Pseudocode

```
CREATE Product structure (id, name, price, stock)
CREATE InventoryManager with product list
nextId = 1

LOOP forever
    SHOW menu
    choice ← READ integer

    SWITCH choice
        CASE 1:
            READ name, price, stock
            CREATE product with nextId
            ADD product to list
            nextId ← nextId + 1

        CASE 2:
            FOR each product
                DISPLAY id, name, price, stock
            END FOR

        CASE 3:
            READ id, quantity
            IF quantity > 0 AND product exists AND stock >= quantity
                stock ← stock - quantity
            ELSE
                DISPLAY error
            END IF

        CASE 4:
            READ id, quantity
            IF quantity > 0 AND product exists
                stock ← stock + quantity
            ELSE
                DISPLAY error
            END IF

        CASE 5:
            READ id
            IF product exists
                REMOVE product
            ELSE
                DISPLAY error
            END IF

        CASE 6:
            READ id
            IF product exists
                UPDATE name if provided
                UPDATE price if provided
                UPDATE stock if provided
            END IF

        CASE 0:
            EXIT program

        DEFAULT:
            DISPLAY "Invalid choice"
    END SWITCH
END LOOP
```
