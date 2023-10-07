package PokemonTrainer_06;

import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        Map<String, List<Pokemon>> pokemonByTrainer = new LinkedHashMap<>();

        while (!input.equals("Tournament")) {
            String[] data = input.split("\\s+");
            String nameTrainer = data[0];
            String pokemonName = data[1];
            String pokemonElement = data[2];
            int health = Integer.parseInt(data[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, health);
            pokemonByTrainer.putIfAbsent(nameTrainer, new ArrayList<>());
            pokemonByTrainer.get(nameTrainer).add(pokemon);

            input = scanner.nextLine();
        }
        List<Trainer> trainerList = pokemonByTrainer.entrySet()
                .stream()
                .map(t -> new Trainer(t.getKey(), t.getValue()))
                .collect(Collectors.toList());

        input = scanner.nextLine();

        while (!input.equals("End")) {
            String element = input;
            for (Trainer trainer : trainerList){
                trainer.commandExecuting(input);
            }
                input = scanner.nextLine();
        }

        trainerList.stream()
                .sorted(Comparator.comparingInt(Trainer::getNumberOfBadges).reversed())
                .forEach(System.out::println);
    }
}
