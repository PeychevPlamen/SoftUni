package carShop;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.Assert.assertEquals;

public class CarShopTests {

    private CarShop carShop;
    private static final Car car1 = new Car("BMW", 245, 40000);
    private static final Car car2 = new Car("VW", 145, 20000);
    private static final Car car3 = new Car("Audi", 245, 30000);

    @Before
    public void prepare() {
        carShop = new CarShop();
        carShop.add(car1);
        carShop.add(car2);
        carShop.add(car3);
    }

    @Test
    public void testConstructor() {
        CarShop carShop = new CarShop();
    }

    @Test
    public void testReturnCarCount() {
        List<Car> carList = new ArrayList<>();
        carList.add(car1);
        carList.add(car2);
        carList.add(car3);
        Assert.assertEquals(carList, carShop.getCars());
    }

    @Test
    public void testReturnCarList() {
        List<Car> carList = new ArrayList<>();
        carList.add(car1);
        carList.add(car2);
        carList.add(car3);
        Assert.assertEquals(carList.size(), carShop.getCars().size());
    }

    @Test
    public void testGetCarReturnCorrectCount() {
        Assert.assertEquals(3, carShop.getCount());
    }

    @Test
    public void testFindCarsWithMostHorsePower() {
        Assert.assertEquals(2, carShop.findAllCarsWithMaxHorsePower(240).size());

//        Car car2 = new Car("Car2", 10, 24);
//        Car car3 = new Car("Car3", 199, 24);
//        Car car4 = new Car("Car4", 192, 22);
//        carShop.add(car2);
//        carShop.add(car3);
//        carShop.add(car4);
//
//        List<Car> expectedCars = new ArrayList<>(Arrays.asList(car2, car3, car4));
//        List<Car> actualCars = carShop.findAllCarsWithMaxHorsePower(190);
//
//        assertEquals(expectedCars, actualCars);
    }

    @Test(expected = NullPointerException.class)
    public void testAddCarWithNullValue() {
        carShop.add(null);
    }

    @Test
    public void testRemoveCar() {
        carShop.remove(car3);
        Assert.assertEquals(2, carShop.getCount());
    }

    @Test
    public void testGetTheMostLuxuryCar() {
        Assert.assertEquals(car1, carShop.getTheMostLuxuryCar());
    }

    @Test
    public void testFindAllCarsByModel() {
        List<Car> carArrayList = new ArrayList<>();
        carArrayList.add(car1);
        Assert.assertEquals(carArrayList, carShop.findAllCarByModel("BMW"));
    }
}

