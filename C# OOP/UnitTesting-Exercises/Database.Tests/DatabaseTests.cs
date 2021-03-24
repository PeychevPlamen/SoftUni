using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database = new Database.Database();

        [SetUp]
        public void Setup()
        {

            database = new Database.Database();

        }

        [Test]
        public void Is_TestConstructor_Works()
        {
            int[] data = new int[3];

            database = new Database.Database(data);

            int expectedDataCount = database.Count;
            int currDataCount = data.Length;

            Assert.AreEqual(expectedDataCount, currDataCount);

        }

        [Test]
        public void Add_TrowExeption_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_ShouldIncreaseCount_WhenAddedSuccessfully()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(n, database.Count);
        }

        [Test]
        public void Remove_ShouldDecreaseCount_WhenSuccess()
        {
            int[] data = new int[6];

            database = new Database.Database(data);

            database.Remove();

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]

        public void ThrowExepcion_WhenDatabaseCountIsNull()
        {
            int[] data = new int[1];

            database = new Database.Database(data);
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 23, 5667, 22, 45, 6, 5 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            database = new Database.Database(expectedData);

            int[] currData = database.Fetch();

            Assert.AreEqual(expectedData, currData);
        }
    }
}