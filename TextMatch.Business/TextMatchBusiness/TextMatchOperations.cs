using TextMatchBusiness.Contracts.Business;

namespace TextMatchBusiness
{
    /// <inheritdoc/>
    public class TextMatchOperations : ITextMatchOperations
    {
        /// <inheritdoc/>
        public Task<List<int>> GetAllSubstringMatchedPositions(string text, string subtext)
        {
            List<int> matches = new List<int>();
            bool matched = false;

            text = text.ToLower();
            subtext = subtext.ToLower();

            for (int x = 0; x < text.Length; x++)
            {
                if (text[x] == subtext[0])
                {
                    for (int y = 0; y < subtext.Length; y++)
                    {
                        if ((x + y < text.Length) && text[x + y] == subtext[y])
                        {
                            matched = true;
                        }
                        else
                        {
                            matched = false;
                            break;
                        }
                    }

                    if (matched)
                    {
                        matches.Add(x + 1);
                    }

                    matched = false;
                }
            }

            return Task.FromResult<List<int>>(matches);
        }
    }
}