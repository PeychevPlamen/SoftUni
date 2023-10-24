package halloween;

import java.util.ArrayList;
import java.util.List;

public class House {
    private int capacity;
    private List<Kid> data;

    public House(int capacity) {
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public int getCapacity() {
        return capacity;
    }

    public void addKid(Kid kid)  {
        if (capacity > data.size()) {
            data.add(kid);
        }
    }

    public boolean removeKid(String name) {
        return this.data.removeIf(e -> e.getName().equals(name));
    }

    public Kid getKid(String street){
        return this.data.stream()
                .filter(e -> e.getStreet().equals(street))
                .findFirst()
                .orElse(null);
    }

    public int getAllKids(){
        return this.data.size();
    }

    public String getStatistics(){
        StringBuilder sb = new StringBuilder();
        sb.append("Children who visited a house for candy:\n");
        for (Kid k : data) {
            sb.append(k.getName()).append(" from ").append(k.getStreet()).append(" street").append(System.lineSeparator());
        }
        return sb.toString().trim();
    }
}
