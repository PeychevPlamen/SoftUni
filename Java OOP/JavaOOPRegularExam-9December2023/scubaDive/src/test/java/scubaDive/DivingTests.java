package scubaDive;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;

public class DivingTests {

    private Arrays divers;

    @Test
    public void test_Constructor() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        Diving diving = new Diving("demo", 2);
        Collection<DeepWaterDiver> divers = new ArrayList<>();
    }

    @Test
    public void test_diversListSize() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        Diving diving = new Diving("demo", 2);
        Collection<DeepWaterDiver> divers = new ArrayList<>();
        divers.add(deepWaterDiver);
        Assert.assertEquals(1, divers.size());
    }

    @Test
    public void test_getCount() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        Diving diving = new Diving("demo", 2);

        diving.addDeepWaterDiver(deepWaterDiver);
        Assert.assertEquals(1, diving.getCount());
    }

    @Test
    public void test_getName() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        Diving diving = new Diving("demo", 2);

        diving.addDeepWaterDiver(deepWaterDiver);
        Assert.assertEquals("demo", diving.getName());
        Assert.assertEquals("pesho", deepWaterDiver.getName());
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_AddDeepWaterDiverNoMoreSpace() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        DeepWaterDiver deepWaterDiver2 = new DeepWaterDiver("pesho2", 7.5);
        DeepWaterDiver deepWaterDiver3 = new DeepWaterDiver("pesho3", 2);
        Diving diving = new Diving("demo", 2);

        diving.addDeepWaterDiver(deepWaterDiver);
        diving.addDeepWaterDiver(deepWaterDiver2);
        diving.addDeepWaterDiver(deepWaterDiver3);

    }

    @Test
    public void test_Remove() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        DeepWaterDiver deepWaterDiver2 = new DeepWaterDiver("pesho2", 7.5);
        DeepWaterDiver deepWaterDiver3 = new DeepWaterDiver("pesho3", 5.5);
        Diving diving = new Diving("demo", 2);

        diving.addDeepWaterDiver(deepWaterDiver);
        diving.addDeepWaterDiver(deepWaterDiver2);


        Assert.assertTrue(diving.removeDeepWaterDiver("pesho"));
        Assert.assertEquals(1, diving.getCount());

    }

    @Test(expected = IllegalArgumentException.class)
    public void test_setZeroCapacity() {
        Diving diving = new Diving("demo", -2);

    }

    @Test(expected = NullPointerException.class)
    public void test_setNameInvalid() {
        Diving diving = new Diving(null, 2);
        Diving diving2 = new Diving("     ", 2);

    }

    @Test
    public void test_getOxygen() {
        DeepWaterDiver deepWaterDiver = new DeepWaterDiver("pesho", 5.5);
        double getOxygen = deepWaterDiver.getOxygen();

    }
}
