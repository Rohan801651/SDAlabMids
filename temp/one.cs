//Example of LSP Principle (Liskov Substitution Principle)
/*Imagine you're building a payroll system where employees can be:

1. Full-time employees

2. Contract-based employees

3. Interns

You create a base class called Employee, and each type should be able to calculate its salary*/

using System;
using System.Collections.Generic;
using System.Security.Policy;

class Program
{
    static void Main(string[] args)
    {
        IEmployee fullTimeEmployee = new FullTimeEmployee("Hadi", 50000);
        IEmployee contractEmployee = new ContractEmployee("Ali", 20, 40);
        IEmployee unpaidIntern = new UnpaidIntern("Ahmed");
        IEmployee paidIntern = new Intern("Rohan", 1000);

        PayrollSystem payrollSystem = new PayrollSystem();
        Console.WriteLine("Employee Data is: \n");
        // Process payroll for different types of employees

        payrollSystem.ProcessPayroll(fullTimeEmployee);
        payrollSystem.ProcessPayroll(contractEmployee);
        payrollSystem.ProcessPayroll(unpaidIntern);
        payrollSystem.ProcessPayroll(paidIntern);
        // You can add more employee types without modifying existing code


    }

    public interface IEmployee
    {
        string Name { get; set; } // Name of the employee
        decimal CalculateSalary(); // Method to calculate salary
    }

    // Full-time employee class
    public class FullTimeEmployee : IEmployee
    {
        public string Name { get; set; } // Name of the employee
        public decimal MonthlySalary { get; set; } // Salary of the employee
        public FullTimeEmployee(string name, decimal monthlySalary)
        {
            Name = name;
            MonthlySalary = monthlySalary;
        }

        public decimal CalculateSalary()
        {
            return MonthlySalary; // Full-time employees get a fixed monthly salary
        }
    }

    // Contract-based employee class
    public class ContractEmployee : IEmployee 
    {
        public string Name { get; set; } // Name of the Employee
        public decimal HourlyRate { get; set; } // Hourly rate of the employee
        public int HoursWorked { get; set; } // Hours worked by the employee

        public ContractEmployee(string name, decimal hourlyRate, int hoursWorked)
        {
            Name = name;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked; // Contract-based employees get paid based on hours worked
        }
    }

    // Intern class
    public class UnpaidIntern : IEmployee
    {
        public string Name { get; set; } // Name of the employee

        public UnpaidIntern(string name)
        {
            Name = name;
        }

        public decimal CalculateSalary()
        {
            return 0; // Unpaid interns do not receive a salary
        }
    }

    public class Intern : IEmployee
    {
        public string Name { get; set; } // Name of the employee
        public decimal Stipend { get; set; } // Stipend of the intern

        public Intern(string name, decimal stipend)
        {
            Name = name;
            Stipend = stipend;
        }

        public decimal CalculateSalary()
        {
            return Stipend; // Interns get a fixed stipend
        }
    }

    class PayrollSystem
    {
        public void ProcessPayroll(IEmployee employee)
        {
            Console.WriteLine($"{employee.Name} will be paid : {employee.CalculateSalary()}");  
        }
    }
}