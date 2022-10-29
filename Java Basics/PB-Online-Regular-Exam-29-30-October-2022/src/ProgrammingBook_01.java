import java.util.Scanner;

public class ProgrammingBook_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int pages = 899;
        int covers = 2;

        double pricePerPage = Double.parseDouble(scanner.nextLine());
        double pricePerOneCover = Double.parseDouble(scanner.nextLine());
        int percentDiscountPaper = Integer.parseInt(scanner.nextLine());
        double designerMoney = Double.parseDouble(scanner.nextLine());
        int totalPercentPay = Integer.parseInt(scanner.nextLine());

        double startPrice = pricePerPage * pages + pricePerOneCover * covers;

        double afterPrintDiscount = startPrice - startPrice * percentDiscountPaper / 100;
        double totalDesignerPay = afterPrintDiscount + designerMoney;

        double total = totalDesignerPay - totalDesignerPay * totalPercentPay / 100;

        System.out.printf("Avtonom should pay %.2f BGN.", total);
    }
}
