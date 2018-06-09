using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BggCoreSdk.Core;
using BggCoreSdk.Dto;

namespace BggCoreSdk.Service
{
    /// < inheritdoc />
    internal class ApiProvider : IApiProvider
    {
        private const string BASE_URL = "http://www.boardgamegeek.com/xmlapi";

        private readonly IBggApiServiceAdapter _serviceAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiProvider" /> class.
        /// </summary>
        /// <param name="serviceAdapter">The service adapter used to make web calls.</param>
        public ApiProvider(
            IBggApiServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        /// < inheritdoc />
        public Uri BuildUri(ApiEndPoint apiEndPoint, NameValueCollection parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            var builder = new UriBuilder(new Uri(new Uri(BASE_URL), apiEndPoint.Name));
            var query = HttpUtility.ParseQueryString(builder.Query);
            query.Add(parameters);
            builder.Query = query.ToString();

            return builder.Uri;
        }

        /// < inheritdoc />
        public Uri BuildUri(ApiEndPoint apiEndPoint, string parameterValue)
        {
            if (string.IsNullOrWhiteSpace(parameterValue))
            {
                throw new ArgumentNullException("parameterValue");
            }

            return new Uri(
                new Uri(BASE_URL), string.Join("/", apiEndPoint.Name, parameterValue));
        }

        /// < inheritdoc />
        public string GetQueryPropertyName<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var property = typeof(T).GetProperty(propertyName);

            if (property == null)
            {
                return null;
            }

            var attribute = property
                .GetCustomAttributes(true)
                .SingleOrDefault(x => x is QueryPropertyAttribute) as QueryPropertyAttribute;

            return attribute?.PropertyName;
        }

        /// < inheritdoc />
        public async Task<T> CallWebServiceGetAsync<T>(Uri requestUri)
            where T : class, IBggResponse
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }

            return await _serviceAdapter.WebGetAsync<T>(requestUri).ConfigureAwait(false);
        }
    }
}