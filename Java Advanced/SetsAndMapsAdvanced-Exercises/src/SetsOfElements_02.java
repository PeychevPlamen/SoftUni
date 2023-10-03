import java.util.*;

public class SetsOfElements_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Set<String> firstSet = new LinkedHashSet<>();
        Set<String> secondSet = new LinkedHashSet<>();

        int[] size = Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::valueOf)
                .toArray();

        for (int i = 0; i < size[0]; i++) {
            firstSet.add(scanner.nextLine());
        }
        for (int i = 0; i < size[1]; i++) {
            secondSet.add(scanner.nextLine());
        }

        firstSet.retainAll(secondSet);

        String result = String.join(" ", firstSet);
        System.out.println(result);
    }
}
