using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault collection = new BankVault();

        Item item = new Item("aaa", "bbb");


        [SetUp]
        public void Setup()
        {
            // collection = new BankVault()
        }

        [Test]
        public void ThrowException_If_TryToAddItemInCollection_If_CellNotExist()
        {
            Assert.Throws<ArgumentException>(() => collection.AddItem("a1", item));
        }
        [Test]
        public void ThrowException_If_CellIsAllreadyTaken()
        {
            collection.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => collection.AddItem("A1", new Item("ccc", "xxx")));
        }

        [Test]
        public void CheckIf_CellExist_ThrowException()
        {

           // collection.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => collection.AddItem("A2", item));
        }

        [Test]
        public void AddItemInCollection()
        {
            string expectedResult = collection.AddItem("A1", item);

            Assert.AreEqual(expectedResult, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItem_ThrowException_WhenItemNotExist()
        {
            //collection.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => collection.RemoveItem("A1", new Item("ccc", "xxx")));
        }

        [Test]
        public void RemoveItem_ThrowException_WhenCellNotExist()
        {
            Assert.Throws<ArgumentException>(() => collection.RemoveItem("A", item));
        }

        [Test]
        public void RemoItem_Successffuly()
        {
           // collection.AddItem("A1", item);

            string expectedResult = collection.RemoveItem("A1", item);

            Assert.AreEqual(expectedResult, $"Remove item:{item.ItemId} successfully!");
        }

        [Test]
        public void TestDictionaryCount()
        {
            
            Assert.That(collection.VaultCells.Count, Is.EqualTo(12));
        }
    }
}