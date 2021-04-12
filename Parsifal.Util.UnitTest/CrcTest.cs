using System;
using Parsifal.Util.CRC;
using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class CrcTest
    {
        [Fact]
        public void AlgorithmTest()
        {
            var testData = new byte[] { 0x41, 0x00, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05 };

            var ccitt = CrcFactory.Get(CrcAlgorithmType.CRC_16_CCITT);
            var ccittValue = ccitt.GetCrc(testData);
            Assert.Equal(new byte[] { 0xd5, 0x09 }, ccittValue);

            var modbus = CrcFactory.Get(CrcAlgorithmType.CRC_16_MODBUS);
            var modbusValue = modbus.GetCrc(testData);
            Assert.Equal(new byte[] { 0x8B, 0x4C }, modbusValue);

            var crc64 = CrcFactory.Get(CrcAlgorithmType.CRC_64);
            var crc64Value = crc64.GetCrc(testData);
            Assert.Equal(8, crc64Value.Length);
        }

        [Theory]
        [InlineData(CrcAlgorithmType.CRC_16_CCITT)]
        [InlineData(CrcAlgorithmType.CRC_16_MODBUS)]
        [InlineData(CrcAlgorithmType.CRC_64)]
        public void AlgorithmCompareWithGeneral(CrcAlgorithmType type)
        {
            var testData = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };
            var crc1 = CrcFactory.Get(type);
            var crc2 = CrcFactory.Get(crc1.Argument);

            var result1 = crc1.GetCrc(testData);
            var result2 = crc2.GetCrc(testData);
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Crc8MaximTest()
        {
            var testData1 = new byte[] { 0xAA, 0x01, 0x02, 0x00, 0x64 };
            var testData2 = new byte[] { 0xAA, 0x02, 0x04, 0x00, 0x64, 0xFF, 0x9C };
            var crc = CrcFactory.Get(CrcAlgorithmType.CRC_8_MAXIM);
            var v1 = crc.GetCrc(testData1);
            Assert.True(v1.Length == 1 && v1[0] == 0x4A);
            var v2 = crc.GetCrc(testData2);
            Assert.True(v2[0] == 0x8A);
        }

        [Fact]
        public void CrcFactoryTest()
        {
            foreach (var item in Enum.GetValues<CrcAlgorithmType>())
            {
                if (item != CrcAlgorithmType.None)
                {
                    var crc = CrcFactory.Get(item);
                    Assert.NotNull(crc);
                }
            }
        }
    }
}
