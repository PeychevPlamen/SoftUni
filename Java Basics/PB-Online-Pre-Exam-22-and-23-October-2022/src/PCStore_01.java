import java.util.Scanner;

public class PCStore_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double priceCPU = Double.parseDouble(scanner.nextLine());
        double priceVGA = Double.parseDouble(scanner.nextLine());
        double priceRAM = Double.parseDouble(scanner.nextLine());
        int countRAM = Integer.parseInt(scanner.nextLine());
        double discountPercent = Double.parseDouble(scanner.nextLine());

        double usd = 1.57;

        double cpuInBgn = priceCPU * usd;
        double vgaInBgn = priceVGA * usd;
        double ramInBgn = priceRAM * usd;

        double totalRamPrice = ramInBgn * countRAM;
        double totalCpuPrice = cpuInBgn - cpuInBgn * discountPercent;
        double totalVgaPrice = vgaInBgn - vgaInBgn * discountPercent;

        double total = totalCpuPrice + totalRamPrice + totalVgaPrice;

        System.out.printf("Money needed - %.2f leva.", total);
    }
}
