package FoodFinder_01;

import java.util.*;
import java.util.stream.Collectors;

public class FoodFinder {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] words = new String[]{"pear", "flour", "pork", "olive"};
        String[] wordsFound = new String[]{"****", "*****", "****", "*****"};

        Deque<Character> queueVowels = new ArrayDeque<>();
        Deque<Character> stackConsonants = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .forEach(e -> queueVowels.offer(e.charAt(0)));
        Arrays.stream(scanner.nextLine().split("\\s+"))
                .forEach(e -> stackConsonants.push(e.charAt(0)));

        while (!stackConsonants.isEmpty()) {
            char vowel = queueVowels.poll();
            char consonants = stackConsonants.pop();

            for (int i = 0; i < words.length; i++) {
                String word = words[i];
                int indexVowel = word.indexOf(vowel);
                int indexConsonant = word.indexOf(consonants);
                if (indexVowel >= 0) {
                    wordsFound[i] = wordsFound[i].substring(0, indexVowel) + vowel + wordsFound[i].substring(indexVowel + 1);
                }
                if (indexConsonant >= 0) {
                    wordsFound[i] = wordsFound[i].substring(0, indexConsonant) + consonants + wordsFound[i].substring(indexConsonant + 1);
                }
            }
            queueVowels.offer(vowel);
        }
        List<String> output = Arrays.stream(wordsFound).filter(w -> !w.contains("*")).toList();

        System.out.printf("Words found: %d%n", output.size());
        output.forEach(System.out::println);
    }
}
