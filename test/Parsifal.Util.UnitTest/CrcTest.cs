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

            var ccitt = CrcFactory.GetCrc(CrcAlgorithmType.CRC_16_CCITT);
            var ccittValue = ccitt.GetCrcValue(testData);
            Assert.Equal((ulong)0x09d5, ccittValue);

            var modbus = CrcFactory.GetCrc(CrcAlgorithmType.CRC_16_MODBUS);
            var modbusValue = modbus.GetCrcBytes(testData);
            Assert.Equal(new byte[] { 0x8B, 0x4C }, modbusValue);

            var crc64 = CrcFactory.GetCrc(CrcAlgorithmType.CRC_64);
            var crc64Value = crc64.GetCrcBytes(testData);
            Assert.Equal(8, crc64Value.Length);
        }

        [Theory]
        [InlineData(CrcAlgorithmType.CRC_5_USB)]
        [InlineData(CrcAlgorithmType.CRC_8_MAXIM)]
        [InlineData(CrcAlgorithmType.CRC_16_CCITT)]
        [InlineData(CrcAlgorithmType.CRC_16_MODBUS)]
        [InlineData(CrcAlgorithmType.CRC_32)]
        public void AlgorithmCompareWithGeneral(CrcAlgorithmType type)
        {
            var testData = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };
            var crc1 = CrcFactory.GetCrc(type);
            var crc2 = CrcFactory.GetCrc(crc1.Argument);

            var result1 = crc1.GetCrcValue(testData);
            var result2 = crc2.GetCrcValue(testData);
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Crc8MaximTest()
        {
            var testData1 = new byte[] { 0xAA, 0x01, 0x02, 0x00, 0x64 };
            var testData2 = new byte[] { 0xAA, 0x02, 0x04, 0x00, 0x64, 0xFF, 0x9C };
            var crc = CrcFactory.GetCrc(CrcAlgorithmType.CRC_8_MAXIM);
            var v1 = crc.GetCrcBytes(testData1);
            Assert.True(v1.Length == 1 && v1[0] == 0x4A);
            var v2 = crc.GetCrcBytes(testData2);
            Assert.True(v2[0] == 0x8A);
        }

        [Fact]
        public void CrcImplementTest()
        {
            var testData = new byte[128];
            new Random(Guid.NewGuid().GetHashCode()).NextBytes(testData);
            foreach (var item in Enum.GetValues<CrcAlgorithmType>())
            {
                if (item != CrcAlgorithmType.None)
                {
                    var crcS = CrcFactory.GetCrc(item);
                    Assert.NotNull(crcS);
                    var sv = crcS.GetCrcValue(testData);
                    var sb = crcS.GetCrcBytes(testData);
                    var ss = crcS.Append(sv, testData);

                    var crcG = CrcFactory.GetCrc(crcS.Argument);
                    var gv = crcG.GetCrcValue(testData);
                    var gb = crcG.GetCrcBytes(testData);
                    var gs = crcG.Append(gv, testData);

                    Assert.Equal(sv, gv);
                    Assert.Equal(sb, gb);

                }
            }
        }
    }
}
