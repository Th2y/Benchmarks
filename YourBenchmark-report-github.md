```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
11th Gen Intel Core i5-11400H 2.70GHz (Max: 2.69GHz), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v4


```
| Method       | Size  | EarlyBreak | Mean          | Error       | StdDev      | Median        | Allocated |
|------------- |------ |----------- |--------------:|------------:|------------:|--------------:|----------:|
| **UsingAny**     | **10**    | **False**      |     **57.800 ns** |   **0.6519 ns** |   **0.5779 ns** |     **57.546 ns** |         **-** |
| UsingForeach | 10    | False      |      9.953 ns |   0.2212 ns |   0.2173 ns |      9.907 ns |         - |
| UsingFor     | 10    | False      |     10.074 ns |   0.2077 ns |   0.1943 ns |     10.052 ns |         - |
| UsingHashSet | 10    | False      |      6.508 ns |   0.0870 ns |   0.0814 ns |      6.463 ns |         - |
| **UsingAny**     | **10**    | **True**       |     **26.240 ns** |   **0.1920 ns** |   **0.1603 ns** |     **26.238 ns** |         **-** |
| UsingForeach | 10    | True       |      5.773 ns |   0.0508 ns |   0.0475 ns |      5.790 ns |         - |
| UsingFor     | 10    | True       |      6.824 ns |   0.1533 ns |   0.1505 ns |      6.757 ns |         - |
| UsingHashSet | 10    | True       |      9.193 ns |   0.1896 ns |   0.2658 ns |      9.157 ns |         - |
| **UsingAny**     | **100**   | **False**      |    **557.006 ns** |   **6.0131 ns** |   **5.3305 ns** |    **556.026 ns** |         **-** |
| UsingForeach | 100   | False      |     89.032 ns |   1.8183 ns |   1.7859 ns |     88.262 ns |         - |
| UsingFor     | 100   | False      |     86.213 ns |   0.7980 ns |   0.7074 ns |     86.016 ns |         - |
| UsingHashSet | 100   | False      |      6.440 ns |   0.0382 ns |   0.0358 ns |      6.429 ns |         - |
| **UsingAny**     | **100**   | **True**       |     **25.969 ns** |   **0.1160 ns** |   **0.0969 ns** |     **25.956 ns** |         **-** |
| UsingForeach | 100   | True       |      6.516 ns |   0.0600 ns |   0.0532 ns |      6.518 ns |         - |
| UsingFor     | 100   | True       |      7.086 ns |   0.1367 ns |   0.1278 ns |      7.040 ns |         - |
| UsingHashSet | 100   | True       |      9.398 ns |   0.2061 ns |   0.2291 ns |      9.370 ns |         - |
| **UsingAny**     | **1000**  | **False**      |  **7,210.062 ns** | **144.0819 ns** | **154.1660 ns** |  **7,170.993 ns** |         **-** |
| UsingForeach | 1000  | False      |    993.841 ns |   3.1261 ns |   2.7712 ns |    993.514 ns |         - |
| UsingFor     | 1000  | False      |  1,012.601 ns |  17.5649 ns |  16.4302 ns |  1,010.932 ns |         - |
| UsingHashSet | 1000  | False      |      6.477 ns |   0.0538 ns |   0.0477 ns |      6.481 ns |         - |
| **UsingAny**     | **1000**  | **True**       |     **26.210 ns** |   **0.1929 ns** |   **0.1611 ns** |     **26.170 ns** |         **-** |
| UsingForeach | 1000  | True       |      6.062 ns |   0.0655 ns |   0.0581 ns |      6.055 ns |         - |
| UsingFor     | 1000  | True       |      7.051 ns |   0.1701 ns |   0.1820 ns |      6.963 ns |         - |
| UsingHashSet | 1000  | True       |      9.055 ns |   0.1297 ns |   0.1150 ns |      9.008 ns |         - |
| **UsingAny**     | **10000** | **False**      | **69,801.888 ns** | **762.1653 ns** | **636.4425 ns** | **69,514.465 ns** |         **-** |
| UsingForeach | 10000 | False      |  9,981.142 ns |  91.4786 ns |  76.3887 ns |  9,970.782 ns |         - |
| UsingFor     | 10000 | False      | 10,306.002 ns | 198.6069 ns | 176.0599 ns | 10,267.167 ns |         - |
| UsingHashSet | 10000 | False      |      6.628 ns |   0.1366 ns |   0.1278 ns |      6.649 ns |         - |
| **UsingAny**     | **10000** | **True**       |     **27.077 ns** |   **0.4096 ns** |   **0.3831 ns** |     **27.007 ns** |         **-** |
| UsingForeach | 10000 | True       |      6.261 ns |   0.1543 ns |   0.2060 ns |      6.275 ns |         - |
| UsingFor     | 10000 | True       |      7.728 ns |   0.1362 ns |   0.1274 ns |      7.671 ns |         - |
| UsingHashSet | 10000 | True       |     10.454 ns |   0.2425 ns |   0.6878 ns |     10.146 ns |         - |
