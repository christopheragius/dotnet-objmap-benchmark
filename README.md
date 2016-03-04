# C\# Object 2 Object Mapping Benchmarks
This project was created to benchmark some of the most known object to object mappers for .NET.

The purpose is not to compare the functionalities between them. Only to see how fast they go. 

## Benchmarked Mappers
All of the below mappers where included in the project using the respective NuGet packages.

* AutoMapper 4.2.1
* EmitMapper 1.0.0
* SafeMapper 2.0.118
* TinyMapper 2.0.8
* ValueInjecter 3.1.1.2

## Latest Results

**System specs**
```
BenchmarkDotNet=v0.9.1.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6600U CPU @ 2.60GHz, ProcessorCount=4
Frequency=2742184 ticks, Resolution=364.6728 ns
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
```

**Simple object (10.000 instances)**
```
    Mapper |    Median |    StdDev |
---------- |---------- |---------- |
 Handwritten | 1.6221 ms | 0.0713 ms |
 SafeMapper | 1.7654 ms | 0.2783 ms |
 EmitMapper | 1.8554 ms | 0.1163 ms |
 TinyMapper | 2.0483 ms | 0.0406 ms |
 ValueInjecter | 66.6965 ms | 2.7518 ms |
 AutoMapper | 93.6690 ms | 11.5649 ms |
```

**Nested objects  (10.000 instances)**
``` 
    Mapper |    Median |    StdDev |
---------- |---------- |---------- | 
 Handwritten | 1.6206 ms | 0.0364 ms |
 SafeMapper | 1.8354 ms | 0.0712 ms |
 EmitMapper | 1.9330 ms | 0.2161 ms |
 ValueInjecter | 74.4472 ms | 3.7340 ms |
 AutoMapper | 160.3249 ms |  6.4109 ms |
 ```
 
