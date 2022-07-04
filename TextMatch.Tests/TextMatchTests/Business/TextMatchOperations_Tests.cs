using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TextMatchTests.Business
{
    /// <summary>
    /// Unit tests to test the logic of the text match operations.
    /// </summary>
    [TestClass]
    public class TextMatchOperations_Tests
    {
        private readonly TextMatchBusiness.TextMatchOperations textMatchOperations = new TextMatchBusiness.TextMatchOperations();
        private readonly string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        /// <summary>
        /// Get text match character positions for subtext, "Polly" with a capital P.
        /// Should return 3 character positions for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_Case1_Success_Test()
        {
            // Arrange
            string subtext = "Polly";
            List<int> expectedResult = new List<int> { 1, 26, 51 };

            // Act
            var response = this.textMatchOperations.GetAllSubstringMatchedPositions(text, subtext);
            List<int> result = (List<int>)response.Result;

            // Assert
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Get text match character positions for subtext, "Polly" with a small case p.
        /// Should return 3 character positions for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_Case2_Success_Test()
        {
            // Arrange
            string subtext = "polly";
            List<int> expectedResult = new List<int> { 1, 26, 51 };

            // Act
            var response = this.textMatchOperations.GetAllSubstringMatchedPositions(text, subtext);
            List<int> result = (List<int>)response.Result;

            // Assert
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Get text match character positions for subtext, "ll".
        /// Should return 5 character positions for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_Case3_Success_Test()
        {
            // Arrange
            string subtext = "ll";
            List<int> expectedResult = new List<int> { 3, 28, 53, 78, 82 };

            // Act
            var response = this.textMatchOperations.GetAllSubstringMatchedPositions(text, subtext);
            List<int> result = (List<int>)response.Result;

            // Assert
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Get text match character positions for subtext, "X".
        /// Should return 0 character positions for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_Case4_Success_Test()
        {
            // Arrange
            string subtext = "X";
            List<int> expectedResult = new List<int>();

            // Act
            var response = this.textMatchOperations.GetAllSubstringMatchedPositions(text, subtext);
            List<int> result = (List<int>)response.Result;

            // Assert
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Get text match character positions for subtext, Polx".
        /// Should return 0 character positions for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_Case5_Success_Test()
        {
            // Arrange
            string subtext = "Polx";
            List<int> expectedResult = new List<int>();

            // Act
            var response = this.textMatchOperations.GetAllSubstringMatchedPositions(text, subtext);
            List<int> result = (List<int>)response.Result;

            // Assert
            Assert.IsNotNull(response);
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}