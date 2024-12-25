using System;
using System.Collections.Generic;
using System.Threading;

namespace PharmacyApp
{
    // For each core aspect of the application, we will create a class having functions 
    // These functions would provide the core functionality -
    // and manipulate the data structures that contain the instances of a class

    public class Medicine
    {
        private string itemId, itemName;
        private double itemPrice;
        private int quantity;

        public Medicine(string id, string name, double price, int quantity)
        {
            itemId = id;
            itemName = name;
            itemPrice = price;
            this.quantity = quantity;
        }

        // Override ToString method that is in C# as def
        public override string ToString()
        {
            return $"ID: {itemId}, Name: {itemName}, Price: {itemPrice:C}, Quantity: {quantity}";
        }

        public string GetItemName()
        {
            return itemName;
        }

        public double GetItemPrice()
        {
            return itemPrice;
        }
    }

    public class Admin
    {
        private string adminId, adminName, adminPassword;
        private List<Medicine> medicines;

        public Admin(string id, string name, string pass)
        {
            adminId = id;
            adminName = name;
            adminPassword = pass;

            medicines = new List<Medicine>();
            initializeMeds();
        }

        // The method given under will only be called once to populate the list
        private void initializeMeds()
        {
            medicines.Add(new Medicine("med001", "Panadol", 20.00, 50));
            medicines.Add(new Medicine("med002", "Flagyl", 30.00, 20));
        }

        public void AddMedicine(string id, string name, double price, int quantity)
        {
            try
            {
                Medicine newMedicine = new Medicine(id, name, price, quantity);
                medicines.Add(newMedicine);
                Console.WriteLine("Medicine Added Successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            RedirectAfterDelay(10);
        }

        public void RemoveMedicine(string medName)
        {
            try
            {
                // Find the medicine by name
                Medicine medicineToRemove = medicines.Find(m => m.GetItemName().Equals(medName, StringComparison.OrdinalIgnoreCase));

                if (medicineToRemove != null)
                {
                    medicines.Remove(medicineToRemove);
                    Console.WriteLine($"{medName} has been removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Medicine with name '{medName}' not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            RedirectAfterDelay(10);
        }

        // A method to pass the list to any created list 
        public List<Medicine> GetMedicines()
        {
            return medicines;
        }

        public void DisplayMedicines()
        {
            Console.WriteLine("Available Medicines:");
            foreach (var medicine in medicines)
            {
                Console.WriteLine(medicine.ToString());
            }
        }

        private void RedirectAfterDelay(int seconds)
        {
            Console.WriteLine($"You will be redirected in {seconds} seconds...");
            Thread.Sleep(seconds * 1000); // Delay for 10 seconds
            Console.Clear(); // Clear the console before redirecting so that the console does not remain full
        }
    }

    public class User
    {
        private string userId, userName;
        private List<Medicine> purchasedMedicines;
        private List<Medicine> availableMedicinesCopy; // To hold a copy of the available medicines

        public User(string id, string name, List<Medicine> availableMedicines)
        {
            userId = id;
            userName = name;
            purchasedMedicines = new List<Medicine>();
            availableMedicinesCopy = new List<Medicine>(availableMedicines);
        }

        public void PurchaseMedicine(string name)
        {
            try
            {
                Medicine medToPurchase = availableMedicinesCopy.Find(m => m.GetItemName().Equals(name, StringComparison.OrdinalIgnoreCase));
                if (medToPurchase != null)
                {
                    purchasedMedicines.Add(medToPurchase);
                    Console.WriteLine($"Medicine '{name}' purchased successfully!");
                }
                else
                {
                    throw new KeyNotFoundException($"Medicine with the name '{name}' not found.");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            RedirectAfterDelay(10);
        }

        // Method to check out and display purchased medicines 
        public void CheckOut()
        {
            if (purchasedMedicines.Count == 0)
            {
                Console.WriteLine("No medicines have been purchased.");
            }
            else
            {
                Console.WriteLine("Purchased Medicines:");
                foreach (var medicine in purchasedMedicines)
                {
                    Console.WriteLine(medicine.ToString());
                }

                double totalCost = 0;
                foreach (var medicine in purchasedMedicines)
                {
                    totalCost += medicine.GetItemPrice();
                }
                Console.WriteLine($"Total Cost: {totalCost:C}");
            }
            RedirectAfterDelay(10);
        }

        private void RedirectAfterDelay(int seconds)
        {
            Console.WriteLine($"You will be redirected in {seconds} seconds...");
            Thread.Sleep(seconds * 1000); // Delay for specified seconds
            Console.Clear(); // Clear the console before redirecting
        }
    }

    public class Login
    {
        // storing the username and passwords
        private Dictionary<string, string> userCredentials;

        public Login()
        {
            userCredentials = new Dictionary<string, string>();
            InitializeCredentials();
        }

        // Initialize with some default admin credentials
        private void InitializeCredentials()
        {
            userCredentials.Add("admin", "admin123"); // Example admin credentials
            userCredentials.Add("user", "user123");   // Example user credentials
        }

        public bool Authenticate(string username, string password)
        {
            if (userCredentials.TryGetValue(username, out string storedPassword))
            {
                return storedPassword == password;
            }
            return false;
        }
    }

    public class PharmacySystem
    {
        public static void Main(string[] args)
        {
            Login login = new Login();
            Admin admin = new Admin("A000", "Example", "123");
            List<Medicine> availableMedicines = admin.GetMedicines();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*");
            Console.WriteLine("         Pharmacy App            ");
            Console.WriteLine("*");
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("Welcome to the Pharmacy App!");
            Console.WriteLine("Your one-stop solution for managing medicines.");
            Console.WriteLine("\n\n");

            while (true)
            {
                Console.WriteLine("Select Role:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string roleChoice = Console.ReadLine();

                if (roleChoice == "3")
                {
                    break; // Exit the application
                }

                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (login.Authenticate(username, password))
                {
                    if (roleChoice == "1") // Admin role
                    {
                        AdminMenu(admin);
                    }
                    else if (roleChoice == "2") // User role
                    {
                        UserMenu(availableMedicines);
                    }
                    else
                    {
                        Console.WriteLine("Invalid role selection. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
        }

        private static void AdminMenu(Admin admin)
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Medicine");
                Console.WriteLine("2. Remove Medicine");
                Console.WriteLine("3. View Medicines");
                Console.WriteLine("4. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "4") break; // Logout

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Medicine ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter Medicine Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Medicine Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Medicine Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        admin.AddMedicine(id, name, price, quantity);
                        break;
                    case "2":
                        Console.Write("Enter Medicine Name to Remove: ");
                        string medName = Console.ReadLine();
                        admin.RemoveMedicine(medName);
                        break;
                    case "3":
                        admin.DisplayMedicines();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        private static void UserMenu(List<Medicine> availableMedicines)
        {
            User user = new User("U001", "John Doe", availableMedicines); // Example user

            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Purchase Medicine");
                Console.WriteLine("2. Checkout");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "3") break; // Logout

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Medicine Name to Purchase: ");
                        string purchaseName = Console.ReadLine();
                        user.PurchaseMedicine(purchaseName);
                        break;
                    case "2":
                        user.CheckOut();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
    }
}