import java.util.Scanner;

public class SantasHoliday_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        String typeRoom = scanner.nextLine();
        String grade = scanner.nextLine();

        double total = 0;

        switch (typeRoom){
            case "room for one person":
                total = (days - 1) * 18;
                break;
            case  "apartment":
                if (days < 10){
                    total = 25 * (days - 1) * 0.7;
                } else if (days <= 15) {
                    total = 25 * (days - 1) * 0.65;
                } else  {
                    total = 25 * (days - 1) * 0.5;
                }
                break;
            case "president apartment":
                if (days < 10){
                    total = 35 * (days - 1) * 0.9;
                } else if (days <= 15) {
                    total = 35 * (days - 1) * 0.85;
                } else  {
                    total = 35 * (days - 1) * 0.8;
                }
                break;
        }
        if (grade.equals("positive")){
            total *= 1.25;
        } else {
            total *= 0.9;
        }

        System.out.printf("%.2f", total);
    }
}
