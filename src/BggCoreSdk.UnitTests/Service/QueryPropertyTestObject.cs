using BggCoreSdk.Service;

namespace BggCoreSdk.UnitTests.Service
{
    public class QueryPropertyTestObject
    {
        public string Property1 { get; set; }

        [QueryProperty("queryproperty2")]
        public string Property2 { get; set; }
    }
}