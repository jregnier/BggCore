using System;

namespace BggCoreSdk.Service
{
    /// <summary>
    /// Attribute to define the name of the API query property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryPropertyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryPropertyAttribute" /> class.
        /// </summary>
        /// <param name="propertyName">The name of the query property.</param>
        public QueryPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; }
    }
}