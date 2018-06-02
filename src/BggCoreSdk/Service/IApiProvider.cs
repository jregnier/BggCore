using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Dto;

namespace BggCoreSdk.Service
{
    /// <summary>
    /// Used to encapsulate the functionality of the given service.
    /// </summary>
    internal interface IApiProvider
    {
        /// <summary>
        /// Builds the URL.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="apiEndPoint">The end point of the API.</param>
        /// <returns></returns>
        Uri BuildUri(ApiEndPoint apiEndPoint, NameValueCollection parameters);

        /// <summary>
        /// Builds the URL to call the web service.
        /// </summary>
        /// <param name="parameterValue">The parameter value to add.</param>
        /// <returns>The URL to make the call with.</returns>
        Uri BuildUri(ApiEndPoint apiEndPoint, string parameterValue);

        /// <summary>
        /// Gets the property name to use in the API call.
        /// </summary>
        /// <param name="propertyName">The name of the property in the class.</param>
        /// <typeparam name="T">The query paramter type.</typeparam>
        /// <returns>The API property name.</returns>
        string GetQueryPropertyName<T>(string propertyName);

        /// <summary>
        /// Makes a web service call to the specified URL.
        /// </summary>
        /// <param name="requestUri">The request URL.</param>
        /// <typeparam name="T">The response type which inherits from <see cref="IBggResponse"/>.</typeparam>
        /// <returns>The response serialized into the response object.</returns>
        Task<T> CallWebServiceGetAsync<T>(Uri requestUri) 
            where T : class, IBggResponse;
    }
}