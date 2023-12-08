package gifts;


import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class GiftFactoryTests {

    @Test
    public void test_Constructor() {
        Gift gift = new Gift("gift", 5.5);
        GiftFactory giftFactory = new GiftFactory();
        Assert.assertEquals(0, giftFactory.getCount());
    }
    @Test
    public void test_CreateGift() {
        Gift gift = new Gift("gift", 5.5);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        Assert.assertEquals(1, giftFactory.getCount());
    }
    @Test (expected = IllegalArgumentException.class)
    public void test_CreateGiftSameName() {
        Gift gift = new Gift("gift", 5.5);
        Gift gift2 = new Gift("gift", 6);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        giftFactory.createGift(gift2);

    }
    @Test (expected = NullPointerException.class)
    public void test_RemoveGiftWithNullValue() {

        GiftFactory giftFactory = new GiftFactory();
       giftFactory.removeGift(null);

    }

    @Test
    public void test_RemoveGift() {
        Gift gift = new Gift("gift", 5.5);
        Gift gift2 = new Gift("gift2", 6);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        giftFactory.createGift(gift2);
        giftFactory.removeGift("gift2");
        Assert.assertEquals(1, giftFactory.getCount());

    }
    @Test
    public void test_getPResentWithLessMagic() {
        Gift gift = new Gift("gift", 5.5);
        Gift gift2 = new Gift("gift2", 6);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        giftFactory.createGift(gift2);
        Assert.assertEquals("gift", giftFactory.getPresentWithLeastMagic().getType());

    }
    @Test
    public void test_getPresentReturnGift() {
        Gift gift = new Gift("gift", 5.5);
        Gift gift2 = new Gift("gift2", 6);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        giftFactory.createGift(gift2);
        Assert.assertEquals(gift, giftFactory.getPresent("gift"));

    }
    @Test
    public void test_getPresentsList() {
        Gift gift = new Gift("gift", 5.5);
        Gift gift2 = new Gift("gift2", 6);
        GiftFactory giftFactory = new GiftFactory();
        giftFactory.createGift(gift);
        giftFactory.createGift(gift2);
        Assert.assertEquals(2, giftFactory.getPresents().size());

    }
}
