//Example No.2
// DRY Principle (Don't Repeat Yourself)

/*Imagine you're building a small billing system that calculates the final price of different 
 product types (like Electronics and Books). Each product type includes a different base price,
but the tax calculation is the same — a flat 10% of the base price.*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var books = new Books("C# Programming", 50.00m);
        var electronics = new Electronics("Laptop", 1000.00m);
        var priceCalculator = new PriceCalculator();
        var finalPriceBooks = priceCalculator.CalculateFinalPrice(books.BasePrice);
        var finalPriceElectronics = priceCalculator.CalculateFinalPrice(electronics.BasePrice);

        Console.WriteLine("Product Data is: \n");

        Console.WriteLine($"Final price of {books.Title} is: {finalPriceBooks}");
        Console.WriteLine($"Final price of {electronics.Name} is: {finalPriceElectronics}");
    }

    //Without 'm' the values is considered as double
    // Price calculation class
    public class PriceCalculator
    {
        private const decimal TaxRate = 0.10m; // 10% tax rate
        public decimal CalculateFinalPrice(decimal basePrice)
        {
            return basePrice + (basePrice * TaxRate);
        }
    }

    //Also SRP principle is also being used here
    // Base class for all products
    public class Books 
    {
        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public Books(string title, decimal basePrice)
        {
            Title = title;
            BasePrice = basePrice;
        }
       
    }

    // Electronics class
    public class Electronics
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public Electronics(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
        
    }

}
 