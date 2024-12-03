using BenchmarkDotNet.Attributes;

namespace adp.BenchmarkDotNet.Artifacts.Benchmarks
{
    [MemoryDiagnoser]
    public class DequeBenchmarks
    {
        private int[] _randomNumbers;

        [Params(1_000, 10_000)]
        public int ItemCount;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();
            _randomNumbers = new int[ItemCount];
            for (int i = 0; i < ItemCount; i++)
            {
                _randomNumbers[i] = random.Next(1, ItemCount);
            }
        }

        [Benchmark]
        public void InsertLeftElements()
        {
            var deque = new DequeImplementation<int>();
            for (int i = 0; i < ItemCount; i++)
            {
                deque.InsertLeft(_randomNumbers[i]);
            }
        }

        [Benchmark]
        public void InsertRightElements()
        {
            var deque = new DequeImplementation<int>();
            for (int i = 0; i < ItemCount; i++)
            {
                deque.InsertRight(_randomNumbers[i]);
            }
        }

        [Benchmark]
        public void DeleteLeftElements()
        {
            var deque = new DequeImplementation<int>();
            for (int i = 0; i < ItemCount; i++)
            {
                deque.InsertRight(_randomNumbers[i]);
            }

            while (deque.Size() > 0)
            {
                deque.DeleteLeft();
            }
        }

        [Benchmark]
        public void DeleteRightElements()
        {
            var deque = new DequeImplementation<int>();
            for (int i = 0; i < ItemCount; i++)
            {
                deque.InsertLeft(_randomNumbers[i]);
            }

            while (deque.Size() > 0)
            {
                deque.DeleteRight();
            }
        }

        [Benchmark]
        public void MixedOperations()
        {
            var deque = new DequeImplementation<int>();
            for (int i = 0; i < ItemCount / 2; i++)
            {
                deque.InsertLeft(_randomNumbers[i]);
            }

            for (int i = ItemCount / 2; i < ItemCount; i++)
            {
                deque.InsertRight(_randomNumbers[i]);
            }

            while (deque.Size() > 0)
            {
                deque.DeleteLeft();
                if (deque.Size() > 0)
                {
                    deque.DeleteRight();
                }
            }
        }
    }
}