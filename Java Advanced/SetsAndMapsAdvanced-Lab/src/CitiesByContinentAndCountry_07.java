import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Scanner;

public class CitiesByContinentAndCountry_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int lines = Integer.parseInt(scanner.nextLine());

        LinkedHashMap<String, LinkedHashMap<String, List<String>>> output = new LinkedHashMap<>();

        for (int i = 0; i < lines; i++) {

            String[] input = scanner.nextLine().split("\\s+");
            String continent = input[0];
            String country = input[1];
            String city = input[2];

            output.putIfAbsent(continent, new LinkedHashMap<>());

            LinkedHashMap<String, List<String>> citiesByCountry = output.get(continent);
            citiesByCountry.putIfAbsent(country, new ArrayList<>());

            List<String> cities = citiesByCountry.get(country);
            cities.add(city);
        }

        output.forEach((continent, countries) -> {
            System.out.println(continent + ":");

            countries.forEach((country, cities) -> {

                String joinedCities = String.join(", ", cities);

                System.out.println("  " + country + " -> " + joinedCities);
            });
        });
    }
}
