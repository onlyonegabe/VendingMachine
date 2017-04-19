namespace VendingMachine
{
    public class VendingMachine
    {
        private const decimal QuarterValue = .25M;
        private const decimal DimeValue = .10M;
        private const decimal NickelValue = .05M;

        private readonly int nickelsInInventory;
        private readonly int dimesInInventory;
        private readonly int quartersInInventory;

        private decimal amountOwed;

        public VendingMachine(int nickelsInInventory, int dimesInInventory, int quartersInInventory)
        {
            this.nickelsInInventory = nickelsInInventory;
            this.dimesInInventory = dimesInInventory;
            this.quartersInInventory = quartersInInventory;
        }

        public string GiveChange(decimal amount)
        {
            amountOwed = amount;
            int quartersToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(QuarterValue, quartersInInventory);
            int dimesToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(DimeValue, dimesInInventory);
            int nickelsToGiveCustomer = CalculateCoinsInChangeToGiveCustomer(NickelValue, nickelsInInventory);

            if (amountOwed == 0.00M)
            {
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesToGiveCustomer} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
        }

        private int CalculateCoinsInChangeToGiveCustomer(decimal coinValue, int coinsInInventory)
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