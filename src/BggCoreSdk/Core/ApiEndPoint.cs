using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BggCoreSdk.Core
{
    public sealed class ApiEndPoint : Enumeration
    {
        public static ApiEndPoint Search { get; } = new ApiEndPoint(0, "search");
        public static ApiEndPoint BoardGame { get; } = new ApiEndPoint(1, "boardgame");
        public static ApiEndPoint Collection { get; } = new ApiEndPoint(2, "collection");
        public static ApiEndPoint Thread { get; } = new ApiEndPoint(3, "thread");
        public static ApiEndPoint GeekList { get; } = new ApiEndPoint(4, "geeklist");

        private ApiEndPoint(int value, string name)
            : base(value, name)
        {
        }

        public static IEnumerable<ApiEndPoint> List()
        {
            return new[] { Search, BoardGame, Collection, Thread, GeekList };
        }
    }
}