import java.util.Scanner;

public class SuppliesForSchool_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double pensBox = 5.80;
        Double markersBox = 7.20;
        Double liquidPerLtr = 1.20;

        Integer boxesOfPens = Integer.parseInt(scanner.nextLine());
        Integer boxesOfMarkers = Integer.parseInt(scanner.nextLine());
        Integer liquidNeeded = Integer.parseInt(scanner.nextLine());
        double discountPercent = Double.parseDouble(scanner.nextLine());

        Double pensPriceTotal = pensBox * boxesOfPens;
        Double markersPriceTotal = markersBox * boxesOfMarkers;
        Double liquidPriceTotal = liquidPerLtr * liquidNeeded;

        double totalStaffPrice = pensPriceTotal + markersPriceTotal + liquidPriceTotal;
        Double total = totalStaffPrice - (totalStaffPrice * discountPercent / 100);

        System.out.println(total);
    }
}
