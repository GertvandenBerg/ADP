// See https://aka.ms/new-console-template for more information

using adp.BenchmarkDotNet.Artifacts.Benchmarks;
using adp.Benchmarks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

BenchmarkRunner.Run<PriorityQueueBenchmarks>();
BenchmarkRunner.Run<DequeBenchmarks>();
BenchmarkRunner.Run<DoublyLinkedListBenchmarks>();
BenchmarkRunner.Run<DynamicArrayBenchmarks>();
BenchmarkRunner.Run<StackBenchmarks>();