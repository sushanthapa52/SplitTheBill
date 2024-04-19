namespace SplitBillLibrary
{
    public class Split
    {
        public decimal SplitAmountPerHead(decimal finalBill, int headCount)
        {
            if (finalBill < 0)
                throw new ArgumentException("Final bill cannot be negative.");

            if (finalBill == 0)
                throw new ArgumentException("Final bill cannot be zero after dining.");

            return finalBill / headCount;
        }


        public Dictionary<string, decimal> CalculateTipWeighted(Dictionary<string, decimal> mealCostsLogic, float tipPercentage)
        {
            if (mealCostsLogic == null)
                throw new ArgumentNullException(nameof(mealCostsLogic), "null meal charge");

            if (mealCostsLogic.Count == 0)
                throw new ArgumentException("mealCostsLogic dictionary must contain at least one entry.", nameof(mealCostsLogic));

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip % should be between 0 and 100.");

            if (mealCostsLogic.Any(x => x.Value < 0))
                throw new ArgumentException("Meal cost cannot be negative.", nameof(mealCostsLogic));

            decimal totalMealCost = mealCostsLogic.Values.Sum();
            decimal tipAmount = totalMealCost * (decimal)(tipPercentage / 100);

            var tipPerPerson = new Dictionary<string, decimal>();
            foreach (var kvp in mealCostsLogic)
            {
                decimal personalTip = kvp.Value / totalMealCost * tipAmount;
                tipPerPerson[kvp.Key] = personalTip;
            }

            return tipPerPerson;
        }

        public decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (price <= 0)
                throw new ArgumentException("Price should be greater than zero.", nameof(price));

            if (numberOfPatrons <= 0)
                throw new ArgumentException("Number of patrons should be greater than 0.", nameof(numberOfPatrons));

            if (tipPercentage < 0 || tipPercentage > 100)
                throw new ArgumentException("Tip % shoud be between 0 and 100.", nameof(tipPercentage));

            decimal totalTip = price * ((decimal)tipPercentage / 100);
            decimal tipPerPerson = totalTip / numberOfPatrons;

            return tipPerPerson;
        }

    }
}
