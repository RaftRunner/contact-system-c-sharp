﻿using System;
using System.Collections.Generic;

class Program
{
    static List<Contact> contacts = new List<Contact>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Contact Management System:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Search Contact by Name");
            Console.WriteLine("4. Delete Contact by Name");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    SearchContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddContact()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Contact newContact = new Contact(name, phoneNumber, email);
        contacts.Add(newContact);
        Console.WriteLine("Contact added.");
    }

    static void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to display.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    static void SearchContact()
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        var foundContacts = contacts.FindAll(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (foundContacts.Count == 0)
        {
            Console.WriteLine("No contacts found with that name.");
        }
        else
        {
            foreach (var contact in foundContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    static void DeleteContact()
    {
        Console.Write("Enter name to delete: ");
        string name = Console.ReadLine();
        var contactToDelete = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (contactToDelete != null)
        {
            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact deleted.");
        }
        else
        {
            Console.WriteLine("No contact found with that name.");
        }
    }
}
