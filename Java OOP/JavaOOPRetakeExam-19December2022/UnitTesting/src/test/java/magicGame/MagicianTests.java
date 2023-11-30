package magicGame;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class MagicianTests {
    private Magician magician;
    private static final Magician magician1 = new Magician("Marilyn", 99);

    @Before
    public void prepare() {
        magician = new Magician("Joni", 15);
    }

    @Test
    public void testConstructor() {
        magician = new Magician("Joni", 15);
    }
    @Test
    public void testReturnCOrrectUsername() {
        Assert.assertEquals("Joni", magician.getUsername());
    }
    @Test (expected = NullPointerException.class)
    public void testSetUsernameWithNull() {
        magician = new Magician(null, 25);
    }
    @Test (expected = NullPointerException.class)
    public void testSetUsernameWithWhiteSpice() {
        magician = new Magician("  ", 25);
    }
    @Test
    public void testReturnHealth() {
        Assert.assertEquals(15, magician.getHealth());
    }
    @Test (expected = IllegalArgumentException.class)
    public void testSetHealthBellowZero() {
        magician = new Magician("Joni", -25);
    }
    @Test
    public void testGetMagicList() {
        Magic magic = new Magic("fire", 10);
        magician.addMagic(magic);
        Assert.assertEquals(1, magician.getMagics().size());
    }
    @Test(expected = IllegalStateException.class)
    public void testGetDamageWithMoreBullets() {
        Magician magician = new Magician("Pesho", 0);
        magician.takeDamage(10);

    }
    @Test
    public void testTakeDamageShouldWork(){
        Magician magician = new Magician("Pesho", 50);
        magician.takeDamage(5);

        Assert.assertEquals(45, magician.getHealth());
    }
    @Test
    public void testTakeDamageShouldWorkZero(){
        Magician magician = new Magician("Pesho", 50);
        magician.takeDamage(55);

        Assert.assertEquals(0, magician.getHealth());
    }
    @Test(expected = NullPointerException.class)
    public void testGAddMagicWithNull() {
        magician.addMagic(null);

    }
    @Test
    public void testGAddMagicWith() {
        Magic magic = new Magic("fire", 10);
        magician.addMagic(magic);

    }
    @Test
    public void testRemoveMagic() {
        Magic magic = new Magic("fire", 10);
        magician.addMagic(magic);
        magician.removeMagic(magic);
        Assert.assertEquals(0, magician.getMagics().size());

    }
    @Test
    public void testGetMagic() {
        Magic magic = new Magic("fire", 10);
        magician.addMagic(magic);

        Assert.assertEquals(magic, magician.getMagic("fire"));

    }
    @Test
    public void testGetBullets() {
        Magic magic = new Magic("fire", 10);

        Assert.assertEquals(10, magic.getBullets());

    }
}
