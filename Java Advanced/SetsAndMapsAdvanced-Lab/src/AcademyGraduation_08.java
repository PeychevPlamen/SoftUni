import java.text.DecimalFormat;
import java.util.*;
import java.util.stream.Collectors;

public class AcademyGraduation_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int numOfStudents = Integer.parseInt(scanner.nextLine());

        TreeMap<String, Double[]> graduationList = new TreeMap<>();

        for (int i = 0; i < numOfStudents; i++) {

            String name = scanner.nextLine();
            String[] scoresString = scanner.nextLine().split("\\s+");
            Double[] scores = new Double[scoresString.length];

            for (int j = 0; j < scoresString.length; j++) {
                scores[j] = Double.parseDouble(scoresString[j]);
            }
            graduationList.put(name, scores);
        }

        for (String name : graduationList.keySet()) {

            Double averageGrade = Arrays.stream(graduationList.get(name))
                    .mapToDouble(Double::valueOf)
                    .summaryStatistics().getAverage();

            System.out.println(name + " is graduated with " + averageGrade);
        }
    }
}
