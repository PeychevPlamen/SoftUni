package robots;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class ServiceTests {
    private Service service;
    private static final Robot robot = new Robot("Harry");

    @Before
    public void prepareService() {
        service = new Service("Softuni", 2);
        service.add(robot);
    }

    @Test
    public void testConstructorCreateObject() {
        Assert.assertEquals("Softuni", service.getName());
        Assert.assertEquals(2, service.getCapacity());
    }

    @Test(expected = NullPointerException.class)
    public void testSetNameWithNull() {
        service = new Service(null, 2);
    }

    @Test(expected = NullPointerException.class)
    public void testSetNameWithEmptyString() {
        service = new Service("     ", 2);
    }

    @Test
    public void testGetNameReturnCorrectName() {
        Assert.assertEquals("Softuni", service.getName());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testCapacityWithNegativeNumber() {
        service = new Service("Softuni", -2);
    }

    @Test
    public void testReturnCorrectCount() {
        Assert.assertEquals(1, service.getCount());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testAddPlayerInFullTeam() {
        Robot robot1 = new Robot("Joni");
        service.add(robot1);
        Robot robot2 = new Robot("Joni2");
        service.add(robot2);
    }

    @Test
    public void testRemoveRobot() {
        service.remove("Harry");
        Assert.assertEquals(0, service.getCount());
    }

    @Test(expected = IllegalArgumentException.class)
    public void testRemoveNoExistRobot() {
        service.remove("Toni");
    }

    @Test
    public void testRobotForSale() {
        service.forSale("Harry");
        Assert.assertFalse(robot.isReadyForSale());

    }

    @Test(expected = IllegalArgumentException.class)
    public void testRobotForSaleThrowException() {
        service.forSale("Toni");
    }

    @Test
    public void testReportReturnCorrectMessage() {
        service.report().equals("The robot Harry is in the service Softuni!");
    }
}
