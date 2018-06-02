using BggCoreSdk.Core;

namespace BggCoreSdk.UnitTests.Core
{
    internal class EnumerationTestObject : Enumeration
    {
        public static EnumerationTestObject Option1 = new EnumerationTestObject(0, "option1");
        public static EnumerationTestObject Option2 = new EnumerationTestObject(1, "option2");
        public static EnumerationTestObject Option3 = new EnumerationTestObject(2, "option3");

        public EnumerationTestObject()
        {

        }

        public EnumerationTestObject(int value, string name)
            : base(value, name)
        {
        }
    }
}