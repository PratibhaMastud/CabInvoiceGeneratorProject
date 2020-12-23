using System;

namespace CabInvoiceGeneratorProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 3);
            Console.WriteLine($"Fare: {fare}");
        }
    }
}
