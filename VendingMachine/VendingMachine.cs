namespace VendingMachine
{
    public class VendingMachine
    {
        private const decimal QuarterValue = .25M;
        private const decimal DimeValue = .10M;
        private const decimal NickelValue = .05M;

        private int nickelsInInventory;
        private int dimesInInventory;
        private int quartersInInventory;
        private decimal amountOwed;

        public VendingMachine(int nickelsInInventory, int dimesInInventory, int quartersInInventory)
        {
            this.nickelsInInventory = nickelsInInventory;
            this.dimesInInventory = dimesInInventory;
            this.quartersInInventory = quartersInInventory;
        }

        public string GiveChange(decimal amount)
        {
            if (amount == 0.00M)
            {
                return "No need to give change.";
            }
            amountOwed = amount;
            int quartersToGiveCustomer = CalculateCoinsToGiveCustomer(QuarterValue, quartersInInventory);
            int dimesToGiveCustomer = CalculateCoinsToGiveCustomer(DimeValue, dimesInInventory);
            int nickelsToGiveCustomer = CalculateCoinsToGiveCustomer(NickelValue, nickelsInInventory);
            if (amountOwed == 0.00M)
            {
                UpdateInventory(nickelsToGiveCustomer, dimesToGiveCustomer, quartersToGiveCustomer);
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesToGiveCustomer} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
        }

        private void UpdateInventory(int nickelsToGiveCustomer, int dimesToGiveCustomer, int quartersToGiveCustomer)
        {
            nickelsInInventory -= nickelsToGiveCustomer;
            dimesInInventory -= dimesToGiveCustomer;
            quartersInInventory -= quartersToGiveCustomer;
        }

        // This is doing two things
        private int CalculateCoinsToGiveCustomer(decimal coinValue, int coinsInInventory)
        {
            int coinsNeededToMakeChange = GetCoinsNeededToMakeChange(coinValue);
            if (AreThereEnoughCoinsInInventory(coinsInInventory, coinsNeededToMakeChange))
            {
                amountOwed -= coinsNeededToMakeChange * coinValue;
                return coinsNeededToMakeChange;
            }
            if (AreThereAnyCoinsInInventory(coinsInInventory))
            {
                amountOwed -= coinsInInventory * coinValue;
                return coinsInInventory;
            }
            return 0;
        }

        private static bool AreThereAnyCoinsInInventory(int coinsInInventory)
        {
            return coinsInInventory > 0;
        }

        private bool AreThereEnoughCoinsInInventory(int coinsInInventory, int coinsNeeded)
        {
            return coinsInInventory >= coinsNeeded;
        }

        private int GetCoinsNeededToMakeChange(decimal coinAmountToDivideBy)
        {
            return (int) (amountOwed / coinAmountToDivideBy);
        }
    }
}