using SplitBillLibrary;

namespace SplitBillTest
{
    [TestClass]
    public class SplitTest
    {
        [TestMethod]
        public void SplitAmountPerHead_ReturnsCorrectAmount()
        {
            // Arrange
            var splitClass = new Split();
            decimal finalBill = 100;
            int headCount = 5;

            // Act
            decimal result = splitClass.SplitAmountPerHead(finalBill, headCount);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void SplitAmountPerHead_FinalBillZero_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal finalBill = 0; // Final bill cannot be zero or negative
            int headCount = 5;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.SplitAmountPerHead(finalBill, headCount));
        }
        [TestMethod]
        public void SplitAmountPerHead_FinalBillLessthanZero_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal finalBill = -500; // Final bill cannot be zero or negative
            int headCount = 5;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.SplitAmountPerHead(finalBill, headCount));
        }

        [TestMethod]
        public void SplitAmountPerHead_HeadCountZero_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal finalBill = 100;
            int headCount = 0;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.SplitAmountPerHead(finalBill, headCount));
        }
    }

    [TestClass]
    public class TipCalculatorTests
    {
        // Test case to ensure that the method returns correct tip amounts for each person
        [TestMethod]
        public void TipCalculate_ReturnsCorrectTipAmounts()
        {
            // Arrange
            var tipCalculator = new Split();
            var totalCost = new Dictionary<string, decimal>
            {
                { "Simran", 50 },
                { "Uma", 75 },
                { "Aanand", 100 }
            };
            float percent = 15;

            // Act
            var result = tipCalculator.TipCalculate(totalCost, percent);

            // Assert
            Assert.AreEqual(7.5m, result["Simran"]); // Simran should pay 7.5 as tip (15% of 50)
            Assert.AreEqual(11.25m, result["Uma"]); // Uma should pay 11.25 as tip (15% of 75)
            Assert.AreEqual(15m, result["Aanand"]); // Aanand should pay 15 as tip (15% of 100)
        }
        [TestMethod]
        public void TipCalculate_ReturnsZeroTipForLessThan40()
        {
            // Arrange
            var splitter = new Split();
            var totalCost = new Dictionary<string, decimal>
            {
                { "Simran", 30 },   // Simran's meal cost is less than 40
                { "Uma", 75 },     // Uma's meal cost is 75
                { "Aanand", 1000 } // Aanand's meal cost is 1000
            };
            float percent = 15;

            // Act
            var result = splitter.TipCalculate(totalCost, percent);

            // Assert
            Assert.AreEqual(0m, result["Simran"]); // Simran should pay 0 as tip for meal cost less than 40
            Assert.AreEqual(11.25m, result["Uma"]); // Uma should pay 11.25 as tip (15% of 75)
        }

        // Test case to ensure that the method throws an ArgumentNullException when the total cost dictionary is null
        [TestMethod]
        public void TipCalculate_TotalCostNull_ThrowsArgumentNullException()
        {
            // Arrange
            var tipCalculator = new Split();
            Dictionary<string, decimal> totalCost = null;
            float percent = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => tipCalculator.TipCalculate(totalCost, percent));
        }

        // Test case to ensure that the method throws an ArgumentException when the percentage is negative
        [TestMethod]
        public void TipCalculate_NegativePercentage_ThrowsArgumentException()
        {
            // Arrange
            var tipCalculator = new Split();
            var totalCost = new Dictionary<string, decimal>
            {
                { "Simran", 50 },
                { "Uma", 75 },
                { "Aanand", 100 }
            };
            float percent = -15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => tipCalculator.TipCalculate(totalCost, percent));
        }
    }
}