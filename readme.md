# Parsifal.Util
[![BuildStatus](https://github.com/itachijames/Parsifal.Util/workflows/build%20%26%20test/badge.svg)](https://github.com/itachijames/Parsifal.Util/actions/workflows/build.yml?query=event%3Apush) 
[![NugetPackage](https://img.shields.io/nuget/v/Parsifal.Util.svg)](https://www.nuget.org/packages/Parsifal.Util) 

`Parsifal.Util`是 *.Net* 平台下的一个实用功能库，提供开发中常用的组件功能。

项目初心是将历往工作中业务无关的常用功能进行良好封装以便复用。本项目对较频繁使用或已有完善实现的功能组件不进行收录，如(反)序列化、加解密等。

## 支持
- `.Net 6.0`+
- `.Net Standard 2.1`
- `.Net Framework 4.8`+

## 功能
- CRC
- 字符串操作
- 网络助手
- ...

## 使用
### CRC
``` C#
var testData = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };

ICrc ccitt = CrcFactory.GetCrc(CrcAlgorithmType.CRC_16_CCITT);
var result1 = ccitt.GetCrcValue(testData);

ICrc maxim = CrcFactory.GetCrc(CrcStandardParam.CRC_8_MAXIM);
var result2 = maxim.GetCrcBytes(testData);
```

### TCP服务
``` C#
var server = new SimpleTcpServer("192.168.57.57", 12345);
server.ClientConnected += (ep) =>
{
    Console.WriteLine($"{ep} connected!");
};
server.ReceiveDataFrom += (ep, data) =>
{
    Console.WriteLine($"receive message [{Encoding.UTF8.GetString(data)}] from {ep}");
};
server.Start();

var client = new SimpleTcpClient("192.168.57.57", 12345);
client.Connect();
Thread.Sleep(1000);
client.Send(Encoding.UTF8.GetBytes("hello"));
```
