import java.util.Scanner;

public class CinemaTickets_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String movieName = scanner.nextLine();

        int totalTickets = 0;
        double totalStudentTickets =0;
        double totalStandardTickets = 0;
        double totalKidsTickets = 0;

        while (!movieName.equals("Finish")) {

            int freeSeats = Integer.parseInt(scanner.nextLine());
            int currMovieTickets = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;

            for (int i = 0; i < freeSeats; i++) {

                String ticket = scanner.nextLine();

                if (ticket.equals("End")){
                    break;
                } else if (ticket.equals("standard")) {
                    standardTickets++;
                } else if (ticket.equals("student")) {
                    studentTickets++;
                } else if (ticket.equals("kid")) {
                    kidsTickets++;
                }
                currMovieTickets = standardTickets + studentTickets + kidsTickets;
            }
            System.out.printf("%s - %.2f%% full.%n", movieName, 1.0 * currMovieTickets / freeSeats * 100 );

            totalStudentTickets += studentTickets;
            totalStandardTickets += standardTickets;
            totalKidsTickets += kidsTickets;

            totalTickets += standardTickets + studentTickets + kidsTickets;

            movieName = scanner.nextLine();
        }
        System.out.printf("Total tickets: %d%n", totalTickets);
        System.out.printf("%.2f%% student tickets.%n", totalStudentTickets / totalTickets * 100);
        System.out.printf("%.2f%% standard tickets.%n", totalStandardTickets / totalTickets * 100);
        System.out.printf("%.2f%% kids tickets.%n", totalKidsTickets / totalTickets * 100);
    }
}
