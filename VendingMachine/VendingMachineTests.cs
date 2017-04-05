using NUnit.Framework;

namespace VendingMachine
{
    public class VendingMachineTests
    {
        [TestCase(0.00, 0, 0, 0, "Unable to give change.")]
        [TestCase(0.05, 1, 0, 0, "Change is 1 Nickel(s), 0 Dime(s), 0 quarter(s).")]
        [TestCase(0.05, 0, 0, 0, "Unable to give change.", Description = "5 cents owed but no change available.")]
        [TestCase(0.10, 0, 1, 0, "Change is 0 Nickel(s), 1 Dime(s), 0 quarter(s).")]
        [TestCase(0.10, 2, 0, 0, "Change is 2 Nickel(s), 0 Dime(s), 0 quarter(s).")]
        [TestCase(0.15, 3, 0, 0, "Change is 3 Nickel(s), 0 Dime(s), 0 quarter(s).")]
        [TestCase(0.15, 1, 2, 0, "Change is 1 Nickel(s), 1 Dime(s), 0 quarter(s).")]
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
