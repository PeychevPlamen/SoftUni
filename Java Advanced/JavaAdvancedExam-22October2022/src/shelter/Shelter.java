package shelter;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Shelter {
    private List<Animal> data;
    private int capacity;

    public Shelter(int capacity) {
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public int getCapacity() {
        return capacity;
    }

    public void add(Animal animal) {
        if (data.size() < capacity) {
            data.add(animal);
        }
    }

    public boolean remove(String name) {
        Animal animalToRemove = null;
        for (Animal animal : data) {
            if (animal.getName().equals(name)) {
                animalToRemove = animal;
                break;
            }
        }
        return data.remove(animalToRemove);
    }

    public Animal getAnimal(String name, String caretaker) {
        Animal animal = null;
        for (Animal a : data) {
            if (a.getName().equals(name) && a.getCaretaker().equals(caretaker)) {
                animal = a;
                break;
            }
        }
        return animal;
    }

    public Animal getOldestAnimal() {
        return data.stream()
                .max(Comparator.comparing(Animal::getAge))
                .orElse(null);
    }

    public int getCount() {
        return data.size();
    }

    public String getStatistics() {
        StringBuilder sb = new StringBuilder();
        sb.append("The shelter has the following animals:").append(System.lineSeparator());
        for (Animal animal:data) {
            sb.append(animal.getName()).append(" ").append(animal.getCaretaker()).append(System.lineSeparator());
        }
        return sb.toString();
    }
}
