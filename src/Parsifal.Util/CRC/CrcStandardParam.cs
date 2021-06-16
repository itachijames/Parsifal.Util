namespace Parsifal.Util.CRC
{
    /// <summary>
    /// CRC标准参数
    /// </summary>
    public static class CrcStandardParam
    {//Each item name must match with CrcAlgorithmType. 各项名称需与CrcAlgorithmType匹配
        public static readonly CrcArgument CRC_3_GSM = new CrcArgument(3, 0x3, 0x00, false, false, 0x07);
        public static readonly CrcArgument CRC_3_ROHC = new CrcArgument(3, 0x3, 0x7, true, true, 0x0);

        public static readonly CrcArgument CRC_4_INTERLAKEN = new CrcArgument(4, 0x03, 0xF, false, false, 0xF);
        public static readonly CrcArgument CRC_4_ITU = new CrcArgument(4, 0x03, 0x00, true, true, 0x00);

        public static readonly CrcArgument CRC_5_EPC = new CrcArgument(5, 0x09, 0x09, false, false, 0x00);
        public static readonly CrcArgument CRC_5_ITU = new CrcArgument(5, 0x15, 0x00, true, true, 0x00);
        public static readonly CrcArgument CRC_5_USB = new CrcArgument(5, 0x05, 0x1F, true, true, 0x1F);

        public static readonly CrcArgument CRC_6_CDMA2000_A = new CrcArgument(6, 0x27, 0x3F, false, false, 0x00);
        public static readonly CrcArgument CRC_6_CDMA2000_B = new CrcArgument(6, 0x07, 0x3F, false, false, 0x00);
        public static readonly CrcArgument CRC_6_DARC = new CrcArgument(6, 0x19, 0x00, true, true, 0x00);
        public static readonly CrcArgument CRC_6_GSM = new CrcArgument(6, 0x2F, 0x00, false, false, 0x3F);
        public static readonly CrcArgument CRC_6_ITU = new CrcArgument(6, 0x03, 0x00, true, true, 0x00);

        public static readonly CrcArgument CRC_7 = new CrcArgument(7, 0x09, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_7_ROHC = new CrcArgument(7, 0x4F, 0x7F, true, true, 0x00);
        public static readonly CrcArgument CRC_7_UMTS = new CrcArgument(7, 0x45, 0x00, false, false, 0x00);

        public static readonly CrcArgument CRC_8 = new CrcArgument(8, 0x07, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_8_AES = new CrcArgument(8, 0x1D, 0xFF, true, true, 0x00);
        public static readonly CrcArgument CRC_8_AUTOSAR = new CrcArgument(8, 0x2F, 0xFF, false, false, 0xFF);
        public static readonly CrcArgument CRC_8_BLUETOOTH = new CrcArgument(8, 0xA7, 0x00, true, true, 0x00);
        public static readonly CrcArgument CRC_8_CDMA2000 = new CrcArgument(8, 0x9B, 0xFF, false, false, 0x00);
        public static readonly CrcArgument CRC_8_DARC = new CrcArgument(8, 0x39, 0x00, true, true, 0x00);
        public static readonly CrcArgument CRC_8_DVB_S2 = new CrcArgument(8, 0xD5, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_8_GSM_A = new CrcArgument(8, 0x1D, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_8_GSM_B = new CrcArgument(8, 0x49, 0x00, false, false, 0xFF);
        public static readonly CrcArgument CRC_8_I_CODE = new CrcArgument(8, 0x1D, 0xFD, false, false, 0x00);
        public static readonly CrcArgument CRC_8_ITU = new CrcArgument(8, 0x07, 0x00, false, false, 0x55);
        public static readonly CrcArgument CRC_8_LTE = new CrcArgument(8, 0x9B, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_8_MAXIM = new CrcArgument(8, 0x31, 0x00, true, true, 0x00);
        public static readonly CrcArgument CRC_8_MIFARE_MAD = new CrcArgument(8, 0x1D, 0xC7, false, false, 0x00);
        public static readonly CrcArgument CRC_8_NRSC5 = new CrcArgument(8, 0x31, 0xFF, false, false, 0x00);
        public static readonly CrcArgument CRC_8_OPENSAFETY = new CrcArgument(8, 0x2F, 0x00, false, false, 0x00);
        public static readonly CrcArgument CRC_8_ROHC = new CrcArgument(8, 0x07, 0xFF, true, true, 0x00);
        public static readonly CrcArgument CRC_8_SAE_J1850 = new CrcArgument(8, 0x1D, 0xFF, false, false, 0xFF);
        public static readonly CrcArgument CRC_8_WCDMA = new CrcArgument(8, 0x9B, 0x00, true, true, 0x00);

        public static readonly CrcArgument CRC_10 = new CrcArgument(10, 0x233, 0x000, false, false, 0x000);
        public static readonly CrcArgument CRC_10_CDMA2000 = new CrcArgument(10, 0x3D9, 0x3FF, false, false, 0x000);
        public static readonly CrcArgument CRC_10_GSM = new CrcArgument(10, 0x175, 0x000, false, false, 0x3FF);

        public static readonly CrcArgument CRC_11 = new CrcArgument(11, 0x385, 0x01A, false, false, 0x000);
        public static readonly CrcArgument CRC_11_UMTS = new CrcArgument(11, 0x307, 0x000, false, false, 0x000);

        public static readonly CrcArgument CRC_12_CDMA2000 = new CrcArgument(12, 0xF13, 0xFFF, false, false, 0x000);
        public static readonly CrcArgument CRC_12_DECT = new CrcArgument(12, 0x80F, 0x000, false, false, 0x000);
        public static readonly CrcArgument CRC_12_GSM = new CrcArgument(12, 0xD31, 0x000, false, false, 0xFFF);
        public static readonly CrcArgument CRC_12_UMTS = new CrcArgument(12, 0x80F, 0x000, false, true, 0x000);

        public static readonly CrcArgument CRC_13_BBC = new CrcArgument(13, 0x1CF5, 0x0000, false, false, 0x0000);

        public static readonly CrcArgument CRC_14_DARC = new CrcArgument(14, 0x0805, 0x0000, true, true, 0x0000);
        public static readonly CrcArgument CRC_14_ELORAN = new CrcArgument(14, 0x60B1, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_14_GSM = new CrcArgument(14, 0x202D, 0x0000, false, false, 0x3FFF);

        public static readonly CrcArgument CRC_15 = new CrcArgument(15, 0x4599, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_15_MPT1327 = new CrcArgument(15, 0x6815, 0x0000, false, false, 0x0001);

        public static readonly CrcArgument CRC_16 = new CrcArgument(16, 0x8005, 0x0000, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_AUG_CCITT = new CrcArgument(16, 0x1021, 0x1D0F, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_CCITT = new CrcArgument(16, 0x1021, 0x0000, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_CCITT_FALSE = new CrcArgument(16, 0x1021, 0xFFFF, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_CDMA2000 = new CrcArgument(16, 0xC867, 0xFFFF, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_CMS = new CrcArgument(16, 0x8005, 0xFFFF, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_DARC = new CrcArgument(16, 0x1021, 0xFFFF, false, false, 0xFFFF);
        public static readonly CrcArgument CRC_16_DDS_110 = new CrcArgument(16, 0x8005, 0x800D, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_DECT_R = new CrcArgument(16, 0x0589, 0x0000, false, false, 0x0001);
        public static readonly CrcArgument CRC_16_DECT_X = new CrcArgument(16, 0x0589, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_DNP = new CrcArgument(16, 0x3D65, 0x0000, true, true, 0xFFFF);
        public static readonly CrcArgument CRC_16_EN_13757 = new CrcArgument(16, 0x3D65, 0x0000, false, false, 0xFFFF);
        public static readonly CrcArgument CRC_16_GSM = new CrcArgument(16, 0x1021, 0x0000, false, false, 0xFFFF);
        public static readonly CrcArgument CRC_16_ISO_IEC_14443_3_A = new CrcArgument(16, 0x1021, 0xC6C6, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_LJ1200 = new CrcArgument(16, 0x6F63, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_MAXIM = new CrcArgument(16, 0x8005, 0x0000, true, true, 0xFFFF);
        public static readonly CrcArgument CRC_16_MCRF4XX = new CrcArgument(16, 0x1021, 0xFFFF, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_MODBUS = new CrcArgument(16, 0x8005, 0xFFFF, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_NRSC_5 = new CrcArgument(16, 0x080B, 0xFFFF, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_OPENSAFETY_A = new CrcArgument(16, 0x5935, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_OPENSAFETY_B = new CrcArgument(16, 0x755b, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_PROFIBUS = new CrcArgument(16, 0x1DCF, 0xFFFF, false, false, 0xFFFF);
        public static readonly CrcArgument CRC_16_RIELLO = new CrcArgument(16, 0x1021, 0xB2AA, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_T10_DIF = new CrcArgument(16, 0x8BB7, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_TELEDISK = new CrcArgument(16, 0xA097, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_TMS37157 = new CrcArgument(16, 0x1021, 0x89EC, true, true, 0x0000);
        public static readonly CrcArgument CRC_16_UMTS = new CrcArgument(16, 0x8005, 0x0000, false, false, 0x0000);
        public static readonly CrcArgument CRC_16_USB = new CrcArgument(16, 0x8005, 0xFFFF, true, true, 0xFFFF);
        public static readonly CrcArgument CRC_16_X25 = new CrcArgument(16, 0x1021, 0xFFFF, true, true, 0xFFFF);
        public static readonly CrcArgument CRC_16_XMODEM = new CrcArgument(16, 0x1021, 0x0000, false, false, 0x0000);

        public static readonly CrcArgument CRC_17_CAN_FD = new CrcArgument(17, 0x1685B, 0x00000, false, false, 0x0000);

        public static readonly CrcArgument CRC_21_CAN_FD = new CrcArgument(21, 0x102899, 0x000000, false, false, 0x000000);

        public static readonly CrcArgument CRC_24 = new CrcArgument(24, 0x864CFB, 0xB704CE, false, false, 0x000000);
        public static readonly CrcArgument CRC_24_BLE = new CrcArgument(24, 0x00065B, 0x555555, true, true, 0x000000);
        public static readonly CrcArgument CRC_24_FLEXRAY_A = new CrcArgument(24, 0x5D6DCB, 0xFEDCBA, false, false, 0x000000);
        public static readonly CrcArgument CRC_24_FLEXRAY_B = new CrcArgument(24, 0x5D6DCB, 0xABCDEF, false, false, 0x000000);
        public static readonly CrcArgument CRC_24_INTERLAKEN = new CrcArgument(24, 0x328B63, 0xFFFFFF, false, false, 0xFFFFFF);
        public static readonly CrcArgument CRC_24_LTE_A = new CrcArgument(24, 0x864CFB, 0x000000, false, false, 0x000000);
        public static readonly CrcArgument CRC_24_LTE_B = new CrcArgument(24, 0x800063, 0x000000, false, false, 0x000000);
        public static readonly CrcArgument CRC_24_OS9 = new CrcArgument(24, 0x800063, 0xFFFFFF, false, false, 0xFF0000);

        public static readonly CrcArgument CRC_30_CDMA = new CrcArgument(30, 0x2030B9C7, 0x3FFFFFFF, false, false, 0x3FFFFFFF);

        public static readonly CrcArgument CRC_31_PHILIPS = new CrcArgument(31, 0x04C11DB7, 0x7FFFFFFF, false, false, 0x7FFFFFFF);

        public static readonly CrcArgument CRC_32 = new CrcArgument(32, 0x04C11DB7, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_AIXM = new CrcArgument(32, 0x814141AB, 0x00000000, false, false, 0x00000000);
        public static readonly CrcArgument CRC_32_AUTOSAR = new CrcArgument(32, 0xF4ACFB13, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_BASE91_D = new CrcArgument(32, 0xA833982B, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_BZIP2 = new CrcArgument(32, 0x04C11DB7, 0xFFFFFFFF, false, false, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_CD_ROM_EDC = new CrcArgument(32, 0x8001801B, 0x00000000, true, true, 0x00000000);
        public static readonly CrcArgument CRC_32_CKSUM = new CrcArgument(32, 0x04C11DB7, 0x00000000, false, false, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_INTERLAKEN = new CrcArgument(32, 0x1EDC6F41, 0xFFFFFFFF, true, true, 0xFFFFFFFF);
        public static readonly CrcArgument CRC_32_JAMCRC = new CrcArgument(32, 0x04C11DB7, 0xFFFFFFFF, true, true, 0x00000000);
        public static readonly CrcArgument CRC_32_MPEG2 = new CrcArgument(32, 0x04C11DB7, 0xFFFFFFFF, false, false, 0x00000000);
        public static readonly CrcArgument CRC_32_XFER = new CrcArgument(32, 0x000000AF, 0x00000000, false, false, 0x00000000);

        public static readonly CrcArgument CRC_40_GSM = new CrcArgument(40, 0x00_0482_0009, 0x00_0000_0000, false, false, 0xFF_FFFF_FFFF);

        public static readonly CrcArgument CRC_64 = new CrcArgument(64, 0x42F0_E1EB_A9EA_3693, 0x0000_0000_0000_0000, false, false, 0x0000_0000_0000_0000);
        public static readonly CrcArgument CRC_64_1B = new CrcArgument(64, 0x0000_0000_0000_001B, 0x0000_0000_0000_0000, true, true, 0x0000_0000_0000_0000);
        public static readonly CrcArgument CRC_64_GO_ISO = new CrcArgument(64, 0x0000_0000_0000_001B, 0xFFFF_FFFF_FFFF_FFFF, true, true, 0xFFFF_FFFF_FFFF_FFFF);
        public static readonly CrcArgument CRC_64_JONES = new CrcArgument(64, 0xAD93_D235_94C9_35A9, 0xFFFF_FFFF_FFFF_FFFF, true, true, 0x0000_0000_0000_0000);
        public static readonly CrcArgument CRC_64_WE = new CrcArgument(64, 0x42F0_E1EB_A9EA_3693, 0xFFFF_FFFF_FFFF_FFFF, false, false, 0xFFFF_FFFF_FFFF_FFFF);
        public static readonly CrcArgument CRC_64_XZ = new CrcArgument(64, 0x42F0_E1EB_A9EA_3693, 0xFFFF_FFFF_FFFF_FFFF, true, true, 0xFFFF_FFFF_FFFF_FFFF);
    }
}
