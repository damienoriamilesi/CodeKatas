using Katas.IpValidator;
using Xunit;

namespace Katas.Tests
{
    public class IpValidatorTest1
    {
        private IpAddress ipAddress;

        public IpValidatorTest1()
        {
            ipAddress = new IpAddress();
        }

        [Theory]
        [InlineData("1.1.1.1")]
        [InlineData("192.168.1.1")]
        [InlineData("10.0.0.1")]
        [InlineData("127.0.0.1")]
        public void ShouldSucceedOnIpValidation(string ipToValidate)
        {
            var isValid = ipAddress.ValidateIpv4Address(ipToValidate);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("0.0.0.0")]
        [InlineData("255.255.255.255")]
        [InlineData("1.1.1.0")]
        [InlineData("10.0.1")]
        public void ShouldFailOnIpValidation(string ipToValidate)
        {
            var isValid = ipAddress.ValidateIpv4Address(ipToValidate);
            Assert.False(isValid);
        }
    }
}
