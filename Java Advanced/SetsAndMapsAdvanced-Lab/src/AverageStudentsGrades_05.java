import java.util.*;
import java.util.stream.Collectors;

public class AverageStudentsGrades_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int count = Integer.parseInt(scanner.nextLine());

        TreeMap<String, List<Double>> students = new TreeMap<>();

        for (int i = 0; i < count; i++) {
            String[] input = scanner.nextLine().split("\\s+");

            String name = input[0];
            double grade = Double.parseDouble(input[1]);

            if (students.containsKey(name)) {
                students.get(name).add(grade);
            } else {
                students.putIfAbsent(name, new ArrayList<>());
                students.get(name).add(grade);
            }

        }
        for (String name : students.keySet()) {

            List<Double> grades = new ArrayList<>(students.get(name));
            StringBuilder gradesOutput = new StringBuilder();
            for (Double grade: grades) {
                gradesOutput.append(String.format("%.2f", grade)).append(" ");
            }

            double averageGrade = grades.stream().mapToDouble(Double::valueOf).average().getAsDouble();
            //System.out.println(name + " -> " + gradesOutput + String.format("%s %.2f", "(avg:", averageGrade) + ")");
            System.out.printf("%s -> %s(avg: %.2f)\n", name, gradesOutput, averageGrade);
        }

    }
}
