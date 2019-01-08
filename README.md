# C\# Object 2 Object Mapping Benchmarks
This project was created to benchmark some of the most known object to object mappers for .NET.

The purpose is not to compare the functionalities between them. Only to see how fast they go. 

## Benchmarked Mappers
All of the below mappers where included in the project using the respective NuGet packages.

* AgileMapper 0.23.2
* AutoMapper 6.2.2
* EmitMapper 1.0.0
* ExpressMapper 1.9.1 (failled on Nested Object :/)
* Mapster 3.1.8
* SafeMapper 2.0.118
* ValueInjecter 3.1.1.5

## Latest Results

**System specs**
```
BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.402 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
Frequency=3914059 Hz, Resolution=255.4893 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2633.0
```

**Simple object (10.000 instances)**

| Mapper | Median | StdDev |
| --- | ---: | ---: |
| Handwritten | 0.6064 ms | 0.0050 ms |
| SafeMapper | 0.6231 ms | 0.0317 ms |
| EmitMapper | 0.7815 ms | 0.0072 ms |
| Mapster | 2.571 ms | 0.0304 ms |
| AgileMapper | 3.394 ms | 0.0320 ms |
| AutoMapper | 3.592 ms |  0.1256 ms |
| ValueInjecter | 55.35 ms | 0.4637 ms |


**Nested objects  (10.000 instances)**

|    Mapper |    Median |    StdDev |
|---------- |----------: |----------: | 
| Handwritten | 0.6364 ms | 0.0034 ms |
| SafeMapper | 0.6481 ms | 0.0042 ms |
| EmitMapper | 0.8443 ms | 0.0069 ms |
| AgileMapper | 3.394 ms | 0.0320 ms |
| AutoMapper |  4.990 ms |   0.0367 ms |
| ValueInjecter | 60.31 ms | 0.3498 ms |
| Mapster | 115.068 ms | 0.8521 ms |
| AgileMapper | 128.835 ms | 3.8260 ms |

