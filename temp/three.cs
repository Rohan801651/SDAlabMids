using System;

public class Book {
    public string title {get; set;}
    public string author {get; set;}
    public bool availability {get; set;}
    public Book(string title, string author, bool available) {
        this.title = title;
        this.author = author;
        this.availability = availability;
    }
}

public interface INotificationSender {
    public void send(string msg);
}

public class EmailSender : INotificationSender {
    public void send(string msg) {
        Console.WriteLine("Email: "+msg);
    }
}

public class SMSSender : INotificationSender {
    public void send(string msg) {
        Console.WriteLine("SMS: "+msg);
    }
}

public interface IStorage {
    public void store();
}

public class StoreInDB : IStorage {
    public void store() {
        Console.WriteLine("Storing in DB...");
    }
}

public class StoreInFile : IStorage {
    public void store() {
        Console.WriteLine("Storing in File...");
    }
}

public class BookManager {
    
    public void borrowBook(INotificationSender type, Book book) {
        type.send("You have borrowed: "+book.title+" Book !");
    }
    
    // more logic
}

class Program
{
    public static void Main(string[] args)
    {
        Book book1 = new Book("Chemistry", "Rohan", true);
        BookManager manager = new BookManager();
        manager.borrowBook(new EmailSender(), book1);
        
    }
}

/*

Question # 04:
Library Management System (SRP, DIP)

Background:

A library needs a system to manage books and their borrowing process. The system should:

Track book details (e.g., title, author, availability).
Allow borrowing books and notifying users (e.g., via email or SMS).
Store book records (e.g., in a database or file).
Task:

Implement the Single Responsibility Principle (SRP) so each class has only one reason to change (e.g., separate book management, notification, and storage).
Apply the Dependency Inversion Principle (DIP) to ensure high-level modules (e.g., borrowing logic) depend on abstractions, not concrete implementations (e.g., specific notification or storage methods).
Your solution should include at least 4-5 classes/interfaces (e.g., for books, borrowing, notifications, and storage).

*/