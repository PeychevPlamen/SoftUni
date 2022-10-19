import java.util.Scanner;

public class AgencyProfit_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();
        int adultTickets = Integer.parseInt(scanner.nextLine());
        int kidsTickets = Integer.parseInt(scanner.nextLine());
        double priceAdult = Double.parseDouble(scanner.nextLine());
        double taxes = Double.parseDouble(scanner.nextLine());

        double priceKids = priceAdult * 0.3;
        double totalKidPrice = priceKids + taxes;
        double totalAdultPrice = priceAdult + taxes;

        double total = adultTickets * totalAdultPrice + kidsTickets * totalKidPrice;
        double profit = total * 0.2;

        System.out.printf("The profit of your agency from %s tickets is %.2f lv.",name, profit);

    }
}
