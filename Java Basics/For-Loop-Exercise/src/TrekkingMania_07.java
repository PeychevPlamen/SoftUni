import java.util.Scanner;

public class TrekkingMania_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int groupCount = Integer.parseInt(scanner.nextLine());
        int musala = 0;
        int monblan = 0;
        int kalimandjaro = 0;
        int k2 = 0;
        int everest = 0;
        int total = 0;

        for (int i = 0; i < groupCount; i++) {
            int peopleCount = Integer.parseInt(scanner.nextLine());
            if (peopleCount <= 5) {
                musala += peopleCount;
                total += peopleCount;
            } else if (peopleCount <= 12) {
                monblan += peopleCount;
                total += peopleCount;
            } else if (peopleCount <= 25) {
                kalimandjaro += peopleCount;
                total += peopleCount;
            } else if (peopleCount <= 40) {
                k2 += peopleCount;
                total += peopleCount;
            } else {
                everest += peopleCount;
                total += peopleCount;
            }
        }
        System.out.printf("%.2f%%%n", 1.0 * musala / total * 100);
        System.out.printf("%.2f%%%n", 1.0 * monblan / total * 100);
        System.out.printf("%.2f%%%n", 1.0 * kalimandjaro / total * 100);
        System.out.printf("%.2f%%%n", 1.0 * k2 / total * 100);
        System.out.printf("%.2f%%%n", 1.0 * everest / total * 100);

    }
}
