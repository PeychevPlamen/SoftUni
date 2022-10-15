import java.util.Scanner;

public class TrainTheTrainers_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int jury = Integer.parseInt(scanner.nextLine());
        String presentation = scanner.nextLine();

        double totalGrades = 0;
        double tempGrade = 0;
        int counter = 0;

        while (!presentation.equals("Finish")) {

            for (int i = 0; i < jury; i++) {

                double grade = Double.parseDouble(scanner.nextLine());
                tempGrade += grade;
                counter++;
            }

            System.out.printf("%s - %.2f.%n", presentation, tempGrade / jury);

            totalGrades += tempGrade;
            tempGrade = 0;
            presentation = scanner.nextLine();
        }
        System.out.printf("Student's final assessment is %.2f.", totalGrades / counter);
    }
}
