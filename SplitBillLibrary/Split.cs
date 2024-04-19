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


        public Dictionary<string, decimal> TipCalculate(Dictionary<string, decimal> totalCost, float percent)
        {

            if (totalCost == null)
                throw new ArgumentNullException(nameof(totalCost), "Total cost dictionary cannot be null.");

            if (percent < 0)
                throw new ArgumentException("Tip percentage cannot be negative.");

            Dictionary<string, decimal> PerPersonTip = new Dictionary<string, decimal>();

            foreach (var pair in totalCost)
            {
                decimal tipAmount = 0;

                // Check if the meal cost is less than 40
                if (pair.Value >= 40)
                {
                    tipAmount = pair.Value * (decimal)(percent / 100);
                }

                PerPersonTip.Add(pair.Key, tipAmount);
            }

            return PerPersonTip;
        }


        
    }
}
