using NUnit.Framework;
using PostalCodes.PCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalCodes.Test
{
    [TestFixture]
    public class PostalCodeServiceTests
    {
        [Test]
        public async void PostalCodeService_LocationQuery_IsNotNull()
        {
            //Arrange
            PostalCodeService service = new PostalCodeService();
            string countryCode = "CA";
            string stateCode = "ON";
            string city = "Waterloo";

            //Act
            var result = await service.LocationQueryAsync(countryCode, stateCode, city);

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
