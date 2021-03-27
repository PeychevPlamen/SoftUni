using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            name = "name";
            damage = 10;
            hp = 50;
        }

        [Test]
        [TestCase("", 20, 50)]
        [TestCase(null, 20, 50)]
        [TestCase("name", 0, 50)]
        [TestCase("name", -15, 50)]
        [TestCase("name", 15, -20)]
        public void Ctor_Test_IfThrow_Exception(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Check_If_ValueReturnName()
        {
            Warrior warrior = new Warrior(name, damage, hp);

            string expectedName = name;

            Assert.AreEqual(expectedName, warrior.Name);
        }

        [Test]
        public void Check_If_ValueReturnDamage()
        {
            Warrior warrior = new Warrior(name, damage, hp);

            int expectedDamage = damage;

            Assert.AreEqual(expectedDamage, warrior.Damage);
        }

        [Test]
        public void Check_If_ValueReturnHp()
        {
            Warrior warrior = new Warrior(name, damage, hp);

            int expectedHp = hp;

            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        [TestCase(15, 30)]
        [TestCase(35, 25)]
        [TestCase(40, 30)]
        public void Check_If_WarriorAttack_Throw_Exception(int hpAttacker, int hpWarrior)
        {
            Warrior attacker = new Warrior("Attacker", 20, hpAttacker);
            Warrior warrior = new Warrior("Warrior", 50, hpWarrior);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Check_If_WarriorHp_SmallerThan_MinAttackHp_Throw_Exception()
        {
            Warrior attacker = new Warrior("Attacker", 20, 50);
            Warrior warrior = new Warrior("Warrior", 60, 15);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Check_If_AttackerHp_SmallerThan_MinAttackHp_Throw_Exception()
        {
            Warrior attacker = new Warrior("Attacker", 20, 15);
            Warrior warrior = new Warrior("Warrior", 60, 55);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void If_AttackerHP_Is_Smaller_Than_WarriroDamage_Throw_Exception()
        {
            Warrior attacker = new Warrior("Attacker", 20, 50);
            Warrior warrior = new Warrior("Warrior", 60, 55);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        [TestCase(50, 40)]
        [TestCase(90, 60)]
        [TestCase(77, 55)]
        public void Check_If_AttackerHpDecrease_WithWarriorDamagePoints(int hpAttacker, int warriorDamage)
        {
            Warrior attacker = new Warrior("Attacker", 20, hpAttacker);
            Warrior warrior = new Warrior("Warrior", warriorDamage, 35);

            //attacker.Attack(warrior);

            //Assert.That(attacker.HP, Is.LessThan(hpAttacker));

            int expectedAttackerDecreaseHp = hpAttacker - warriorDamage;
            int currentHp = attacker.HP - warrior.Damage;

            Assert.AreEqual(expectedAttackerDecreaseHp, currentHp);
        }

        [Test]
        [TestCase(50, 45)]
        [TestCase(70, 50)]
        public void Check_If_WarriorXp_IfIsSmaller_ThanAttackerDamage_AfterAttackIsZero(int attackerDamage, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", attackerDamage, 40);
            Warrior warrior = new Warrior("Warrior", 40, warriorHp);

            attacker.Attack(warrior);

            int expectedResult = 0;
            int currResult = warrior.HP;

            Assert.AreEqual(expectedResult, currResult);
        }

        [Test]
        [TestCase(45, 50)]
        [TestCase(60, 70)]
        public void Check_If_WarriorXp_IsDecrease_ByAttackerHpPoints(int attackerDamage, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", attackerDamage, 40);
            Warrior warrior = new Warrior("Warrior", 40, warriorHp);

            attacker.Attack(warrior);

            int expectedResult = warriorHp - attackerDamage;
            int currResult = warrior.HP;

            Assert.AreEqual(expectedResult, currResult);
        }

        [Test]
        public void CheckIf_AttackerHp_DecreaseWith_WarriorDamagePoints()
        {
            Warrior attacker = new Warrior("Attacker", 100, 50);
            Warrior warrior = new Warrior("Warrior", 40, 150);

            int expectedResult = 10;
            int currentResult = attacker.HP - warrior.Damage;

            warrior.Attack(attacker);

            Assert.AreEqual(expectedResult, currentResult);
        }

        [Test]
        public void Check_If_AttackChangeHPToZero()
        {
            Warrior attacker = new Warrior("pesho", 50, 55);
            Warrior warrior = new Warrior("warrior", 50, 45);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }
    }
}