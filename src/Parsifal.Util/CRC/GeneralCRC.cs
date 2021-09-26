using System;

namespace Parsifal.Util.CRC
{
    /// <summary>
    /// 通用CRC
    /// </summary>
    public class GeneralCRC : CrcBase
    {
        #region field
        private readonly CrcArgument _crcArg;
        private readonly ulong[] _crcTable;
        private readonly int _rightShift;
        private readonly ulong _initValue;
        #endregion

        #region ctor
        public GeneralCRC(CrcArgument argument)
        {
            _crcArg = argument ?? throw new ArgumentNullException(nameof(argument));
            //查表法
            _crcTable = CreateTable(_crcArg.Width, _crcArg.Polynomial, _crcArg.ReflectIn);
            _rightShift = _crcArg.Width - (_crcArg.Width < 8 ? 1 : 8);
            _initValue = _crcArg.ReflectIn ? ReverseBits(_crcArg.InitValue, _crcArg.Width) : _crcArg.InitValue;
        }
        #endregion

        #region private
        public override CrcArgument Argument => _crcArg;
        protected override ulong CalculateCrc(byte[] data, int offset, int length, ulong initial = 0)
        {
            ulong result = initial == 0 ? _initValue : initial;
            while (length-- > 0)
            {
                byte current = data[offset++];
                if (_crcArg.Width < 8)
                {
                    //对每位进行处理
                    for (int bit = 0; bit < 8; bit++)
                    {
                        if (_crcArg.ReflectIn)
                        {
                            result = (result >> 1) ^ _crcTable[(byte)(result & 1) ^ ((byte)(current >> bit) & 1)];
                        }
                        else
                        {
                            result = (result << 1) ^ _crcTable[(byte)((result >> _rightShift) & 1) ^ ((byte)(current >> (7 - bit)) & 1)];
                        }
                    }
                }
                else
                {
                    if (_crcArg.ReflectIn)
                    {
                        result = (result >> 8) ^ _crcTable[(byte)result ^ current];
                    }
                    else
                    {
                        result = (result << 8) ^ _crcTable[(byte)(result >> _rightShift) ^ current];
                    }
                }
            }
            if (_crcArg.ReflectIn ^ _crcArg.ReflectOut)
            {
                result = ReverseBits(result, _crcArg.Width);
            }
            result ^= _crcArg.XorValue;
            return result;
        }
        private ulong[] CreateTable(int width, ulong poly, bool refIn)
        {
            int perBitCount = width < 8 ? 1 : 8;
            var crcTable = new ulong[1 << perBitCount];
            ulong mostSignificantBit = 1ul << (width - 1);
            var mask = ulong.MaxValue >> (64 - _crcArg.Width);
            for (uint i = 0; i < crcTable.Length; ++i)
            {
                ulong current = i;
                if (perBitCount > 1 && refIn)
                    current = ReverseBits(current, perBitCount);
                current <<= (width - perBitCount);

                for (int j = 0; j < perBitCount; ++j)
                {
                    if ((current & mostSignificantBit) > 0ul)
                        current = (current << 1) ^ poly;
                    else
                        current <<= 1;
                }

                if (refIn)
                    current = ReverseBits(current, width);
                current &= mask;
                crcTable[i] = current;
            }
            return crcTable;
        }
        private static ulong ReverseBits(ulong value, int length)
        {
            ulong newValue = 0ul;
            for (int i = length - 1; i >= 0; i--)
            {
                newValue |= (value & 1) << i;
                value >>= 1;
            }
            return newValue;
        }
        #endregion

        #region 直算
        //private byte[] CalcInWidth8(byte[] data, int offset, int length)
        //{
        //    throw new NotImplementedException();
        //}
        //private byte[] CalcInWidth16(byte[] data, int offset, int length)
        //{
        //    ushort crc = (ushort)_crcArg.InitValue;
        //    bool shift = _crcArg.RefIn;
        //    ushort temp = shift ? (ushort)ReverseBits((ushort)_crcArg.Poly, 16) : (ushort)_crcArg.Poly;
        //    while (length-- > 0)
        //    {
        //        byte current = data[offset++];
        //        if (shift)
        //        {
        //            crc ^= current;
        //            for (int i = 0; i < 8; i++)
        //            {
        //                if ((crc & 0x0001) > 0)
        //                {
        //                    crc = (ushort)((crc >> 1) ^ temp);
        //                }
        //                else
        //                {
        //                    crc >>= 1;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            crc ^= (ushort)(current << 8);
        //            for (int i = 0; i < 8; i++)
        //            {
        //                if ((crc & 0x8000) > 0)
        //                {
        //                    crc = (ushort)((crc << 1) ^ temp);
        //                }
        //                else
        //                {
        //                    crc <<= 1;
        //                }
        //            }
        //        }
        //    }
        //    return BitConverter.GetBytes((ushort)(crc ^ _crcArg.XorValue));
        //}
        //private byte[] CalcInWidth32(byte[] data, int offset, int length)
        //{
        //    //uint crc = (uint)_crcArg.InitValue;
        //    //bool shift = _crcArg.RefIn;
        //    //uint temp = shift ? (uint)ReverseBits(_crcArg.Poly, 32) : (uint)_crcArg.Poly;
        //    //return BitConverter.GetBytes(crc ^ _crcArg.XorValue);
        //    throw new NotImplementedException();
        //}
        //private byte[] CalcInWidth64(byte[] data, int offset, int length)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

    }
}
