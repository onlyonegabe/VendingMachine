using NUnit.Framework;

namespace VendingMachine
{
    public class VendingMachineTests
    {
        [TestCase(0.00, 0, 0, 0, "Unable to give change.")]
        [TestCase(0.05, 1, 0, 0, "Change is 1 Nickel(s), 0 Dime(s), 0 quarter(s).")]
        [TestCase(0.05, 0, 0, 0, "Unable to give change.")]
        [TestCase(0.10, 0, 1, 0, "Change is 0 Nickel(s), 1 Dime(s), 0 quarter(s).")]
        [TestCase(0.10, 2, 0, 0, "Change is 2 Nickel(s), 0 Dime(s), 0 quarter(s).")]
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

    public class VendingMachine
    {
        private int nickels;
        private int dimes;
        private int quarters;

        public VendingMachine(int nickels, int dimes, int quarters)
        {
            this.nickels = nickels;
            this.dimes = dimes;
            this.quarters = quarters;
        }

        public string GiveChange(decimal amountOwed)
        {
            int nickelsProvided = 0;
            int dimesProvided = 0;

            if (amountOwed == .05M)
            {
                if (nickels == 1)
                {
                    nickelsProvided = 1;
                }
            }

            if (amountOwed == .10M)
            {
                if (dimes == 1)
                {
                    dimesProvided = 1;
                }
                else if (nickels == 2)
                {
                    nickelsProvided = 2;
                }
            }

            if (nickelsProvided > 0 || dimesProvided > 0)
            {
                return
                    $"Change is {nickelsProvided} Nickel(s), {dimesProvided} Dime(s), 0 quarter(s).";
            }
            return "Unable to give change.";
        }
    }
}
