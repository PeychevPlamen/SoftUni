import java.util.Scanner;

public class Repainting_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double safetyCoverPricePerMeter = 1.50;
        Double paintPricePerLtr = 14.50;
        Double paintLiquidPerLtrPrice = 5.00;

        int safetyCover = Integer.parseInt(scanner.nextLine());
        int paint = Integer.parseInt(scanner.nextLine());
        Integer paintLiquid = Integer.parseInt(scanner.nextLine());
        int hours = Integer.parseInt(scanner.nextLine());

        Integer safetyCoverExtra = safetyCover + 2;
        Double safetyPaint = paint * 1.1;
        double bags = 0.4;

        double totalPriceForMaterials = safetyCoverPricePerMeter * safetyCoverExtra
                + paintPricePerLtr * safetyPaint
                + paintLiquidPerLtrPrice * paintLiquid
                + bags;

        double workersPriceTotal = (totalPriceForMaterials * 0.3) * hours;
        Double total = workersPriceTotal + totalPriceForMaterials;

        System.out.printf("%.2f", total);
    }
}
