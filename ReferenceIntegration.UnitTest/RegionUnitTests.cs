using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReferenceIntegration.UnitTest
{
    public class RegionUnitTests
    {
        [Fact]
        public void FindRegionUnitTests()
        {
            var finder = new RegionRepository();
                             
            Region region1 = finder.Find("1");
            Region region2 = finder.Find("2");
            Region region3 = finder.Find("3");

            Assert.True(region1 != null);
            Assert.True(region1.Code == "1");

            Assert.True(region2 != null);
            Assert.True(region2.Code == "2");

            Assert.True(region3 != null);
            Assert.True(region3.Code == "3");
        }
    }
}
