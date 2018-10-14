using System;

namespace BggCoreSdk.Service
{
    public class BoardGameQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to show users' comments on games.
        /// </summary>
        [QueryProperty("comments")]
        public bool Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include game statistics.
        /// </summary>
        [QueryProperty("stats")]
        public bool Stats { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include historical game statistics. Use the
        /// From and To date parameters in combination with this.
        /// </summary>
        [QueryProperty("historical")]
        public bool Historical { get; set; }

        /// <summary>
        /// Gets or sets the from date. This only applies in combination with the Historical parameter.
        /// </summary>
        [QueryProperty("from")]
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the to date. This only applies in combination with the Historical parameter.
        /// </summary>
        [QueryProperty("to")]
        public DateTime To { get; set; }
    }
}