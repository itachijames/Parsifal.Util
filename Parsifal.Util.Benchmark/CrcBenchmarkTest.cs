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
        ICrc _crcS = CrcFactory.Get(CrcAlgorithmType.CRC_16_CCITT);
        ICrc _crcG = CrcFactory.Get(CrcStandardParam.CRC_16_CCITT);

        [Params(100, 100_000)]
        public int _length;

        [GlobalSetup]
        public void Setup()
        {
            _testDataBytes = new byte[_length];
            new Random(Guid.NewGuid().GetHashCode()).NextBytes(_testDataBytes);
        }

        [Benchmark]
        public byte[] CalcCrcWithSpecificAlgorithm()
        {
            return _crcS.GetCrc(_testDataBytes);
        }

        [Benchmark]
        public byte[] CalcCrcWithGeneralAlgotithm()
        {
            return _crcG.GetCrc(_testDataBytes);
        }
    }
}
