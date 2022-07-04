namespace TextMatchBusiness.Contracts.Business
{
    /// <summary>
    /// Text Match Operations. Class for the business logic of the API.
    /// </summary>
    public interface ITextMatchOperations
    {
        /// <summary>
        /// Get all substring matched positions method. Takes two string parameters as input and outputs a list of
        /// integers representing character positions of the the beginning of each match for the subtext string 
        /// within the main text string.
        /// </summary>
        /// <param name="text">Main string of text.</param>
        /// <param name="subtext">Subtext string to find matches of in text.</param>
        /// <returns>List of integers representing the character positions.</returns>
        Task<List<int>> GetAllSubstringMatchedPositions(string text, string subtext);
    }
}
