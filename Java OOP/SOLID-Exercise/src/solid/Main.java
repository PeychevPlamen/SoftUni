package solid;

import java.util.List;

public class Main {

    public static void main(String[] args) {
        Cloud cloud = new Cloud();
        System.out.println(QuantityCalculator.average(List.of(cloud)));
    }
}
