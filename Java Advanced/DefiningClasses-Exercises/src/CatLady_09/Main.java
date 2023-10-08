package CatLady_09;

import java.util.*;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        Map<String, Cat> cats = new HashMap<>();

        while (!input.equals("End")) {
            String[] tokens = input.split("\\s+");
            String breed = tokens[0];
            String name = tokens[1];

            Cat cat = null;

            if (breed.equals("Cymric")) {
                double furLength = Double.parseDouble(tokens[2]);
                cat = new Cymric(breed, name, furLength);
            } else if (breed.equals("Siamese")) {
                double earSize = Double.parseDouble(tokens[2]);
                cat = new Siamese(breed, name, earSize);
            } else if (breed.equals("StreetExtraordinaire")) {
                double decibelsOfMeows = Double.parseDouble(tokens[2]);
                cat = new StreetExtraordinaire(breed, name, decibelsOfMeows);
            }
            cats.putIfAbsent(name, cat);

            input = scanner.nextLine();
        }
        String searchedName = scanner.nextLine();
        System.out.println(cats.get(searchedName));
    }
}
