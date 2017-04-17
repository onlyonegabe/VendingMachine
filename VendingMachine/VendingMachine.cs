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
            int quartersToGiveCustomer = CalculateQuartersInChangeToGiveCustomer(amountOwed);
            int dimesToGiveCustomer = CalculateDimesInChangeToGiveCustomer(amountOwed);
            int nickelsToGiveCustomer = CalculateNickelsInChangeToGiveCustomer(amountOwed);

            if (nickelsToGiveCustomer > 0 || dimesToGiveCustomer > 0 || quartersToGiveCustomer > 0)
            {
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesToGiveCustomer} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
        }

        private int CalculateQuartersInChangeToGiveCustomer(decimal amountOwed)
        {
            int quartersToGiveCustomer = 0;
            const decimal quarterValue = .25M;
            int quartersNeeded = GetCoinsNeededToMakeChange(amountOwed, quarterValue);
            if (AreThereEnoughCoins(quarters, quartersNeeded))
            {
                quartersToGiveCustomer = quartersNeeded;
            }
            return quartersToGiveCustomer;
        }

        private int CalculateDimesInChangeToGiveCustomer(decimal amountOwed)
        {
            int dimesToGiveCustomer = 0;
            const decimal dimeValue = .10M;
            int dimesNeeded = GetCoinsNeededToMakeChange(amountOwed, dimeValue);
            if (AreThereEnoughCoins(dimes, dimesNeeded))
            {
                dimesToGiveCustomer = dimesNeeded;
            }
            return dimesToGiveCustomer;
        }

        private int CalculateNickelsInChangeToGiveCustomer(decimal amountOwed)
        {
            int nickelsToGiveCustomer = 0;
            const decimal nickelValue = .05M;
            int nickelsNeeded = GetCoinsNeededToMakeChange(amountOwed, nickelValue);
            if (AreThereEnoughCoins(nickels, nickelsNeeded))
            {
                nickelsToGiveCustomer = nickelsNeeded;
            }
            return nickelsToGiveCustomer;
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