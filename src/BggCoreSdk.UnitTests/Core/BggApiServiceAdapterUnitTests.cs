using System;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Dto;
using Xunit;

namespace BggCoreSdk.UnitTests.Core
{
    public class BggApiServiceAdapterUnitTests
    {
        [Fact]
        public async Task WebGetAsync_Exception_Thrown()
        {
            // arrange
            var service = new BggApiServiceAdapter();

            // act, assert
            await Assert.ThrowsAsync<ArgumentNullException>(
                "requestUri",
                async () => await service.WebGetAsync<BoardGameSearchListDto>(null));
        }
    }
}