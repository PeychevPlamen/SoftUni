using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 10;
    private int exp = 10;
    Dummy dummy;

    [SetUp]
    public void DummyCreate()
    {
        dummy = new Dummy(health, exp);
    }
    [Test]
    public void LooseHealthIfAttack()
    {
        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(health - 5));
    }

    [Test]
    public void DeadDummyAttacked()
    {
        Dummy dummy = new Dummy(0, exp);

        Assert.That(() => dummy.TakeAttack(1), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void CanGiveXp()
    {
        Dummy dummy = new Dummy(0, 10);
        int experince = 0;

        experince = dummy.GiveExperience();

        Assert.That(experince, Is.EqualTo(10));
    }

    [Test]
    public void CanNotGiveXp()
    {

        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
    [Test]
    public void IsDummyDead()
    {
        Dummy dummy = new Dummy(0, exp);

        Assert.AreEqual(dummy.IsDead(), true);
    }
    [Test]
    public void IsDummyInitialized()
    {
        Assert.AreEqual(dummy.Health, health);
    }
}
