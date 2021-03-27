using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        ExtendedDatabase.Person person = new ExtendedDatabase.Person(11, "Pesho");

        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void TestConstructor_IfCountIsInCorrectRange()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            int expextedCount = 1;
            int currCount = extendedDatabase.Count;

            Assert.AreEqual(expextedCount, currCount);

        }

        [Test]
        public void Database_Count_Should_Be_Correct()
        {
            int expectedResult = 1;

            extendedDatabase.Add(person);

            Assert.AreEqual(expectedResult, extendedDatabase.Count);
        }

        [Test]
        public void TestIfCountIsOutOfRange_AndThrowException_IfTryToAdd()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new ExtendedDatabase.Person(i, $"Person{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person));

        }

        [Test]
        public void Test_If_Person_Already_Exists()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person));
        }

        [Test]
        public void Test_IfNameIsAlreadyExists_AndThrowException()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new ExtendedDatabase.Person(12, "Pesho")));
        }

        [Test]
        public void If_ThereIs_Allready_A_Person_With_Same_Id_ThrowException()
        {
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new ExtendedDatabase.Person(11, "Gosho")));
        }

        [Test]
        public void Test_If_DatabaseIsEmpty_TryToRemove_AndThrowAxception()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void Test_ArrayLenght_IsInRangeOf_16()
        {
            ExtendedDatabase.Person[] data = new ExtendedDatabase.Person[17];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new ExtendedDatabase.Person(i, $"person{i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase.ExtendedDatabase(data));
        }

        [Test]
        public void CheckUser_By_UserName()
        {
            extendedDatabase.Add(person);

            string expectedUserName = person.UserName;

            Assert.AreEqual(expectedUserName, person.UserName);
        }

        [Test]
        public void Check_User_By_Id()
        {
            extendedDatabase.Add(person);

            long expectedId = person.Id;

            Assert.AreEqual(expectedId, person.Id);
        }

        [Test]
        public void FindUser_By_UserName()
        {
            extendedDatabase.Add(person);

            var currName = extendedDatabase.FindByUsername("Pesho");

            Assert.AreEqual(person.UserName, currName.UserName);
        }

        [Test]
        [TestCase("Gosho")]
        public void If_UserByUserName_NotExist_ThrowException(string userName)
        {
            extendedDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername(userName));
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void FindUser_By_Id()
        {
            extendedDatabase.Add(person);

            var currId = extendedDatabase.FindById(11);

            Assert.AreEqual(person.Id, currId.Id);
        }

        [Test]
        [TestCase(12)]
        public void If_UserById_NotExistNumber_ThrowException(long id)
        {
            extendedDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(id));

        }

        [Test]
        [TestCase(-12)]
        public void If_UserById_IsNegativeNumber_ThrowException(long id)
        {
            extendedDatabase.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(id));

        }

        [Test]
        public void Ctor_AddAditionalPeople_ToDataBase()
        {

            ExtendedDatabase.Person[] data = new ExtendedDatabase.Person[7];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new ExtendedDatabase.Person(i, $"person{i}");
                extendedDatabase.Add(data[i]);
            }

            Assert.That(extendedDatabase.Count, Is.EqualTo(data.Length));
        }

        [Test]
        public void Remove_Method_Should_Decrease_Count()
        {
            extendedDatabase.Add(person);

            int expectedResult = 0;

            extendedDatabase.Remove();

            Assert.AreEqual(expectedResult, extendedDatabase.Count);
        }

        [Test]
        [TestCase(null)]
        public void FindByUsername_Should_Throw_Exception_If_Parameter_Is_Null(string name)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(name));

        }
    }
}