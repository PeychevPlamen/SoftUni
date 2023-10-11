package magazine;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;

public class Magazine {
    private List<Cloth> data;
    private String type;
    private int capacity;

    public Magazine(String type, int capacity) {
        this.type = type;
        this.capacity = capacity;
        this.data = new ArrayList<>();
    }

    public void addCloth(Cloth cloth) {
        if (data.size() < capacity) {
            data.add(cloth);
        }
    }

    public boolean removeCloth(String color) {
        Cloth clothToRemove = null;
        for (Cloth cloth : data) {
            if (cloth.getColor().equals(color)) {
                clothToRemove = cloth;
                break;
            }
        }
        return data.remove(clothToRemove);
    }

    public Cloth getSmallestCloth() {
        return data.stream()
                .min(Comparator.comparing(Cloth::getSize))
                .orElse(null);
    }

    public Cloth getCloth(String color) {
        Cloth clothColor = null;
        for (Cloth cloth : data) {
            if (cloth.getColor().equals(color)) {
                clothColor = cloth;
                break;
            }
        }
        return clothColor;
    }

    public int getCount() {
        return data.size();
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append(type).append(" magazine contains:").append(System.lineSeparator());
        for (Cloth cloth : data) {
            sb.append(cloth).append(System.lineSeparator());
        }
        return sb.toString().trim();
    }
}
