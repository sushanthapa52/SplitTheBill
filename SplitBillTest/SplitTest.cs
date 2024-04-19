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


        // Test case to ensure that the method throws an ArgumentNullException when the total cost dictionary is null
        [TestMethod]
        public void TipCalculate_TotalCostNull_ThrowsArgumentNullException()
        {
            // Arrange
            var tipCalculator = new Split();
            Dictionary<string, decimal> totalCost = null;
            float percent = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => tipCalculator.CalculateTipWeighted(totalCost, percent));
        }

        [TestMethod]
        public void CalculateTipWeighted_CalculatesTipAmountsCorrectly()
        {
            // Arrange
            var splitClass = new Split();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Simran", 30 },
                { "Uma", 50 },
                { "Aanand", 70 }
            };
            float tipPercentage = 15;

            // Act
            var result = splitClass.CalculateTipWeighted(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(1.6875m, result["Simran"]); // Simran's tip should be 1.6875
            Assert.AreEqual(2.8125m, result["Uma"]); // Uma's tip should be 2.8125
            Assert.AreEqual(3.9375m, result["Aanand"]); // Aanand's tip should be 3.9375
        }

        [TestMethod]
        public void CalculateTipWeighted_NullMealCosts_ThrowsArgumentNullException()
        {
            // Arrange
            var splitClass = new Split();
            Dictionary<string, decimal> mealCosts = null;
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => splitClass.CalculateTipWeighted(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipWeighted_EmptyMealCosts_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            var mealCosts = new Dictionary<string, decimal>();
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipWeighted(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipWeighted_NegativeMealCost_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Simran", 30 },
                { "Uma", -50 }, // Negative meal cost
                { "Aanand", 70 }
            };
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipWeighted(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipWeighted_NegativeTipPercentage_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Simran", 30 },
                { "Uma", 50 },
                { "Aanand", 70 }
            };
            float tipPercentage = -15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipWeighted(mealCosts, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipWeighted_TipPercentageGreaterThan100_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Simran", 30 },
                { "Uma", 50 },
                { "Aanand", 70 }
            };
            float tipPercentage = 150;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipWeighted(mealCosts, tipPercentage));
        }



        [TestMethod]
        public void CalculateTipPerPerson_CorrectlyCalculatesTip()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = 100;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act
            decimal result = splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3m, result);
        }

        [TestMethod]
        public void CalculateTipPerPerson_PriceZero_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = 0;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_NegativePrice_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = -100;
            int numberOfPatrons = 5;
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_NumberOfPatronsZero_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = 100;
            int numberOfPatrons = 0;
            float tipPercentage = 15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_NegativeTipPercentage_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = 100;
            int numberOfPatrons = 5;
            float tipPercentage = -15;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

        [TestMethod]
        public void CalculateTipPerPerson_TipPercentageGreaterThan100_ThrowsArgumentException()
        {
            // Arrange
            var splitClass = new Split();
            decimal price = 100;
            int numberOfPatrons = 5;
            float tipPercentage = 150;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => splitClass.CalculateTipPerPerson(price, numberOfPatrons, tipPercentage));
        }

    }
}