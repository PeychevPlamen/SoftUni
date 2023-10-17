package christmas;

import java.time.Period;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Bag {
    private List<Present> data;
    private String color;
    private int capacity;

    public Bag(String color, int capacity) {
        this.color = color;
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public String getColor() {
        return color;
    }

    public int getCapacity() {
        return capacity;
    }

    public int count() {
        return data.size();
    }

    public void add(Present present) {
        if (capacity > data.size()) {
            data.add(present);
        }
    }

    public boolean remove(String name) {
        return this.data.removeIf(e -> e.getName().equals(name));
    }

    public Present heaviestPresent() {
        return this.data.stream()
                .max(Comparator.comparing(Present::getWeight))
                .orElse(null);
    }
    public Present getPresent(String name){
        return this.data.stream()
                .filter(e -> e.getName().equals(name))
                .findFirst()
                .orElse(null);
    }
    public String report(){
        StringBuilder sb = new StringBuilder();
        sb.append(getColor()).append(" bag contains:");
        this.data.forEach(present -> {
            sb.append(System.lineSeparator());
            sb.append(present);
        });
        return sb.toString().trim();
    }
}
