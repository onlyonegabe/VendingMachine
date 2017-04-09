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
            int nickelsInChange = 0;
            int dimesInChange = 0;

            dimesInChange = MakeChangeForCoinType(amountOwed, DimeValue);
            nickelsInChange = MakeChangeForCoinType(amountOwed, NickelValue);

            if (nickelsInChange > 0 || dimesInChange > 0)
            {
                return
                    $"Change is {nickelsInChange} nickel(s), {dimesInChange} dime(s), 0 quarter(s).";
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
                    coinsProvided = coinsNeeded;
                }
            }
            if (coinValue == NickelValue)
            {
                if (nickels >= coinsNeeded)
                {
                    coinsProvided = coinsNeeded;
                }
            }

            return coinsProvided;
        }
    }
}