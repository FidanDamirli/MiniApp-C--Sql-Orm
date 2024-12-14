using System;
using System.Threading.Tasks;
using MiniApp.BusinessLogic;
using MiniApp.BusinessLogic.Services;

namespace MiniApp.Presentation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Menu Operations");
                Console.WriteLine("2. Order Operations");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    await HandleMenuOperations();
                }
                else if (choice == "2")
                {
                    await HandleOrderOperations();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        private static Task HandleOrderOperations()
        {
            throw new NotImplementedException();
        }

        static async Task HandleMenuOperations()
        {
            var menuService = new MenuService();

            while (true)
            {
                Console.WriteLine("Menu Operations:");
                Console.WriteLine("1. Add New Menu Item");
                Console.WriteLine("2. Edit Menu Item");
                Console.WriteLine("3. Remove Menu Item");
                Console.WriteLine("4. View All Menu Items");
                Console.WriteLine("5. View Items by Category");
                Console.WriteLine("6. View Items by Price Range");
                Console.WriteLine("7. Search Items by Name");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        var price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Category: ");
                        var category = Console.ReadLine();
                        await menuService.AddMenuItemAsync(name, price, category);
                        Console.WriteLine("Menu item added successfully.");
                        break;

                    case "2":
                        Console.Write("Enter Menu Item ID to Edit: ");
                        var editId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("Enter New Price: ");
                        var newPrice = decimal.Parse(Console.ReadLine());
                        await menuService.EditMenuItemAsync(editId, newName, newPrice);
                        Console.WriteLine("Menu item updated successfully.");
                        break;
                }
            }
                }
            }
        }
