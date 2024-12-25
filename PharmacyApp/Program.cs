using System;
using System.Collections.Generic;

namespace PharmacyApp
{
    // For each core aspect of the application, we will create a class having functions 
    // These functions would provide the core functionality -
    // and manipulate the data structures that contain the instances of a class

    class Medicine
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

        // Override ToString method
        public override string ToString()
        {
            return $"ID: {itemId}, Name: {itemName}, Price: {itemPrice:C}, Quantity: {quantity}";
        }

        public string GetItemName()
        {
            return itemName; // Assuming itemName is a private field
        }

        public double GetItemPrice()
        {
            return itemPrice; // Allow access to the item price
        }
    }

    class Admin
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
            Medicine panadol = new Medicine("med001", "Panadol", 20.00, 50);
            Medicine flagyl = new Medicine("med002", "Flagyl", 30.00, 20);

            medicines.Add(panadol);
            medicines.Add(flagyl);
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
                Console.WriteLine(e.Message);
            }
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
                Console.WriteLine(e.Message);
            }
        }

        // A method to pass the list to any created list 
        public List<Medicine> GetMedicines()
        {
            return medicines;
        }
    }

    class User
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
        }
    }

    class PharmacySystem
    {
        public static void Main(string[] args)
        {
            Admin admin = new Admin("A000", "Example", "123");
            List<Medicine> availableMedicines = admin.GetMedicines();

            Console.WriteLine("List of Medicines:");
            foreach (var medicine in availableMedicines)
            {
                Console.WriteLine(medicine.ToString());
            }

            User user = new User("U001", "John Doe", availableMedicines);
            user.PurchaseMedicine("Panadol");
            user.CheckOut();

            Console.ReadKey();
        }
    }
}