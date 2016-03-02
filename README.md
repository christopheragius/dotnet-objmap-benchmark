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

## Some Results
The presented results are for 1.000.000 instances of the ```Person``` object.

All the results are measured in Milliseconds.

| Mapper | Simple | Nested |
| --- | --- | --- |
| Handwritten | 79 | 109 |
| TinyMapper | 201 | 194 |
| SafeMapper | 114 | 109 |
| EmitMapper | 110 | 118 |
| ValueInjecter | 2226 | 2231 |
| AutoMapper | 3354 | 5717 |
