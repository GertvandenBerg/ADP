```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.404
  [Host] : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
| Method       | ItemCount | Mean            | Error        | StdDev       |
|------------- |---------- |----------------:|-------------:|-------------:|
| **AddElements**  | **1000**      |      **5,461.3 ns** |     **85.03 ns** |    **121.95 ns** |
| PollElements | 1000      |     70,668.0 ns |    145.90 ns |    209.24 ns |
| PeekElement  | 1000      |        165.3 ns |      2.61 ns |      3.75 ns |
| **AddElements**  | **10000**     |    **102,425.7 ns** |    **527.70 ns** |    **789.84 ns** |
| PollElements | 10000     |    988,678.9 ns |  2,656.02 ns |  3,893.16 ns |
| PeekElement  | 10000     |      1,205.6 ns |     22.43 ns |     31.45 ns |
| **AddElements**  | **100000**    |  **1,156,582.1 ns** |  **2,512.61 ns** |  **3,603.51 ns** |
| PollElements | 100000    | 12,633,514.9 ns | 28,408.24 ns | 41,640.43 ns |
| PeekElement  | 100000    |     25,796.2 ns |    241.52 ns |    346.38 ns |
