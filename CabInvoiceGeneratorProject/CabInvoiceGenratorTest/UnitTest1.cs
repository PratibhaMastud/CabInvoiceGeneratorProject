using CabInvoiceGeneratorProject;
using NUnit.Framework;

namespace CabInvoiceGenratorTest
{
    public class UnitTest1
    {
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        [Test]
        public void GivenDistanceAndTime_WhenCalculate_ShouldReturnTotalFare()
        {
            //Here We creating Instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Here Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, fare);
        }
    }
}