using System;
using Xunit;

namespace ReferenceIntegration.UnitTest
{
    public class CoverageUnitTests
    {
        [Fact]
        public void FindCoverageUnitTests()
        {
            var finder = new CoverageRepository();

            Coverage coverage1 = finder.Find("1");
            Coverage coverage2 = finder.Find("2");
            Coverage coverage3 = finder.Find("3");

            Assert.True(coverage1 != null);
            Assert.True(coverage1.Id == "1");

            Assert.True(coverage2 != null);
            Assert.True(coverage2.Id == "2");

            Assert.True(coverage3 != null);
            Assert.True(coverage3.Id == "3");
        }
    }
}
