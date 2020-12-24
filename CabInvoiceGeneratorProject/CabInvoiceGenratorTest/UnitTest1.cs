using CabInvoiceGeneratorProject;
using NUnit.Framework;

namespace CabInvoiceGenratorTest
{
    public class UnitTest1
    {
        InvoiceGenerator invoiceGenerator = null;
        RideRepository rideRepository;
        ///<summary>
        /// Test case for UC-1 Given the distance and time when invoice generator then should return total fare.
        ///</summary>
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

        /// <summary>
        /// Test case for UC-2 Given multiple rides for invoice generator then should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenInvoiceGenerator_thenShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test case for UC-3 Given the multiple rides invoice generator that should return following invoice summary.
        /// </summary>
        [Test]
        public void GivenInvoiceGenerator_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            //Creating Instance of InviceGenerator For Normal Ride.
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary For Rides
            InvoiceSummary enhancedSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);

            //Asserting Values
            Assert.AreEqual(expectedSummary, enhancedSummary);
        }

        /// <summary>
        /// Test case for UC 4 Givens the multiple rides when user identifier then should return following invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_WhenUserId_thenShouldReturnFollowingInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            string userId = "Dhiraj";
            rideRepository.AddRide(userId, rides);
            Ride[] rideData = rideRepository.GetRides(userId);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rideData);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        /// <summary>
        /// Test Case UC-5 to Calculate Fare for Primium Ride type
        /// </summary>
        [Test]
        public void GivenRides_WhenPremiumAndNormal_ShouldSupportBoth()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 20;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 85;

            //Asserting Values
            Assert.AreEqual(expected, fare);
        }

    }
}