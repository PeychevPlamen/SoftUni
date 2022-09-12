import java.util.Scanner;

public class ProjectsCreation_07 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Integer timeForProject = 3;
        String name = scanner.nextLine();
        Integer projectsCount = Integer.parseInt(scanner.nextLine());
        Integer neededTime = timeForProject * projectsCount;

        System.out.printf("The architect %s will need " +
                "%d hours to complete %d project/s.", name, neededTime, projectsCount);

    }
}
