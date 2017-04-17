namespace VendingMachine
{
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
            int nickelsToGiveCustomer = 0;
            int dimesProvided = 0;
            int quartersToGiveCustomer = 0;

            const decimal quarterValue = .25M;
            int quartersNeeded = GetCoinsNeededToMakeChange(amountOwed, quarterValue);
            if (AreThereEnoughCoins(quarters, quartersNeeded))
            {
                quartersToGiveCustomer = quartersNeeded;
            }
            const decimal nickelValue = .05M;
            int nickelsNeeded = GetCoinsNeededToMakeChange(amountOwed, nickelValue);
            if (AreThereEnoughCoins(nickels, nickelsNeeded))
            {
                nickelsToGiveCustomer = nickelsNeeded;
            }
            
            if (nickelsToGiveCustomer > 0 || dimesProvided > 0 || quartersToGiveCustomer > 0)
            {
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesProvided} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
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