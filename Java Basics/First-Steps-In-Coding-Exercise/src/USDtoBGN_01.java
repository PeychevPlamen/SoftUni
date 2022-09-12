import java.util.Scanner;

public class USDtoBGN_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double usdPrice = 1.79549;
        Double usd = Double.parseDouble(scanner.nextLine());
        Double bgnPrice = usdPrice * usd;

        System.out.println(bgnPrice);

    }
}
