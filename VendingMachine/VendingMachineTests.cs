using NUnit.Framework;

namespace VendingMachine
{
    public class VendingMachineTests
    {
        [TestCase(0.60, 0, 1, 2, "Change is 0 nickel(s), 1 dime(s), 2 quarter(s).")]
        [TestCase(0.75, 0, 0, 3, "Change is 0 nickel(s), 0 dime(s), 3 quarter(s).")]
        [TestCase(0.30, 0, 3, 0, "Change is 0 nickel(s), 3 dime(s), 0 quarter(s).")]
        [TestCase(0.65, 13, 0, 0, "Change is 13 nickel(s), 0 dime(s), 0 quarter(s).")]
        [TestCase(0.00, 0, 0, 0, "Unable to give change.")]
        [TestCase(0.05, 0, 0, 0, "Unable to give change.", Description = "5 cents owed but no change available.")]
        public void GiveChange_ProvidedInventory_ReturnsExpected(decimal amountOwed, int nickels, int dimes, int quarters, string expected)
        {
            // Arrange
            var vendingMachine = new VendingMachine(nickels, dimes, quarters);

            // Act
            string result = vendingMachine.GiveChange(amountOwed);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
