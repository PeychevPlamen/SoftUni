import java.util.Scanner;

public class Walking_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        int steps = 0;
        boolean goalReached = false;

        while (!input.equals("Going home")) {

            steps += Integer.parseInt(input);

            if (steps >= 10000) {
                goalReached = true;
                break;
            }

            input = scanner.nextLine();
        }
        if (input.equals("Going home")){
            steps += Integer.parseInt(scanner.nextLine());
            if (steps >= 10000){
                System.out.printf("Goal reached! Good job!%n%d steps over the goal!", steps - 10000);
            }else {
                System.out.printf("%d more steps to reach goal.", Math.abs(steps - 10000));
            }
        }
        if (goalReached){
            System.out.printf("Goal reached! Good job!%n%d steps over the goal!", steps - 10000);
        }
    }
}
