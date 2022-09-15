import java.util.Scanner;

public class FishTank_09 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Integer a = Integer.parseInt(scanner.nextLine());
        Integer b = Integer.parseInt(scanner.nextLine());
        Integer h = Integer.parseInt(scanner.nextLine());
        double percent = Double.parseDouble(scanner.nextLine());

        double totalAquariumSpaceInLtr = (a * b * h) * 0.001;

        Double realSpaceLtr = totalAquariumSpaceInLtr * (1 - percent / 100);

        System.out.println(realSpaceLtr);
    }
}
