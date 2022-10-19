import java.util.Scanner;

public class BestPlayer_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();

        String bestPlayer = "";
        int tempGoals = 0;
        boolean hatTrick = false;

        while (!name.equals("END")){

            int goals = Integer.parseInt(scanner.nextLine());

            if (goals > tempGoals){
                bestPlayer = name;
                tempGoals = goals;
            }
            if (goals >= 3){
                hatTrick = true;
            } else {
                hatTrick = false;
            }
            if (goals >= 10){
                break;
            }

            name = scanner.nextLine();
        }

        System.out.printf("%s is the best player!%n", bestPlayer);
        if (hatTrick){
            System.out.printf("He has scored %d goals and made a hat-trick !!!", tempGoals);
        } else {
            System.out.printf("He has scored %d goals.", tempGoals);
        }
    }
}
