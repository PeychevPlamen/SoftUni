using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private string name;
    private int experience;
    private Axe weapon;
    Hero hero;
    Dummy dummy;

    [SetUp]
    public void HeroInitilized()
    {
        hero = new Hero(name);
        dummy = new Dummy(20, 20);
    }

    [Test]
    public void IsHeroNameInitilizedCorrect()
    {
        Assert.AreEqual(hero.Name, name);
    }

    [Test]
    public void HeroReceiveExperienceAfterAttack()
    {
        Hero hero = new Hero("Pesho");
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);


        hero.Attack(dummy);

        var expectedExp = 10;

        Assert.AreEqual(expectedExp, hero.Experience, "Target is not dead.");
    }

}