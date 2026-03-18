
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
11th Gen Intel Core i5-11400H 2.70GHz (Max: 2.69GHz), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.201
  [Host]     : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.5 (10.0.5, 10.0.526.15411), X64 RyuJIT x86-64-v4


 Method                 | CollectionSize | EnableEarlyExit | Mean          | Error         | StdDev        | Allocated |
----------------------- |--------------- |---------------- |--------------:|--------------:|--------------:|----------:|
 **LinqAny_MultipleChecks** | **10**             | **False**           |     **62.249 ns** |     **1.0827 ns** |     **1.0128 ns** |         **-** |
 Foreach_SinglePass     | 10             | False           |      9.957 ns |     0.2237 ns |     0.2297 ns |         - |
 For_SinglePass         | 10             | False           |      9.702 ns |     0.1577 ns |     0.1398 ns |         - |
 HashSet_ContainsLookup | 10             | False           |      6.771 ns |     0.1669 ns |     0.2050 ns |         - |
 **LinqAny_MultipleChecks** | **10**             | **True**            |     **26.698 ns** |     **0.5447 ns** |     **0.5350 ns** |         **-** |
 Foreach_SinglePass     | 10             | True            |      6.602 ns |     0.1315 ns |     0.1230 ns |         - |
 For_SinglePass         | 10             | True            |      6.745 ns |     0.1517 ns |     0.1345 ns |         - |
 HashSet_ContainsLookup | 10             | True            |      9.389 ns |     0.2140 ns |     0.2002 ns |         - |
 **LinqAny_MultipleChecks** | **100**            | **False**           |    **565.502 ns** |    **11.0075 ns** |     **9.7578 ns** |         **-** |
 Foreach_SinglePass     | 100            | False           |     91.309 ns |     1.8402 ns |     2.2599 ns |         - |
 For_SinglePass         | 100            | False           |     88.475 ns |     1.8048 ns |     2.4705 ns |         - |
 HashSet_ContainsLookup | 100            | False           |      6.519 ns |     0.0959 ns |     0.0897 ns |         - |
 **LinqAny_MultipleChecks** | **100**            | **True**            |     **25.737 ns** |     **0.5125 ns** |     **0.5263 ns** |         **-** |
 Foreach_SinglePass     | 100            | True            |      6.132 ns |     0.0656 ns |     0.0548 ns |         - |
 For_SinglePass         | 100            | True            |      6.483 ns |     0.0522 ns |     0.0436 ns |         - |
 HashSet_ContainsLookup | 100            | True            |      9.118 ns |     0.1670 ns |     0.1562 ns |         - |
 **LinqAny_MultipleChecks** | **1000**           | **False**           |  **6,859.445 ns** |   **105.2003 ns** |    **98.4045 ns** |         **-** |
 Foreach_SinglePass     | 1000           | False           |  1,031.793 ns |    16.5404 ns |    15.4719 ns |         - |
 For_SinglePass         | 1000           | False           |  1,034.019 ns |    19.4236 ns |    20.7830 ns |         - |
 HashSet_ContainsLookup | 1000           | False           |      7.331 ns |     0.1760 ns |     0.1807 ns |         - |
 **LinqAny_MultipleChecks** | **1000**           | **True**            |     **28.184 ns** |     **0.5893 ns** |     **0.6787 ns** |         **-** |
 Foreach_SinglePass     | 1000           | True            |      6.694 ns |     0.1635 ns |     0.2068 ns |         - |
 For_SinglePass         | 1000           | True            |      7.113 ns |     0.1688 ns |     0.1579 ns |         - |
 HashSet_ContainsLookup | 1000           | True            |      9.501 ns |     0.2189 ns |     0.2606 ns |         - |
 **LinqAny_MultipleChecks** | **10000**          | **False**           | **71,946.720 ns** | **1,429.2483 ns** | **1,588.6057 ns** |         **-** |
 Foreach_SinglePass     | 10000          | False           | 10,437.329 ns |   204.4805 ns |   200.8272 ns |         - |
 For_SinglePass         | 10000          | False           | 10,230.117 ns |   195.1971 ns |   200.4530 ns |         - |
 HashSet_ContainsLookup | 10000          | False           |      6.323 ns |     0.0277 ns |     0.0231 ns |         - |
 **LinqAny_MultipleChecks** | **10000**          | **True**            |     **26.563 ns** |     **0.5299 ns** |     **0.4957 ns** |         **-** |
 Foreach_SinglePass     | 10000          | True            |      6.228 ns |     0.1478 ns |     0.1383 ns |         - |
 For_SinglePass         | 10000          | True            |      7.782 ns |     0.1182 ns |     0.1106 ns |         - |
 HashSet_ContainsLookup | 10000          | True            |      8.872 ns |     0.0580 ns |     0.0453 ns |         - |
