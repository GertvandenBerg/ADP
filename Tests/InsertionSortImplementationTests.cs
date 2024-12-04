using adp;

namespace Tests
{
    public class InsertionSortImplementationTests
    {
        [Fact]
        public void InsertionSort_SortsIntegersInAscendingOrder()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { 9, 7, 5, 3, 1 };

            sorter.InsertionSort(array, (a, b) => a.CompareTo(b));

            Assert.Equal(new int[] { 1, 3, 5, 7, 9 }, array);
        }

        [Fact]
        public void InsertionSort_SortsIntegersInDescendingOrder()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { 1, 3, 5, 7, 9 };

            sorter.InsertionSort(array, (a, b) => b.CompareTo(a));

            Assert.Equal(new int[] { 9, 7, 5, 3, 1 }, array);
        }

        [Fact]
        public void InsertionSort_SortsStringArrayAlphabetically()
        {
            var sorter = new InsertionSortImplementation();
            string[] array = { "banana", "apple", "cherry", "date" };

            sorter.InsertionSort(array, (a, b) => string.Compare(a, b));

            Assert.Equal(new string[] { "apple", "banana", "cherry", "date" }, array);
        }

        [Fact]
        public void InsertionSort_SortsStringArrayInReverseAlphabeticalOrder()
        {
            var sorter = new InsertionSortImplementation();
            string[] array = { "banana", "apple", "cherry", "date" };

            sorter.InsertionSort(array, (a, b) => string.Compare(b, a));

            Assert.Equal(new string[] { "date", "cherry", "banana", "apple" }, array);
        }

        [Fact]
        public void InsertionSort_HandlesEmptyArray()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { };

            sorter.InsertionSort(array, (a, b) => a.CompareTo(b));

            Assert.Empty(array);
        }

        [Fact]
        public void InsertionSort_HandlesSingleElementArray()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { 42 };

            sorter.InsertionSort(array, (a, b) => a.CompareTo(b));

            Assert.Equal(new int[] { 42 }, array);
        }

        [Fact]
        public void InsertionSort_HandlesAlreadySortedArray()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { 1, 2, 3, 4, 5 };

            sorter.InsertionSort(array, (a, b) => a.CompareTo(b));

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Fact]
        public void InsertionSort_HandlesReverseSortedArray()
        {
            var sorter = new InsertionSortImplementation();
            int[] array = { 5, 4, 3, 2, 1 };

            sorter.InsertionSort(array, (a, b) => a.CompareTo(b));

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Fact]
        public void InsertionSort_SortsCustomObjects()
        {
            var sorter = new InsertionSortImplementation();
            var people = new[]
            {
                new Person { Name = "John", Age = 25 },
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 20 }
            };

            sorter.InsertionSort(people, (a, b) => a.Age.CompareTo(b.Age));

            Assert.Equal("Bob", people[0].Name);
            Assert.Equal("John", people[1].Name);
            Assert.Equal("Alice", people[2].Name);
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
