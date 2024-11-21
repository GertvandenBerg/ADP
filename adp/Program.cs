// See https://aka.ms/new-console-template for more information
using adp.Benchmarks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<PriorityQueueBenchmarks>();

