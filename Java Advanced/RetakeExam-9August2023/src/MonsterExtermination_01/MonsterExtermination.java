package MonsterExtermination_01;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class MonsterExtermination {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Integer> monsterArmorQueue = new ArrayDeque<>();
        Deque<Integer> soldierStrikeStack = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split(","))
                .mapToInt(Integer::parseInt)
                .forEach(monsterArmorQueue::offer);

        Arrays.stream(scanner.nextLine().split(","))
                .mapToInt(Integer::parseInt)
                .forEach(soldierStrikeStack::push);

        int totalKilled = 0;

        while (!monsterArmorQueue.isEmpty() && !soldierStrikeStack.isEmpty()) {
            int monster = monsterArmorQueue.peek();
            int soldier = soldierStrikeStack.peek();

            if (soldier >= monster) {
                soldier -= monster;
                totalKilled++;
                monsterArmorQueue.poll();
                if (soldier == 0) {
                    soldierStrikeStack.pop();
                } else {
                    if (soldierStrikeStack.size() == 1){
                        soldierStrikeStack.pop();
                        soldierStrikeStack.push(soldier);
                    } else {
                        soldierStrikeStack.pop();
                        soldierStrikeStack.push(soldierStrikeStack.pop() + soldier);
                    }
                }

            } else {
                monster -= soldier;
                soldierStrikeStack.pop();
                monsterArmorQueue.poll();
                monsterArmorQueue.offer(monster);
            }
        }

        if (monsterArmorQueue.isEmpty()) {
            System.out.println("All monsters have been killed!");
        }
        if (soldierStrikeStack.isEmpty()) {
            System.out.println("The soldier has been defeated.");
        }
        System.out.printf("Total monsters killed: %s", totalKilled);
    }
}
