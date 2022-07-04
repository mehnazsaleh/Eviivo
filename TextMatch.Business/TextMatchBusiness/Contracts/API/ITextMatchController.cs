namespace TextMatchBusiness.Contracts.API
{
    /// <summary>
    /// Controller class for the Text Match Web API.
    /// </summary>
    public interface ITextMatchController
    {
        /// <summary>
        /// Takes two string parameters as input and outputs a list of character positions of the
        /// beginning of each match for the subtext string within the text string.
        /// </summary>
        /// <param name="text">Main string of text.</param>
        /// <param name="subtext">Subtext string to find matches of in text.</param>
        /// <returns>String containing a comma separated list of character positions.</returns>
        string? Get(string text, string subtext);
    }
}
