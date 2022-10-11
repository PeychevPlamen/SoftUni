import java.util.Scanner;

public class ExamPreparation_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int poorGrades = Integer.parseInt(scanner.nextLine());
        String input = scanner.nextLine();
        int numProblems = 0;
        double averageGrade = 0;
        int countPoorGrade = 0;
        boolean isFinished = false;
        String lastProblem = "";

        while (!input.equals("Enough")) {
            int grade = Integer.parseInt(scanner.nextLine());
            if (grade <= 4) {
                countPoorGrade++;
            }
            if (poorGrades <= countPoorGrade) {
                isFinished = true;
                break;
            }
            averageGrade += grade;
            numProblems++;
            lastProblem = input;
            input = scanner.nextLine();

        }
        if (isFinished) {
            System.out.printf("You need a break, %d poor grades.", countPoorGrade);
        } else {
            System.out.printf("Average score: %.2f%n" +
                    "Number of problems: %d%n" +
                    "Last problem: %s", averageGrade / numProblems, numProblems, lastProblem);
        }
    }
}
