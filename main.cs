using System;

class SupportTicket
{
    private static int nextId = 1001;

    public string TicketId { get; }          // read-only: set once, in the constructor
    public string CustomerName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "Open";

    public SupportTicket()
    {
        TicketId = "T" + nextId;
        nextId++;
    }

    public virtual void GetDetails()
    {
        Console.Write("Enter customer name: ");
        CustomerName = Console.ReadLine();
        Console.Write("Enter issue description: ");
        Description = Console.ReadLine();
    }

    public virtual void DisplaySummary()
    {
        Console.WriteLine("\n=== Ticket Summary ===");
        Console.WriteLine($"Ticket ID: {TicketId}");
        Console.WriteLine($"Customer: {CustomerName}");
    }
}

class HardwareTicket : SupportTicket
{
    public string Device { get; set; }

    public override void GetDetails()
    {
        base.GetDetails();
        Console.Write("Enter device: ");
        Device = Console.ReadLine();
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine("Issue type: Hardware");
        Console.WriteLine($"Device: {Device}");
        Console.WriteLine($"Status: {Status}");
    }
}

class SoftwareTicket : SupportTicket
{
    public string SoftwareName { get; set; }

    public override void GetDetails()
    {
        base.GetDetails();
        Console.Write("Enter software name: ");
        SoftwareName = Console.ReadLine();
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine("Issue type: Software");
        Console.WriteLine($"Software: {SoftwareName}");
        Console.WriteLine($"Status: {Status}");
    }
}

class NetworkTicket : SupportTicket
{
    public string NetworkIssue { get; set; }

    public override void GetDetails()
    {
        base.GetDetails();
        Console.Write("Enter network issue: ");
        NetworkIssue = Console.ReadLine();
    }

    public override void DisplaySummary()
    {
        base.DisplaySummary();
        Console.WriteLine("Issue type: Network");
        Console.WriteLine($"Network issue: {NetworkIssue}");
        Console.WriteLine($"Status: {Status}");
    }
}

class MainProgram
{
    static void Main()
    {
        Console.WriteLine("=== IT Help Desk ===");
        Console.WriteLine("Choose issue type:");
        Console.WriteLine("1. Hardware");
        Console.WriteLine("2. Software");
        Console.WriteLine("3. Network");

        Console.Write("Enter choice: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid choice. Please enter a number.");
            return;
        }

        SupportTicket ticket;

        switch (choice)
        {
            case 1: ticket = new HardwareTicket(); break;
            case 2: ticket = new SoftwareTicket(); break;
            case 3: ticket = new NetworkTicket(); break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                return;
        }

        ticket.GetDetails();
        ticket.DisplaySummary();
    }
}