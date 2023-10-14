package aquarium;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashSet;
import java.util.List;

public class Aquarium {
    private List<Fish> fishInPool;
    private String name;
    private int capacity;
    private int size;

    public Aquarium(String name, int capacity, int size) {
        this.name = name;
        this.capacity = capacity;
        this.size = size;
        this.fishInPool = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public int getCapacity() {
        return capacity;
    }

    public int getSize() {
        return size;
    }

    public int getFishInPool() {
        return fishInPool.size();
    }

    public void add(Fish fish) {
        if (fishInPool.size() < capacity && !fishInPool.contains(fish.getName())) {
            fishInPool.add(fish);
        }
    }

    public boolean remove(String name) {
        Fish fishToRemove = null;
        for (Fish fish : fishInPool) {
            if (fish.getName().equals(name)) {
                fishToRemove = fish;
                break;
            }
        }
        return fishInPool.remove(fishToRemove);
    }
    public Fish findFish(String name) {
        Fish searchedFish = null;
        for (Fish fish : fishInPool) {
            if (fish.getName().equals(name)) {
                searchedFish = fish;
                break;
            }
        }
        return searchedFish;
    }
    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append("Aquarium: ").append(getName()).append(" ^ Size: ").append(getSize());
        sb.append(System.lineSeparator());
        for (Fish fish : fishInPool) {
            sb.append(fish).append(System.lineSeparator());
        }
        return sb.toString().trim();
    }

}
