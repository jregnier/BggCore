using System;
using System.Threading.Tasks;
using BggCoreSdk.Dto;

namespace BggCoreSdk.Core
{
    internal interface IBggApiServiceAdapter
    {
        Task<T> WebGetAsync<T>(Uri requestUri)
           where T : class, IBggResponse;
    }
}