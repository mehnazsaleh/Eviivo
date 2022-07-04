using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextMatch.Controllers;
using TextMatchBusiness.Contracts.Business;

namespace TextMatchTests.API
{
    /// <summary>
    /// Unit tests to test the methods within of the text match controller.
    /// </summary>
    [TestClass]
    public class TextMatchController_Tests
    {
        private TextMatchController textMatchController;
        private Mock<ITextMatchOperations> mockTextMatchOperations;
        private ILogger<TextMatchController> logger;
        private readonly string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        /// <summary>
        /// Initialize for all the tests within this class.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.mockTextMatchOperations = new Mock<ITextMatchOperations>();

            // Setting up logger to inject into the contoller.
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            this.logger = factory.CreateLogger<TextMatchController>();
        }

        /// <summary>
        /// Text match get method should return a string containing a comma separated list of integers for given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_SuccessResponse_Test()
        {
            // Arrange
            string subtext = "Polly";
            List<int> response = new List<int> { 1, 26, 51};

            this.mockTextMatchOperations.Setup(s => s.GetAllSubstringMatchedPositions(text, subtext)).Returns(Task.FromResult(response));

            textMatchController = new TextMatchController(this.mockTextMatchOperations.Object, this.logger);

            // Act
            var result = textMatchController.Get(text, subtext);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("1,26,51", result);
        }

        /// <summary>
        /// Text match get method should return an empty string when no matches found in given text.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_NullResponse_Test()
        {
            // Arrange
            string subtext = "X";
            List<int> response = new List<int>();

            this.mockTextMatchOperations.Setup(s => s.GetAllSubstringMatchedPositions(text, subtext)).Returns(Task.FromResult(response));

            textMatchController = new TextMatchController(this.mockTextMatchOperations.Object, this.logger);

            // Act
            var result = textMatchController.Get(text, subtext);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Text match get method should return an empty string when an input parameter is null.
        /// </summary>
        [TestMethod]
        public void GetTextMatch_NullParameter_Test()
        {
            // Arrange
            string subtext = string.Empty;
            List<int> response = new List<int>();

            this.mockTextMatchOperations.Setup(s => s.GetAllSubstringMatchedPositions(text, subtext)).Returns(Task.FromResult(response));

            textMatchController = new TextMatchController(this.mockTextMatchOperations.Object, this.logger);

            // Act
            var result = textMatchController.Get(text, subtext);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }
    }
}