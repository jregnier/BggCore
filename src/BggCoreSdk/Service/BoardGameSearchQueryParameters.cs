namespace BggCoreSdk.Service
{
    public class BoardGameSearchQueryParameters
    {
        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        [QueryProperty("search")]
        public string Search { get; set; }

        /// <summary>
        /// Gets a value indicating whether the search string should be exact
        /// </summary>
        [QueryProperty("exact")]
        public bool IsExact { get; set; }
    }
}