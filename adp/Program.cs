// See https://aka.ms/new-console-template for more information

using adp.BenchmarkDotNet.Artifacts.Benchmarks;
using adp.BenchmarkDotNet.Artifacts.Benchmarks.Sortings;
using adp.Benchmarks;
using BenchmarkDotNet.Running;
using Benchmarks.Hashing;
using Benchmarks.Searches;

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

BenchmarkRunner.Run<PriorityQueueBenchmarks>();
BenchmarkRunner.Run<DequeBenchmarks>();
BenchmarkRunner.Run<DoublyLinkedListBenchmarks>();
BenchmarkRunner.Run<DynamicArrayBenchmarks>();
BenchmarkRunner.Run<StackBenchmarks>();
BenchmarkRunner.Run<BinarySearchBenchmarks>();
BenchmarkRunner.Run<InsertionSortBenchmarks>();
BenchmarkRunner.Run<ParallelMergeSortBenchmarks>();
BenchmarkRunner.Run<QuickSortBenchmarks>();
BenchmarkRunner.Run<SelectionSortBenchmarks>();
BenchmarkRunner.Run<HashTableBenchmarks>();
BenchmarkRunner.Run<GraphBenchmarks>();
BenchmarkRunner.Run<BinarySearchTreeBenchmarks>();
