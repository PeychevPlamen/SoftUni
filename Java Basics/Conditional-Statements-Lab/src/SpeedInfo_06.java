import java.util.Scanner;

public class SpeedInfo_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double input = Double.parseDouble(scanner.nextLine());
        String output = "";

        if (input <= 10) {
            output = "slow";
        } else if (input > 10 && input <= 50) {
            output = "average";
        } else if (input > 50 && input <= 150) {
            output = "fast";
        } else if (input > 150 && input <= 1000) {
            output = "ultra fast";
        } else {
            output = "extremely fast";
        }
        System.out.println(output);
    }
}
