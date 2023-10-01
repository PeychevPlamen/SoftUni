import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class ProductShop_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        TreeMap<String, LinkedHashMap<String, Double>> shops = new TreeMap<>();

        while (!input.equals("Revision")) {

            String[] line = input.split(", ");
            String shop = line[0];
            String product = line[1];
            Double price = Double.parseDouble(line[2]);

            shops.putIfAbsent(shop, new LinkedHashMap<>());
            LinkedHashMap<String, Double> productData = shops.get(shop);
            productData.putIfAbsent(product, price);

            input = scanner.nextLine();
        }

        for (Map.Entry<String, LinkedHashMap<String, Double>> entry : shops.entrySet()) {
            System.out.println(entry.getKey() + "->");

            LinkedHashMap<String, Double> productData = entry.getValue();

            for (var product : productData.entrySet()) {
                System.out.printf("Product: %s, Price: %.1f%n", product.getKey(), product.getValue());
            }
        }
    }
}
