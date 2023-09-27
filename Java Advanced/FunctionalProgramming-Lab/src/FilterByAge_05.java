import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Consumer;
import java.util.function.Predicate;

public class FilterByAge_05 {

    public static class Person {
        String name;
        int age;
    }

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        List<Person> people = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = scanner.nextLine().split(", ");

            String name = tokens[0];
            int age = Integer.parseInt(tokens[1]);

            Person person = new Person();
            person.name = name;
            person.age = age;
            people.add(person);
        }
        String condition = scanner.nextLine();
        int age = Integer.parseInt(scanner.nextLine());
        String format = scanner.nextLine();

        Predicate<Person> filter = createFilter(condition, age);
        Consumer<Person> printer = createPrinter(format);

        people.stream()
                .filter(filter)
                .forEach(printer);
    }

    private static Consumer<Person> createPrinter(String format) {
        if (format.equals("name")) {
            return person -> System.out.println(person.name);
        } else if (format.equals("age")) {
            return person -> System.out.println(person.age);
        }
        return person -> System.out.println(person.name + " - " + person.age);
    }

    private static Predicate<Person> createFilter(String condition, int age) {
        if (condition.equals("younger")) {
            return person -> person.age <= age;
        }
        return person -> person.age >= age;
    }
}
