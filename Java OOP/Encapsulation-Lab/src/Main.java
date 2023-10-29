import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

public class Main {
    public static void main(String[] args) throws IOException {
        // task 1
//        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
//        int n = Integer.parseInt(reader.readLine());
//
//        List<Person> people = new ArrayList<>();
//
//        for (int i = 0; i < n; i++) {
//            String[] input = reader.readLine().split(" ");
//            people.add(new Person(input[0], input[1], Integer.parseInt(input[2])));
//        }
//
//        Collections.sort(people, (firstPerson, secondPerson) -> {
//            int sComp = firstPerson.getFirstName().compareTo(secondPerson.getFirstName());
//
//            if (sComp != 0) {
//                return sComp;
//            } else {
//                return Integer.compare(firstPerson.getAge(), secondPerson.getAge());
//            }
//        });
//
//        for (Person person : people) {
//            System.out.println(person.toString());
//        }

        // task 2
//        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
//        int n = Integer.parseInt(reader.readLine());
//        List<Person> people = new ArrayList<>();
//        for (int i = 0; i < n; i++) {
//            String[] input = reader.readLine().split(" ");
//            people.add(new Person(input[0], input[1], Integer.parseInt(input[2]), Double.parseDouble(input[3])));
//        }
//        double bonus = Double.parseDouble(reader.readLine());
//        for (Person person : people) {
//            person.increaseSalary(bonus);
//            System.out.println(person.toString());
//        }

        // task 3
//        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
//        int n = Integer.parseInt(reader.readLine());
//        List<Person> people = new ArrayList<>();
//        for (int i = 0; i < n; i++) {
//            String[] input = reader.readLine().split(" ");
//
//            Optional<Person> person = Optional.empty();
//
//            try {
//                person = Optional.of(new Person(input[0], input[1], Integer.parseInt(input[2]), Double.parseDouble(input[3])));
//            } catch (IllegalArgumentException e) {
//                System.out.println(e.getMessage());
//            }
//
//            person.ifPresent(people::add);
//        }
//
//        double bonus = Double.parseDouble(reader.readLine());
//        for (Person person : people) {
//            person.increaseSalary(bonus);
//            System.out.println(person.toString());
//        }

        // TASK 4
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(reader.readLine());

        Team team = new Team("Black Eagles");

        for (int i = 0; i < n; i++) {
            String[] input = reader.readLine().split(" ");

            Optional<Person> person = Optional.empty();

            try {
                person = Optional.of(new Person(input[0], input[1], Integer.parseInt(input[2]), Double.parseDouble(input[3])));
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }

            person.ifPresent(team::addPlayer);
        }

        System.out.println("First team have " + team.getFirstTeam().size() + " players");
        System.out.println("Reserve team have " + team.getReserveTeam().size() + " players");

    }

}
