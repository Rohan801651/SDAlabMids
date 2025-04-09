using System;

// ocp and liskov

public class Users
{
    public string name { get; set; }
    public Users(string name)
    {
        this.name = name;
    }

}

public interface IEvents
{
    public void rigester(Users user);
}

public class PublicEvent : IEvents
{
    public void rigester(Users user)
    {
        Console.WriteLine(user.name+" is in public event");
    }
}

public class TicketedEvent : IEvents
{
    Users user{ get; set; }
    int fees { get; set; }
    public TicketedEvent(Users user, int fees)
    {
        this.user = user;
        this.fees = fees;
    }
    public void rigester(Users user)
    {
        Console.WriteLine(user.name + " has paid the fees :" + fees);
    }
}

public class MemberOnlyEvents : IEvents
{
    public void rigester(Users user)
    {
        // logic
    }
}
// --------- ocp ↑

public class EventManager  // liskov
{
    public void eventRegister(Users user, IEvents events) {
        events.rigester(user);
    }
    
}


class Program
{
    public static void Main(string[] args)
    {
        Users user = new Users("Rohan");
        Users user2 = new Users("Ali");
        EventManager manager = new EventManager();
        manager.eventRegister(user, new TicketedEvent(user,500));

        manager.eventRegister(user2, new PublicEvent());
        
    }
}

/*
Question:
Event Registration System (OCP, LSP)

Background:

A community center wants an Event Registration System to manage participant registrations. The system should:

Allow participants to register for events.
Support different types of events:
Public events (open to everyone, no cost).
Ticketed events (require purchasing a ticket to register).
Ensure that participants can register for any event type without modifying existing code.
Task:

Implement the Open/Closed Principle (OCP) so new event types (e.g., Member-Only Events) can be added without modifying existing code.
Ensure your design follows the Liskov Substitution Principle (LSP) so all event types can be used interchangeably.
Your solution should include at least 3-4 classes/interfaces (e.g., for events, participants, and registration management).

*/