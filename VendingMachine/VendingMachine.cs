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

        public VendingMachine(int nickelsInInventory, int dimesInInventory, int quartersInInventory)
        {
            this.nickelsInInventory = nickelsInInventory;
            this.dimesInInventory = dimesInInventory;
            this.quartersInInventory = quartersInInventory;
        }

        public string GiveChange(decimal amountOwed)
        {
            int quartersToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(amountOwed, QuarterValue, quartersInInventory);
            int dimesToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(amountOwed, DimeValue, dimesInInventory);
            int nickelsToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(amountOwed, NickelValue, nickelsInInventory);

            if (nickelsToGiveCustomer > 0 || dimesToGiveCustomer > 0 || quartersToGiveCustomer > 0)
            {
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesToGiveCustomer} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
        }

        private int CalculateCoinsInChangeToGiveCustomer(decimal amountOwed, decimal coinValue, int coins)
        {
            int coinsToGiveCustomer = 0;
            int coinsNeeded = GetCoinsNeededToMakeChange(amountOwed, coinValue);
            if (AreThereEnoughCoins(coins, coinsNeeded))
            {
                coinsToGiveCustomer = coinsNeeded;
            }
            return coinsToGiveCustomer;
        }

        private bool AreThereEnoughCoins(int coinsInInventory, int coinsNeeded)
        {
            return coinsInInventory >= coinsNeeded;
        }

        private static int GetCoinsNeededToMakeChange(decimal amountOwed, decimal coinAmountToDivideBy)
        {
            return (int) (amountOwed / coinAmountToDivideBy);
        }
    }
}