using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Tests.POM.Base
{
    public class BaseAssertions
    {

        public BaseAssertions()
        {
        }

        public void StringContains(string actualString, string expectedString, string errorMessage)
        {
            Assert.That(actualString.Contains(expectedString), errorMessage);
        }

        public void AreEqual(object? expected, object? actual, string errorMessage)
        {
            ClassicAssert.AreEqual(expected, actual, errorMessage);
        }
    }
}
