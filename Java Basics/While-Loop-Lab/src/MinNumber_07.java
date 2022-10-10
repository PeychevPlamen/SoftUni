import java.util.Scanner;

public class MinNumber_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        int minNum = Integer.MAX_VALUE;

        while (!input.equals("Stop")){

            int num = Integer.parseInt(input);

            if (minNum > num){
                minNum = num;
            }

            input = scanner.nextLine();
        }
        System.out.println(minNum);
    }
}
