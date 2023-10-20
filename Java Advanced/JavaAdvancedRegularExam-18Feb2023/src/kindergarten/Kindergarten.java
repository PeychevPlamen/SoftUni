package kindergarten;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Kindergarten {
    private String name;
    private int capacity;
    private List<Child> registry;

    public Kindergarten(String name, int capacity) {
        this.name = name;
        this.capacity = capacity;
        this.registry = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public int getCapacity() {
        return capacity;
    }

    public boolean addChild(Child child) {
        if (capacity > registry.size()) {
            registry.add(child);
            return true;
        }
        return false;
    }

    public boolean removeChild(String firstName) {
        return this.registry.removeIf(e -> e.getFirstName().equals(firstName));
    }

    public int getChildrenCount() {
        return this.registry.size();
    }

    public Child getChild(String firstName) {
        return this.registry.stream()
                .filter(e -> e.getFirstName().equals(firstName))
                .findFirst()
                .orElse(null);
    }

    public String registryReport() {
        StringBuilder sb = new StringBuilder();
        sb.append("Registered children in ").append(getName()).append(":");
        // sorting by 3 elements in ascending order !!!!
        Comparator<Child> childSort = Comparator
                .comparing(Child::getAge)
                .thenComparing(Child::getFirstName)
                .thenComparing(Child::getLastName);
        // ascending order
        List<Child> sortedChild = registry.stream()
                .sorted(childSort)
                .collect(Collectors.toList());
        // descending order
//        List<Child> sortedChildDescending = registry.stream()
//                .sorted(childSort.reversed())
//                .collect(Collectors.toList());

        sortedChild.forEach(child -> {
            sb.append(System.lineSeparator());
            sb.append("--");
            sb.append(System.lineSeparator());
            sb.append(child);
        });
        return sb.toString().trim();
    }
}
