using System;
using System.Collections.Generic;

namespace PharmacyApp
{
    // For each core aspect of the application we will create a class having functions 
    // These functions would provide the core functionality -
    // and manipulate the datastructures that contain the instances of a class

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

        public void addMedicine(string id, string name, double price, int quantity)
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

        // A method to pass the list to any created list 
        public List<Medicine> getMedicines()
        {
            return medicines;
        }
    }

    class PharmacySystem
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Entry Point");
            //Console.ReadKey();

            Admin admin = new Admin("A000", "Example", "123");

            List<Medicine> eg = admin.getMedicines();

            Console.WriteLine("List of Medicines:");
            foreach (var medicine in eg)
            {
                Console.WriteLine(medicine.ToString()); // Calls the ToString method
            }
            Console.ReadKey();
        }
    }
}