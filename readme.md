# 简介 
[![BuildStatus](https://github.com/itachijames/Parsifal.Util/workflows/build%20%26%20test/badge.svg)](https://github.com/itachijames/Parsifal.Util/actions/workflows/build.yml?query=event%3Apush) 
[![NugetPackage](https://img.shields.io/nuget/v/Parsifal.Util.svg)](https://www.nuget.org/packages/Parsifal.Util) 

`Parsifal.Util` 是一个实用功能库。


# 功能
- CRC
- 字节操作
- Window进程、窗口操作
- more


# 使用
## CRC
``` C#
var testData = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };

ICrc ccitt = CrcFactory.GetCrc(CrcAlgorithmType.CRC_16_CCITT);
var result1 = ccitt.GetCrcValue(testData);

ICrc maxim = CrcFactory.GetCrc(CrcStandardParam.CRC_8_MAXIM);
var result2 = maxim.GetCrcBytes(testData);
```

## win窗口
``` C#
var app = new AppModuleInfo
{
    ProcessName = "notepad++"
};
if (WindowHelper.FindWindow(app, out var hwnd))
{
    WindowHelper.ShowWindow(hwnd, WindowShowType.SW_SHOWMAXIMIZED);
}
```