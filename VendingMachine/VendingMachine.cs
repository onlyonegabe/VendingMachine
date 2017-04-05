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
            int nickelsProvided = 0;
            int dimesProvided = 0;

            if (amountOwed >= .15M)
            {
                if (dimes > 1)
                {
                    dimesProvided = 1;
                    nickelsProvided = 1;
                }
                else
                {
                    nickelsProvided = 3;
                }
            }

            if (amountOwed >= .10M)
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

            if (amountOwed == .05M)
            {
                if (nickels == 1)
                {
                    nickelsProvided = 1;
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