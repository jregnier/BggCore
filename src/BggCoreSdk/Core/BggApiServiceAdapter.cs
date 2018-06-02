using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BggCoreSdk.Dto;

namespace BggCoreSdk.Core
{
    internal class BggApiServiceAdapter : IBggApiServiceAdapter
    {
        public async Task<T> WebGetAsync<T>(Uri requestUri)
            where T : class, IBggResponse
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("requestUri");
            }

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(requestUri).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(await response.Content.ReadAsStreamAsync());
                }
            }
        }
    }
}