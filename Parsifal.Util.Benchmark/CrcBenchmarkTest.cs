using System;
using BenchmarkDotNet.Attributes;
using Parsifal.Util.CRC;

namespace Parsifal.Util.Benchmark
{
    /// <summary>
    /// CRC算法基准测试
    /// </summary>
    [MemoryDiagnoser]
    public class CrcBenchmarkTest
    {
        byte[] _testDataBytes;
        ICrc _crcS;
        ICrc _crcG;

        [Params(1000, 1_000_000)]
        public int length;
        [Params(CrcAlgorithmType.CRC_16_CCITT, CrcAlgorithmType.CRC_32)]
        public CrcAlgorithmType type;

        [GlobalSetup]
        public void Setup()
        {
            _crcS = CrcFactory.GetCrc(type);
            _crcG = CrcFactory.GetCrc(_crcS.Argument);
            _testDataBytes = new byte[length];
            new Random(Guid.NewGuid().GetHashCode()).NextBytes(_testDataBytes);
        }

        [Benchmark]
        public ulong CalcCrcWithSpecificAlgorithm()
        {
            return _crcS.GetCrcValue(_testDataBytes);
        }

        [Benchmark]
        public ulong CalcCrcWithGeneralAlgotithm()
        {
            return _crcG.GetCrcValue(_testDataBytes);
        }
    }
}
