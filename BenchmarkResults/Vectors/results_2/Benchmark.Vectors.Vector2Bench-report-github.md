``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.918/21H2)
Intel Core i7-10700T CPU 2.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2


```
|                          Method |    N |          Mean |         Error |        StdDev |      StdErr |        Median |           Min |            Q1 |            Q3 |           Max |          Op/s | Ratio | RatioSD |
|-------------------------------- |----- |--------------:|--------------:|--------------:|------------:|--------------:|--------------:|--------------:|--------------:|--------------:|--------------:|------:|--------:|
|               **ValueTuple2_Bench** |   **10** |      **8.062 ns** |     **0.1544 ns** |     **0.2062 ns** |   **0.0412 ns** |      **8.018 ns** |      **7.806 ns** |      **7.931 ns** |      **8.076 ns** |      **8.578 ns** | **124,041,330.6** |  **1.00** |    **0.00** |
|              Vector2_Init_Bench |   10 |     23.949 ns |     0.1749 ns |     0.1636 ns |   0.0422 ns |     23.902 ns |     23.666 ns |     23.809 ns |     24.112 ns |     24.196 ns |  41,756,022.4 |  2.94 |    0.09 |
|            UEVector2_Init_Bench |   10 |     11.252 ns |     0.1088 ns |     0.0965 ns |   0.0258 ns |     11.291 ns |     11.090 ns |     11.172 ns |     11.313 ns |     11.384 ns |  88,876,490.2 |  1.38 |    0.04 |
|              VectorFloat2_Bench |   10 |     30.765 ns |     0.5681 ns |     0.5314 ns |   0.1372 ns |     30.858 ns |     29.897 ns |     30.314 ns |     31.189 ns |     31.522 ns |  32,504,807.3 |  3.78 |    0.14 |
|             VectorDouble2_Bench |   10 |     33.480 ns |     0.6510 ns |     1.0135 ns |   0.1792 ns |     33.246 ns |     32.215 ns |     32.759 ns |     33.921 ns |     35.978 ns |  29,868,360.6 |  4.17 |    0.17 |
|       VectorFloat2_Static_Bench |   10 |    366.060 ns |     6.5277 ns |    13.6258 ns |   1.8716 ns |    360.702 ns |    352.156 ns |    358.230 ns |    366.052 ns |    403.948 ns |   2,731,794.7 | 46.55 |    2.73 |
|         VectorFloat2_Init_Bench |   10 |     41.915 ns |     0.4593 ns |     0.4297 ns |   0.1109 ns |     41.967 ns |     41.033 ns |     41.688 ns |     42.167 ns |     42.492 ns |  23,858,010.2 |  5.15 |    0.16 |
|          Tuple2Float_Init_Bench |   10 |    759.155 ns |    14.6672 ns |    14.4052 ns |   3.6013 ns |    757.854 ns |    733.443 ns |    750.744 ns |    772.962 ns |    779.737 ns |   1,317,253.6 | 93.43 |    2.94 |
|     ValueTuple2Float_Init_Bench |   10 |      8.250 ns |     0.1956 ns |     0.2678 ns |   0.0525 ns |      8.135 ns |      7.925 ns |      8.081 ns |      8.359 ns |      8.805 ns | 121,213,961.4 |  1.02 |    0.05 |
|       MyVector2Float_Init_Bench |   10 |    213.620 ns |     4.2603 ns |     6.1101 ns |   1.1547 ns |    213.462 ns |    204.563 ns |    208.706 ns |    219.657 ns |    222.799 ns |   4,681,212.5 | 26.52 |    1.15 |
| MyStructVector2Float_Init_Bench |   10 |      9.738 ns |     0.1663 ns |     0.1389 ns |   0.0385 ns |      9.739 ns |      9.496 ns |      9.655 ns |      9.841 ns |      9.948 ns | 102,691,933.3 |  1.19 |    0.03 |
|  MyTupleVector2Float_Init_Bench |   10 |    210.580 ns |     3.9031 ns |     7.1371 ns |   1.1013 ns |    209.307 ns |    202.696 ns |    205.221 ns |    212.396 ns |    231.384 ns |   4,748,783.3 | 26.35 |    1.01 |
|      ExtensionArray2_Init_Bench |   10 |    497.027 ns |     9.7502 ns |     9.5760 ns |   2.3940 ns |    495.738 ns |    481.804 ns |    489.121 ns |    502.360 ns |    514.585 ns |   2,011,961.6 | 61.17 |    2.11 |
|                                 |      |               |               |               |             |               |               |               |               |               |               |       |         |
|               **ValueTuple2_Bench** |  **100** |     **94.154 ns** |     **1.6331 ns** |     **1.5276 ns** |   **0.3944 ns** |     **93.973 ns** |     **91.748 ns** |     **92.980 ns** |     **95.489 ns** |     **96.750 ns** |  **10,620,881.9** |  **1.00** |    **0.00** |
|              Vector2_Init_Bench |  100 |    252.807 ns |     4.9415 ns |     4.6223 ns |   1.1935 ns |    252.122 ns |    245.306 ns |    250.193 ns |    255.749 ns |    264.061 ns |   3,955,581.1 |  2.69 |    0.07 |
|            UEVector2_Init_Bench |  100 |    106.711 ns |     1.5734 ns |     1.3948 ns |   0.3728 ns |    106.734 ns |    104.687 ns |    105.835 ns |    107.639 ns |    109.176 ns |   9,371,062.7 |  1.14 |    0.02 |
|              VectorFloat2_Bench |  100 |    139.246 ns |     2.8156 ns |     6.4126 ns |   0.8144 ns |    139.640 ns |    127.796 ns |    134.412 ns |    144.003 ns |    153.406 ns |   7,181,538.2 |  1.42 |    0.07 |
|             VectorDouble2_Bench |  100 |    132.796 ns |     2.3014 ns |     2.2602 ns |   0.5651 ns |    132.941 ns |    129.343 ns |    131.589 ns |    133.986 ns |    137.440 ns |   7,530,337.2 |  1.41 |    0.04 |
|       VectorFloat2_Static_Bench |  100 |  3,656.665 ns |    70.1803 ns |    65.6467 ns |  16.9499 ns |  3,642.900 ns |  3,569.106 ns |  3,604.667 ns |  3,707.375 ns |  3,787.846 ns |     273,473.3 | 38.85 |    1.04 |
|         VectorFloat2_Init_Bench |  100 |    137.488 ns |     2.7768 ns |     5.0775 ns |   0.7835 ns |    135.981 ns |    130.209 ns |    133.324 ns |    140.769 ns |    150.688 ns |   7,273,366.7 |  1.43 |    0.05 |
|          Tuple2Float_Init_Bench |  100 |  7,221.551 ns |   133.3785 ns |   153.5989 ns |  34.3458 ns |  7,193.771 ns |  6,998.769 ns |  7,116.883 ns |  7,302.456 ns |  7,515.984 ns |     138,474.4 | 76.89 |    2.39 |
|     ValueTuple2Float_Init_Bench |  100 |     94.553 ns |     0.9392 ns |     0.8785 ns |   0.2268 ns |     94.488 ns |     93.571 ns |     93.766 ns |     95.015 ns |     96.767 ns |  10,576,076.3 |  1.00 |    0.02 |
|       MyVector2Float_Init_Bench |  100 |  1,959.608 ns |    38.6704 ns |    88.0721 ns |  11.1852 ns |  1,925.242 ns |  1,846.665 ns |  1,900.583 ns |  2,022.656 ns |  2,220.615 ns |     510,306.1 | 21.75 |    1.23 |
| MyStructVector2Float_Init_Bench |  100 |    110.101 ns |     2.1812 ns |     2.2399 ns |   0.5433 ns |    110.171 ns |    106.286 ns |    108.531 ns |    111.616 ns |    114.938 ns |   9,082,530.4 |  1.17 |    0.03 |
|  MyTupleVector2Float_Init_Bench |  100 |  1,933.866 ns |    29.7105 ns |    26.3376 ns |   7.0390 ns |  1,936.237 ns |  1,888.445 ns |  1,913.881 ns |  1,941.716 ns |  1,981.856 ns |     517,099.0 | 20.57 |    0.42 |
|      ExtensionArray2_Init_Bench |  100 |  4,650.659 ns |    91.0212 ns |   115.1127 ns |  24.0027 ns |  4,624.617 ns |  4,512.856 ns |  4,568.679 ns |  4,705.014 ns |  4,940.276 ns |     215,023.3 | 49.77 |    1.66 |
|                                 |      |               |               |               |             |               |               |               |               |               |               |       |         |
|               **ValueTuple2_Bench** | **1000** |    **883.867 ns** |     **6.8942 ns** |     **6.1115 ns** |   **1.6334 ns** |    **884.352 ns** |    **871.392 ns** |    **881.290 ns** |    **887.915 ns** |    **894.950 ns** |   **1,131,392.5** |  **1.00** |    **0.00** |
|              Vector2_Init_Bench | 1000 |  2,584.992 ns |    50.3382 ns |    49.4388 ns |  12.3597 ns |  2,577.611 ns |  2,516.686 ns |  2,540.888 ns |  2,617.664 ns |  2,668.689 ns |     386,848.3 |  2.93 |    0.06 |
|            UEVector2_Init_Bench | 1000 |  1,021.847 ns |    15.6007 ns |    14.5929 ns |   3.7679 ns |  1,024.825 ns |    997.743 ns |  1,009.376 ns |  1,030.665 ns |  1,046.477 ns |     978,620.2 |  1.16 |    0.02 |
|              VectorFloat2_Bench | 1000 |  1,162.626 ns |    23.1315 ns |    54.0690 ns |   6.7064 ns |  1,152.295 ns |  1,069.821 ns |  1,127.032 ns |  1,200.529 ns |  1,341.189 ns |     860,122.1 |  1.28 |    0.07 |
|             VectorDouble2_Bench | 1000 |  1,160.449 ns |    22.8588 ns |    28.0726 ns |   5.9851 ns |  1,156.513 ns |  1,106.904 ns |  1,137.729 ns |  1,178.238 ns |  1,214.904 ns |     861,735.6 |  1.32 |    0.03 |
|       VectorFloat2_Static_Bench | 1000 | 38,169.737 ns |   762.2839 ns | 1,486.7762 ns | 216.8686 ns | 38,244.312 ns | 35,648.322 ns | 36,883.160 ns | 39,392.154 ns | 41,654.749 ns |      26,198.8 | 42.83 |    1.40 |
|         VectorFloat2_Init_Bench | 1000 |  1,094.303 ns |    21.7419 ns |    31.1816 ns |   5.8928 ns |  1,091.920 ns |  1,050.309 ns |  1,069.105 ns |  1,113.821 ns |  1,161.116 ns |     913,823.4 |  1.24 |    0.03 |
|          Tuple2Float_Init_Bench | 1000 | 76,145.180 ns | 1,498.8502 ns | 2,504.2420 ns | 417.3737 ns | 75,327.930 ns | 72,625.293 ns | 74,378.412 ns | 77,597.791 ns | 81,800.354 ns |      13,132.8 | 87.01 |    2.86 |
|     ValueTuple2Float_Init_Bench | 1000 |    937.954 ns |     8.7805 ns |     8.2133 ns |   2.1207 ns |    938.946 ns |    920.697 ns |    931.794 ns |    944.486 ns |    947.987 ns |   1,066,149.8 |  1.06 |    0.01 |
|       MyVector2Float_Init_Bench | 1000 | 19,673.557 ns |   381.0972 ns |   836.5176 ns | 109.8401 ns | 19,406.506 ns | 18,442.245 ns | 19,013.625 ns | 20,211.786 ns | 21,561.661 ns |      50,829.6 | 22.92 |    1.15 |
| MyStructVector2Float_Init_Bench | 1000 |  1,026.465 ns |    17.0687 ns |    15.9661 ns |   4.1224 ns |  1,031.004 ns |  1,002.931 ns |  1,011.228 ns |  1,037.081 ns |  1,056.570 ns |     974,217.1 |  1.16 |    0.02 |
|  MyTupleVector2Float_Init_Bench | 1000 | 19,547.086 ns |   386.2914 ns |   686.6325 ns | 108.5661 ns | 19,326.933 ns | 18,594.208 ns | 18,951.660 ns | 20,015.070 ns | 21,017.371 ns |      51,158.5 | 22.35 |    0.86 |
|      ExtensionArray2_Init_Bench | 1000 | 48,697.599 ns |   959.3429 ns | 1,435.8992 ns | 262.1581 ns | 48,454.990 ns | 46,301.370 ns | 47,617.488 ns | 49,861.241 ns | 51,480.704 ns |      20,534.9 | 54.98 |    1.63 |