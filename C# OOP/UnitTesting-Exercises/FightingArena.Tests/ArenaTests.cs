using NUnit.Framework;
using FightingArena;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void CtorCheck_WhenWeCreatePrivateReadOnlyCollection()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void CtorCheckCountIsZero_WhenWeCreatePrivateReadOnlyCollection()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }
        [Test]
        public void CheckCountProperty_WhenWeAddToCollectionDifferentWarriors()
        {
            Warrior first = new Warrior("n1", 40, 40);
            Warrior second = new Warrior("n2", 50, 60);
            arena.Enroll(first);
            arena.Enroll(second);
            Assert.That(arena.Warriors.Count, Is.EqualTo(arena.Count));
        }
        [Test]
        public void CheckEnrollMethodWithSameWarriors_ShouldThrowException()
        {
            Warrior first = new Warrior("n1", 40, 40);
            arena.Enroll(first);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("n1", 40, 40)));
        }
        [Test]
        public void CheckFightMethodWithNullWarriors_ShouldThrowException()
        {
            Warrior first = new Warrior("notNull", 40, 40);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("n1", "n2"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(first.Name, "n2"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("n1", first.Name));
        }
        [Test]
        public void CheckFightMethodWith_ShouldAttackDefender()
        {
            Warrior attacker = new Warrior("n1", 40, 50);
            Warrior defender = new Warrior("n2", 40, 50);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.That(attacker.HP, Is.EqualTo(10));


        }
    }
}
