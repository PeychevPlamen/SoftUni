package parrots;

import java.util.ArrayList;
import java.util.List;

public class Cage {
    private List<Parrot> data;
    private String name;
    private int capacity;

    public Cage(String name, int capacity) {
        this.name = name;
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public int getCapacity() {
        return capacity;
    }

    public void add(Parrot parrot) {
        if (capacity > data.size()) {
            data.add(parrot);
        }
    }

    public boolean remove(String name) {
        for (int i = 0; i < this.data.size(); i++) {
            if (this.data.get(i).getName().equals(name)) {
                this.data.remove(i);
                return true;
            }
        }
        return false;
    }

    public Parrot sellParrot(String name) {
        Parrot parrotToSell = null;
        for (Parrot parrot : data) {
            if (parrot.getName().equals(name)) {
                parrotToSell = parrot;
                parrot.setAvailable(false);
                break;
            }
        }
        return parrotToSell;
    }
    public List<Parrot> sellParrotBySpecies(String species) {
        List<Parrot> toReturn = new ArrayList<>();
        this.data.forEach(i -> {
            if (i.getSpecies().equals(species)) {
                i.setAvailable(false);
                toReturn.add(i);
            }
        });
        return toReturn;
    }
    public int count() {
        return this.data.size();
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append("Parrots available at ").append(this.name).append(":").append(System.lineSeparator());
        for (Parrot r: this.data) {
            if (r.isAvailable()) {
                sb.append(r.toString()).append(System.lineSeparator());
            }
        }
        return sb.toString().trim();
    }
}
