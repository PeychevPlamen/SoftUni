package toyStore;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import javax.naming.OperationNotSupportedException;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Objects;

public class ToyStoryTest {

    private static final Toy toy = new Toy("pixar", "1");
    private ToyStore toyStore;

    @Before
    public void Prepare() {
        Toy toy = new Toy("pixar", "1");
        toyStore = new ToyStore();
    }
    @Test
    public void getVaultCells() {
        Map<String, Toy> toyShelf;
        toyShelf = new LinkedHashMap<>();
        toyShelf.put("A", null);
        toyShelf.put("B", null);
        toyShelf.put("C", null);
        toyShelf.put("D", null);
        toyShelf.put("E", null);
        toyShelf.put("F", null);
        toyShelf.put("G", null);
        Assert.assertEquals(toyShelf, toyStore.getToyShelf());

    }
    @Test
    public void test_CreateToy() {
        Toy toy1 = new Toy("demo", "2");
    }

    @Test
    public void test_returnCorrectManufacture() {
        Assert.assertEquals("pixar", toy.getManufacturer());
    }

    @Test
    public void test_returnCorrectId() {
        Assert.assertEquals("1", toy.getToyId());
    }

    @Test
    public void test_addToy() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_addToyTrowError() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy(null, toy);
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_addToyWithAlreadyTakenShelf() throws OperationNotSupportedException {
        Toy toy2 = new Toy("demo", "2");
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
        toyStore.addToy("A", toy2);
    }

    @Test(expected = OperationNotSupportedException.class)
    public void test_addToyWithAlreadyHave() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
        toyStore.addToy("B", toy);
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_removeShelfNotExist() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
        toyStore.removeToy("B", toy);
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_removeToyNotExist() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        Toy toy2 = new Toy("demo", "2");
        toyStore.addToy("A", toy);
        toyStore.removeToy("A", toy2);
    }

    @Test
    public void test_removeSuccess() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
        toyStore.removeToy("A", toy);
    }
    @Test (expected = IllegalArgumentException.class)
    public void test_removeShelfNotExistWithNull() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        toyStore.addToy("A", toy);
        toyStore.removeToy(null, toy);
    }
    @Test
    public void test_returnCount() throws OperationNotSupportedException {
        ToyStore toyStore = new ToyStore();
        Assert.assertEquals(7, toyStore.getToyShelf().size());
    }
    @Test
    public void removeToyReturnCorrectString() throws OperationNotSupportedException {
        Toy i = new Toy("TestOwner", "TestItem");
        Toy i2 = new Toy("TestOwner", "TestItem2");
        toyStore.addToy("A", i);
        toyStore.addToy("B", i2);
        String result =  toyStore.removeToy("B", i2);
        long exist = toyStore.getToyShelf().values().stream().filter(Objects::nonNull).count();
        Assert.assertEquals(1, exist);
        Assert.assertEquals("Remove toy:TestItem2 successfully!", result);
    }

}