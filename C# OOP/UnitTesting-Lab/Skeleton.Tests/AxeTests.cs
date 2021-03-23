using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void Initialized()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        Dummy dummy = new Dummy(100, 100);

       InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()=> 
        {
            for (int i = 0; i < durability+1; i++)
            {
                axe.Attack(dummy);
            }
        });

        Assert.AreEqual(ex.Message, "Axe is broken.");
    }

    [Test]
    public void IsInitializedAxe()
    {
        Axe axe = new Axe(attack, durability);

        Assert.That(axe.AttackPoints, Is.EqualTo(attack));
        Assert.That(axe.DurabilityPoints, Is.EqualTo(durability));
    }

}