namespace VendingMachine
{
    public class VendingMachine
    {
        private int nickels;
        private int dimes;
        private const decimal NickelValue = .05M;
        private const decimal DimeValue = .10M;

        public VendingMachine(int nickels, int dimes, int quarters)
        {
            this.nickels = nickels;
            this.dimes = dimes;
        }

        public string GiveChange(decimal amountOwed)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
            int nickelsInChange = 0;
            int dimesInChange = 0;

            dimesInChange = MakeChangeForCoinType(amountOwed, DimeValue);
            nickelsInChange = MakeChangeForCoinType(amountOwed, NickelValue);

            if (nickelsInChange > 0 || dimesInChange > 0)
            {
                return
                    $"Change is {nickelsInChange} nickel(s), {dimesInChange} dime(s), 0 quarter(s).";
=======
>>>>>>> d19c36643fd4b323e1dbab08c9d458ad6c6c5091
            int nickelsToGiveCustomer = 0;
            int dimesProvided = 0;
            int quartersToGiveCustomer = 0;

            const decimal quarterValue = .25M;
            int quartersNeeded = GetCoinsNeededToMakeChange(amountOwed, quarterValue);
            if (AreThereEnoughCoins(quarters, quartersNeeded))
            {
                quartersToGiveCustomer = quartersNeeded;
<<<<<<< HEAD
            }
            const decimal nickelValue = .05M;
            int nickelsNeeded = GetCoinsNeededToMakeChange(amountOwed, nickelValue);
            if (AreThereEnoughCoins(nickels, nickelsNeeded))
            {
                nickelsToGiveCustomer = nickelsNeeded;
=======
>>>>>>> d19c36643fd4b323e1dbab08c9d458ad6c6c5091
            }
            const decimal nickelValue = .05M;
            int nickelsNeeded = GetCoinsNeededToMakeChange(amountOwed, nickelValue);
            if (AreThereEnoughCoins(nickels, nickelsNeeded))
            {
                nickelsToGiveCustomer = nickelsNeeded;
>>>>>>> Gives change in quarters.  Some refactoring.
            }
            return "Unable to give change.";
        }

        private int MakeChangeForCoinType(decimal amountOwed, decimal coinValue)
        {
            int coinsNeeded = (int)(amountOwed / coinValue);
            int coinsProvided = 0;

            if (coinValue == DimeValue)
            {
                if (dimes >= coinsNeeded)
                {
<<<<<<< HEAD
                    coinsProvided = coinsNeeded;
=======
                    if (dimes > 1)
                    {
                        dimesProvided = 1;
                        nickelsToGiveCustomer = 1;
                    }
>>>>>>> Gives change in quarters.  Some refactoring.
                }
            }
            if (coinValue == NickelValue)
            {
                if (nickels >= coinsNeeded)
                {
                    coinsProvided = coinsNeeded;
                }
            }

<<<<<<< HEAD
=======
<<<<<<< HEAD
            return coinsProvided;
=======
>>>>>>> d19c36643fd4b323e1dbab08c9d458ad6c6c5091
            if (nickelsToGiveCustomer > 0 || dimesProvided > 0 || quartersToGiveCustomer > 0)
            {
                return
                    $"Change is {nickelsToGiveCustomer} nickel(s), {dimesProvided} dime(s), {quartersToGiveCustomer} quarter(s).";
            }
            return "Unable to give change.";
>>>>>>> Gives change in quarters.  Some refactoring.
        }

        private bool AreThereEnoughCoins(int coinsInInventory, int coinsNeeded)
        {
            return coinsInInventory >= coinsNeeded;
        }

        private bool AreThereEnoughNickels(int nickelsNeeded)
        {
            return nickels >= nickelsNeeded;
        }

        private static int GetCoinsNeededToMakeChange(decimal amountOwed, decimal coinAmountToDivideBy)
        {
            return (int) (amountOwed / coinAmountToDivideBy);
        }

        private bool AreThereEnoughCoins(int coinsInInventory, int coinsNeeded)
        {
            return coinsInInventory >= coinsNeeded;
        }

        private bool AreThereEnoughNickels(int nickelsNeeded)
        {
            return nickels >= nickelsNeeded;
        }

        private static int GetCoinsNeededToMakeChange(decimal amountOwed, decimal coinAmountToDivideBy)
        {
            return (int) (amountOwed / coinAmountToDivideBy);
        }
    }
}