using Microsoft.AspNetCore.Mvc;
using TextMatchBusiness.Contracts.Business;
using TextMatchBusiness.Contracts.API;

namespace TextMatch.Controllers
{
    /// <inheritdoc/>
    [ApiController]
    [Route("[controller]")]
    public class TextMatchController : ControllerBase, ITextMatchController
    {
        private readonly ITextMatchOperations operations;
        private readonly ILogger<TextMatchController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMatchController"/> class.
        /// </summary>
        /// <param name="operations">ITextMatchOperations.</param>
        /// <param name="logger">Logger.</param>
        public TextMatchController(ITextMatchOperations operations, ILogger<TextMatchController> logger)
        {
            this.operations = operations;
            this.logger = logger;
        }

        /// <inheritdoc/>
        [HttpGet]
        [Route("[action]")]
        public string Get([FromQuery]string text, [FromQuery]string subtext)
        {
            if (text == null || subtext == null)
            {
                this.logger.LogError("Null value passed into TextMatch Get method.");
                return string.Empty;
            }

            List<int> list = this.operations.GetAllSubstringMatchedPositions(text, subtext).Result;
            return string.Join(",", list.Select(i => i).ToArray());
        }
    }
}