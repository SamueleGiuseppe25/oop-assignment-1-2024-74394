using RentalCarLibrary.Domain; // Reference to your domain library to use RentalCar class
using Xunit; // Reference to xUnit framework for testing
using System.IO; // Required to test console output

namespace RentalCar.Tests
{
    public class RentalCarTests
    {
        // Note: Explicit namespace usage for RentalCar class to avoid ambiguity

        // 1. Testing the Borrow() method
        [Fact]
        public void Borrow_WhenCarIsNotBorrowed_ShouldSetBorrowedToTrue()
        {
            // Arrange: I create a car that is not yet borrowed
            var car = new RentalCarLibrary.Domain.RentalCar("Toyota", "Corolla", "Sedan", "TOY123", 100.0);

            // Act: I borrow the car
            car.Borrow();

            // Assert: The car should now be marked as borrowed
            Assert.True(car.Borrowed);
        }

        [Fact]
        public void Borrow_WhenCarIsAlreadyBorrowed_ShouldNotChangeBorrowedStatus()
        {
            // Arrange: I create a car and borrow it initially
            var car = new RentalCarLibrary.Domain.RentalCar("Ford", "Mustang", "Convertible", "FOR456", 200.0);
            car.Borrow(); // Borrow it first

            // Capture console output to verify the message
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console output to StringWriter

                // Act: Try to borrow the car again when it's already borrowed
                car.Borrow();

                // Assert: Verify that the appropriate message was printed
                var expectedOutput = "The Rental Car is already on Loan" + Environment.NewLine;
                Assert.Equal(expectedOutput, sw.ToString());
                // Also, verify that the borrowed status remains true
                Assert.True(car.Borrowed);
            }
        }

        // 2. Testing the ReturnRentalCar() method
        [Fact]
        public void ReturnRentalCar_WhenCarIsBorrowed_ShouldSetBorrowedToFalse()
        {
            // Arrange: I create a car and borrow it first
            var car = new RentalCarLibrary.Domain.RentalCar("Honda", "Civic", "Sedan", "HON123", 120.0);
            car.Borrow(); // Borrow the car first

            // Capture console output using StringWriter
            using (var sw = new StringWriter())
            {
                var originalOut = Console.Out; // Save the original Console output

                try
                {
                    Console.SetOut(sw); // Redirect Console output to StringWriter

                    // Act: Return the car
                    car.ReturnRentalCar();

                    // Assert: Verify that the appropriate message was printed
                    var expectedOutput = "The car has been successfully returned." + Environment.NewLine;
                    Assert.Equal(expectedOutput, sw.ToString());
                }
                finally
                {
                    Console.SetOut(originalOut); // Reset Console to the original output
                }
            }

            // Also Assert that Borrowed status is now false
            Assert.False(car.Borrowed);
        }

        [Fact]
        public void ReturnRentalCar_WhenCarIsNotBorrowed_ShouldDoNothing()
        {
            // Arrange: I create a car that hasn't been borrowed
            var car = new RentalCarLibrary.Domain.RentalCar("Tesla", "Model S", "Sedan", "TES789", 300.0);

            // Capture console output to verify the message
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console output to StringWriter

                // Act: Try to return a car that is not borrowed
                car.ReturnRentalCar();

                // Assert: Verify that the appropriate message was printed
                var expectedOutput = "The car was not on loan." + Environment.NewLine;
                Assert.Equal(expectedOutput, sw.ToString());
                // Also, verify that the borrowed status remains false
                Assert.False(car.Borrowed);
            }
        }

        // 3. Testing the ChangePrice(double price) method
        [Fact]
        public void ChangePrice_WithValidPrice_ShouldUpdatePrice()
        {
            // Arrange: I create a car with an initial price
            var car = new RentalCarLibrary.Domain.RentalCar("Ford", "Focus", "Hatchback", "FOR123", 100.0);

            // Act: Change the price to a new valid value
            car.ChangePrice(150.0);

            // Assert: Verify that the price has been updated correctly
            Assert.Equal(150.0, car.Price);
        }

        [Fact]
        public void ChangePrice_WithNegativePrice_ShouldNotUpdatePrice()
        {
            // Arrange: I create a car with an initial price
            var car = new RentalCarLibrary.Domain.RentalCar("Ford", "Focus", "Hatchback", "FOR123", 100.0);

            // Act: Try to change the price to a negative value
            car.ChangePrice(-50.0);

            // Assert: Verify that the price has not been changed
            Assert.Equal(100.0, car.Price); // Price should remain unchanged
        }

        // 4. Testing the CheckPrice() method
        [Fact]
        public void CheckPrice_ShouldReturnCorrectPrice()
        {
            // Arrange: I create a car with a specific price
            var car = new RentalCarLibrary.Domain.RentalCar("Toyota", "Camry", "Sedan", "TOY456", 200.0);

            // Act: Get the price of the car
            var price = car.CheckPrice();

            // Assert: Verify that the returned price is correct
            Assert.Equal(200.0, price);
        }

        // 5. Testing the CheckBorrowed() method
        [Fact]
        public void CheckBorrowed_ShouldReturnCorrectBorrowedStatus()
        {
            // Arrange: I create a car and check its initial borrowed status
            var car = new RentalCarLibrary.Domain.RentalCar("Nissan", "Altima", "Sedan", "NIS123", 150.0);

            // Act & Assert: Verify that initially the car is not borrowed
            Assert.False(car.CheckBorrowed()); // Should be false initially

            // Act: Borrow the car
            car.Borrow();

            // Assert: Verify that the car is now marked as borrowed
            Assert.True(car.CheckBorrowed()); // Should be true after borrowing
        }

        // 6. Testing the Display() method
        [Fact]
        public void Display_ShouldPrintCorrectDetails()
        {
            // Arrange: I create a car with specific details
            var car = new RentalCarLibrary.Domain.RentalCar("Mazda", "CX-5", "SUV", "MAZ123", 180.0);

            // Capture console output to verify the display information
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // Redirect Console output to StringWriter

                // Act: Display the car information
                car.DisplayInfo();

                // Assert: Verify that the output matches the expected details
                var expectedOutput =
                    "*********************************" + Environment.NewLine +
                    "Manufacturer: Mazda" + Environment.NewLine +
                    "Model: CX-5" + Environment.NewLine +
                    "Body Type: SUV" + Environment.NewLine +
                    "Registration Number: MAZ123" + Environment.NewLine +
                    "Price: 180" + Environment.NewLine +
                    "Borrowed: No" + Environment.NewLine +
                    "*********************************" + Environment.NewLine +
                    Environment.NewLine;

                Assert.Equal(expectedOutput, sw.ToString());
            }
        }
    }
}
