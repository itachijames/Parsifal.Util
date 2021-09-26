namespace Parsifal.Util.CRC
{
    /// <summary>
    /// CRC算法类型
    /// </summary>
    public enum CrcAlgorithmType
    {//Do not rename Item. 勿对各项重命名
        None,
        /// <summary>
        /// CRC-3/GSM
        /// </summary>
        CRC_3_GSM,
        /// <summary>
        /// CRC-3/ROHC
        /// </summary>
        CRC_3_ROHC,
        /// <summary>
        /// CRC_4_INTERLAKEN
        /// </summary>
        CRC_4_INTERLAKEN,
        /// <summary>
        /// CRC-4/ITU or CRC-4/G-704
        /// </summary>
        CRC_4_ITU,
        /// <summary>
        /// CRC-5/EPC or CRC-5/EPC-C1G2
        /// </summary>
        CRC_5_EPC,
        /// <summary>
        /// CRC-5/ITU or CRC-5/G-704
        /// </summary>
        CRC_5_ITU,
        /// <summary>
        /// CRC-5/USB
        /// </summary>
        CRC_5_USB,
        /// <summary>
        /// CRC-6/CDMA2000-A
        /// </summary>
        CRC_6_CDMA2000_A,
        /// <summary>
        /// CRC-6/CDMA2000-B
        /// </summary>
        CRC_6_CDMA2000_B,
        /// <summary>
        /// CRC-6/DARC
        /// </summary>
        CRC_6_DARC,
        /// <summary>
        /// CRC-6/GSM
        /// </summary>
        CRC_6_GSM,
        /// <summary>
        /// CRC-6/ITU or CRC-6/G-704
        /// </summary>
        CRC_6_ITU,
        /// <summary>
        /// CRC-7 or CRC-7/MMC
        /// </summary>
        CRC_7,
        /// <summary>
        /// CRC-7/ROHC
        /// </summary>
        CRC_7_ROHC,
        /// <summary>
        /// CRC-7/UMTS
        /// </summary>
        CRC_7_UMTS,
        /// <summary>
        /// CRC-8 or CRC-8/SMBUS
        /// </summary>
        CRC_8,
        /// <summary>
        /// CRC-8/AES or CRC-8/EBU or CRC-8/TECH-3250
        /// </summary>
        CRC_8_AES,
        /// <summary>
        /// CRC-8/AUTOSAR
        /// </summary>
        CRC_8_AUTOSAR,
        /// <summary>
        /// CRC-8/BLUETOOTH
        /// </summary>
        CRC_8_BLUETOOTH,
        /// <summary>
        /// CRC-8/CDMA2000
        /// </summary>
        CRC_8_CDMA2000,
        /// <summary>
        /// CRC-8/DARC
        /// </summary>
        CRC_8_DARC,
        /// <summary>
        /// CRC-8/DVB-S2
        /// </summary>
        CRC_8_DVB_S2,
        /// <summary>
        /// CRC-8/GSM-A
        /// </summary>
        CRC_8_GSM_A,
        /// <summary>
        /// CRC-8/GSM-B
        /// </summary>
        CRC_8_GSM_B,
        /// <summary>
        /// CRC-8/ITU or CRC-8/I-432-1
        /// </summary>
        CRC_8_ITU,
        /// <summary>
        /// CRC-8/I-CODE
        /// </summary>
        CRC_8_I_CODE,
        /// <summary>
        /// CRC-8/LTE
        /// </summary>
        CRC_8_LTE,
        /// <summary>
        /// CRC-8/MAXIM or CRC-8/MAXIM-DOW or DOW-CRC
        /// </summary>
        CRC_8_MAXIM,
        /// <summary>
        /// CRC-8/MIFARE-MAD
        /// </summary>
        CRC_8_MIFARE_MAD,
        /// <summary>
        /// CRC-8/NRSC-5
        /// </summary>
        CRC_8_NRSC5,
        /// <summary>
        /// CRC-8/OPENSAFETY
        /// </summary>
        CRC_8_OPENSAFETY,
        /// <summary>
        /// CRC-8/ROHC
        /// </summary>
        CRC_8_ROHC,
        /// <summary>
        /// CRC-8/SAE-J1850
        /// </summary>
        CRC_8_SAE_J1850,
        /// <summary>
        /// CRC-8/WCDMA
        /// </summary>
        CRC_8_WCDMA,
        /// <summary>
        /// CRC-10 or CRC-10/ATM or CRC-10/I-610
        /// </summary>
        CRC_10,
        /// <summary>
        /// CRC-10/CDMA2000
        /// </summary>
        CRC_10_CDMA2000,
        /// <summary>
        /// CRC-10/GSM
        /// </summary>
        CRC_10_GSM,
        /// <summary>
        /// CRC-11 or CRC-11/FLEXRAY
        /// </summary>
        CRC_11,
        /// <summary>
        /// CRC-11/UMTS
        /// </summary>
        CRC_11_UMTS,
        /// <summary>
        /// CRC-12/CDMA2000
        /// </summary>
        CRC_12_CDMA2000,
        /// <summary>
        /// CRC-12/DECT or X-CRC-12
        /// </summary>
        CRC_12_DECT,
        /// <summary>
        /// CRC-12/GSM
        /// </summary>
        CRC_12_GSM,
        /// <summary>
        /// CRC-12/UMTS or CRC-12/3GPP
        /// </summary>
        CRC_12_UMTS,
        /// <summary>
        /// CRC-13/BBC
        /// </summary>
        CRC_13_BBC,
        /// <summary>
        /// CRC-14/DARC
        /// </summary>
        CRC_14_DARC,
        /// <summary>
        /// CRC-14/ELORAN
        /// </summary>
        CRC_14_ELORAN,
        /// <summary>
        /// CRC-14/GSM
        /// </summary>
        CRC_14_GSM,
        /// <summary>
        /// CRC-15 or CRC-15/CAN
        /// </summary>
        CRC_15,
        /// <summary>
        /// CRC-15/MPT1327
        /// </summary>
        CRC_15_MPT1327,
        /// <summary>
        /// CRC-16 or CRC16/IBM or CRC16/ARC or CRC16/LHA
        /// </summary>
        CRC_16,
        /// <summary>
        /// CRC-16/AUG-CCITT or CRC-16/SPI-FUJITSU
        /// </summary>
        CRC_16_AUG_CCITT,
        /// <summary>
        /// CRC-16/CCITT or CRC-16/CCITT-TRUE or CRC-16/KERMIT or CRC-16/V-41-LSB
        /// </summary>
        CRC_16_CCITT,
        /// <summary>
        /// CRC-16/CCITT-FALSE or CRC-16/AUTOSAR or CRC-16/IBM-3740
        /// </summary>
        CRC_16_CCITT_FALSE,
        /// <summary>
        /// CRC-16/CDMA2000
        /// </summary>
        CRC_16_CDMA2000,
        /// <summary>
        /// CRC-16/CMS
        /// </summary>
        CRC_16_CMS,
        /// <summary>
        /// CRC-16/DARC or CRC-16/EPC or CRC-16/GENIBUS or CRC-16/EPC-C1G2 or CRC-16/I-CODE
        /// </summary>
        CRC_16_DARC,
        /// <summary>
        /// CRC-16/DDS-110
        /// </summary>
        CRC_16_DDS_110,
        /// <summary>
        /// CRC-16/DECT-R or R-CRC-16
        /// </summary>
        CRC_16_DECT_R,
        /// <summary>
        /// CRC-16/DECT-X or X-CRC-16
        /// </summary>
        CRC_16_DECT_X,
        /// <summary>
        /// CRC-16/DNP
        /// </summary>
        CRC_16_DNP,
        /// <summary>
        /// CRC-16/EN-13757
        /// </summary>
        CRC_16_EN_13757,
        /// <summary>
        /// CRC-16/GSM
        /// </summary>
        CRC_16_GSM,
        /// <summary>
        /// CRC-16/ISO-IEC-14443-3-A or CRC-A
        /// </summary>
        CRC_16_ISO_IEC_14443_3_A,
        /// <summary>
        /// CRC-16/LJ1200
        /// </summary>
        CRC_16_LJ1200,
        /// <summary>
        /// CRC-16/MAXIM or CRC-16/MAXIM-DOW
        /// </summary>
        CRC_16_MAXIM,
        /// <summary>
        /// CRC-16/MCRF4XX
        /// </summary>
        CRC_16_MCRF4XX,
        /// <summary>
        /// CRC-16/MODBUS
        /// </summary>
        CRC_16_MODBUS,
        /// <summary>
        /// CRC-16/NRSC-5
        /// </summary>
        CRC_16_NRSC_5,
        /// <summary>
        /// CRC-16/OPENSAFETY-A
        /// </summary>
        CRC_16_OPENSAFETY_A,
        /// <summary>
        /// CRC-16/OPENSAFETY-B
        /// </summary>
        CRC_16_OPENSAFETY_B,
        /// <summary>
        /// CRC-16/PROFIBUS or CRC-16/IEC-61158-2
        /// </summary>
        CRC_16_PROFIBUS,
        /// <summary>
        /// CRC-16/RIELLO
        /// </summary>
        CRC_16_RIELLO,
        /// <summary>
        /// CRC-16/T10-DIF
        /// </summary>
        CRC_16_T10_DIF,
        /// <summary>
        /// CRC-16/TELEDISK
        /// </summary>
        CRC_16_TELEDISK,
        /// <summary>
        /// CRC-16/TMS37157
        /// </summary>
        CRC_16_TMS37157,
        /// <summary>
        /// CRC-16/UMTS or CRC-16/BUYPASS or CRC-16/VERIFONE
        /// </summary>
        CRC_16_UMTS,
        /// <summary>
        /// CRC-16/USB
        /// </summary>
        CRC_16_USB,
        /// <summary>
        /// CRC-16/X-25 or CRC-16/IBM-SDLC or CRC-16/ISO-HDLC or CRC-16/ISO-IEC-14443-3-B or CRC-B
        /// </summary>
        CRC_16_X25,
        /// <summary>
        /// CRC-16/XMODEM or CRC-16/ACORN, CRC-16/LTE, CRC-16/V-41-MSB, XMODEM, ZMODEM
        /// </summary>
        CRC_16_XMODEM,
        /// <summary>
        /// CRC-17/CAN-FD
        /// </summary>
        CRC_17_CAN_FD,
        /// <summary>
        /// CRC-21/CAN-FD
        /// </summary>
        CRC_21_CAN_FD,
        /// <summary>
        /// CRC-24 or CRC-24/OPENPGP
        /// </summary>
        CRC_24,
        /// <summary>
        /// CRC-24/BLE
        /// </summary>
        CRC_24_BLE,
        /// <summary>
        /// CRC-24/FLEXRAY-A
        /// </summary>
        CRC_24_FLEXRAY_A,
        /// <summary>
        /// CRC-24/FLEXRAY-B
        /// </summary>
        CRC_24_FLEXRAY_B,
        /// <summary>
        /// CRC-24/INTERLAKEN
        /// </summary>
        CRC_24_INTERLAKEN,
        /// <summary>
        /// CRC-24/LTE-A
        /// </summary>
        CRC_24_LTE_A,
        /// <summary>
        /// CRC-24/LTE-B
        /// </summary>
        CRC_24_LTE_B,
        /// <summary>
        /// CRC-24/OS-9
        /// </summary>
        CRC_24_OS9,
        /// <summary>
        /// CRC-30/CDMA
        /// </summary>
        CRC_30_CDMA,
        /// <summary>
        /// CRC-31/PHILIPS
        /// </summary>
        CRC_31_PHILIPS,
        /// <summary>
        /// CRC-32 or CRC-32/ISO-HDLC or CRC-32/ADCCP or CRC-32/V-42 or CRC-32/XZ or PKZIP
        /// </summary>
        CRC_32,
        /// <summary>
        /// CRC-32/AIXM or CRC-32Q
        /// </summary>
        CRC_32_AIXM,
        /// <summary>
        /// CRC-32/AUTOSAR
        /// </summary>
        CRC_32_AUTOSAR,
        /// <summary>
        /// CRC-32/BASE91-D or CRC-32D
        /// </summary>
        CRC_32_BASE91_D,
        /// <summary>
        /// CRC-32/BZIP2 or CRC-32/AAL5 or CRC-32/DECT-B, B-CRC-32
        /// </summary>
        CRC_32_BZIP2,
        /// <summary>
        /// CRC-32/CD-ROM-EDC
        /// </summary>
        CRC_32_CD_ROM_EDC,
        /// <summary>
        /// CRC-32/CKSUM or CRC-32/POSIX or CKSUM
        /// </summary>
        CRC_32_CKSUM,
        /// <summary>
        /// CRC-32/INTERLAKEN or CRC-32/ISCSI or CRC-32/BASE91-C or CRC-32/CASTAGNOLI or CRC-32C
        /// </summary>
        CRC_32_INTERLAKEN,
        /// <summary>
        /// CRC-32/JAMCRC
        /// </summary>
        CRC_32_JAMCRC,
        /// <summary>
        /// CRC-32/MPEG-2
        /// </summary>
        CRC_32_MPEG2,
        /// <summary>
        /// CRC-32/XFER
        /// </summary>
        CRC_32_XFER,
        /// <summary>
        /// CRC-40/GSM
        /// </summary>
        CRC_40_GSM,
        /// <summary>
        /// CRC-64 or CRC-64/ECMA-182
        /// </summary>
        CRC_64,
        /// <summary>
        /// CRC-64/1B
        /// </summary>
        CRC_64_1B,
        /// <summary>
        /// CRC-64/GO-ISO
        /// </summary>
        CRC_64_GO_ISO,
        /// <summary>
        /// CRC-64/Jones
        /// </summary>
        CRC_64_JONES,
        /// <summary>
        /// CRC-64/WE
        /// </summary>
        CRC_64_WE,
        /// <summary>
        /// CRC-64/XZ or CRC-64/GO-ECMA
        /// </summary>
        CRC_64_XZ,
        ///// <summary>
        ///// CRC-82/DARC
        ///// </summary>
        //CRC_82_DARC
    }
}
