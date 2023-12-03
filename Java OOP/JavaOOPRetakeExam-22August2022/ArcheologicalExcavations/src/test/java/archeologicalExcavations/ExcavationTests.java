package archeologicalExcavations;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Collection;

public class ExcavationTests {

    @Before
    public void setUp() {
        Excavation excavation = new Excavation("demo", 1);
    }

    @Test
    public void test_ConstructorCreateObject() {
        Excavation excavation = new Excavation("demo", 1);
    }

    @Test
    public void test_CountOFList() {
        Collection<Archaeologist> archaeologists = new ArrayList<>();
        Archaeologist archaeologist = new Archaeologist("demo", 1);
        archaeologists.add(archaeologist);
        Assert.assertEquals(1, archaeologists.size());
    }

    @Test
    public void test_ArcheologistGetName() {

        Archaeologist archaeologist = new Archaeologist("demo", 1);

        Assert.assertEquals("demo", archaeologist.getName());
    }

    @Test
    public void test_ExcavationGetName() {
        Excavation excavation = new Excavation("demo", 1);

        Assert.assertEquals("demo", excavation.getName());
    }

    @Test(expected = NullPointerException.class)
    public void test_ExcavationGetNameWithNullAndEmptySpace() {
        Excavation excavation = new Excavation("  ", 1);
        Excavation excavation1 = new Excavation(null, 1);

    }

    @Test
    public void test_ExcavationGetCapacity() {
        Excavation excavation = new Excavation("demo", 1);

        Assert.assertEquals(1, excavation.getCapacity());
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_ExcavationSetCapacityWithNegativeNumber() {
        Excavation excavation = new Excavation("demo", -1);
    }

    @Test
    public void test_ExcavationGetCount() {
        Excavation excavation = new Excavation("demo", 1);
        Archaeologist archaeologist = new Archaeologist("demo", 1);
        excavation.addArchaeologist(archaeologist);
        Assert.assertEquals(1, excavation.getCount());
    }

    @Test(expected = IllegalArgumentException.class)
    public void test_ExcavationAddArcheologistThrowException() {
        Excavation excavation = new Excavation("demo", 1);
        Archaeologist archaeologist = new Archaeologist("demo", 1);
        Archaeologist archaeologist2 = new Archaeologist("demo2", 2);
        excavation.addArchaeologist(archaeologist);
        excavation.addArchaeologist(archaeologist2);

    }

    @Test(expected = IllegalArgumentException.class)
    public void test_ExcavationAddArcheologistThrowExceptionAlreadyExist() {
        Excavation excavation = new Excavation("demo", 2);
        Archaeologist archaeologist = new Archaeologist("demo", 1);
        Archaeologist archaeologist2 = new Archaeologist("demo", 2);
        excavation.addArchaeologist(archaeologist);
        excavation.addArchaeologist(archaeologist2);
    }

    @Test
    public void test_RemoveArcheologist() {
        Excavation excavation = new Excavation("demo", 2);
        Archaeologist archaeologist = new Archaeologist("demo", 1);
        Archaeologist archaeologist2 = new Archaeologist("demo2", 2);
        excavation.addArchaeologist(archaeologist);
        excavation.addArchaeologist(archaeologist2);
        excavation.removeArchaeologist("demo2");
        Assert.assertEquals(1, excavation.getCount());
    }
}
