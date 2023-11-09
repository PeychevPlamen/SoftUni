package collection_hierarchy;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public abstract class Collection implements Addable {
    private int maxSize;
    private List<String> items;


    public Collection() {
        this.maxSize = 100;
        this.items = new ArrayList<>();
    }

    public int getMaxSize() {
        return maxSize;
    }
    protected void addItems(String item){
        this.items.add(item);
    }

    protected List<String> getItems() {
        return Collections.unmodifiableList(this.items);
    }
    protected void addFirst(String item) {
        this.items.add(0, item);
    }

    protected String removeFirst() {
        return this.items.remove(0);
    }

    protected String removeLast() {
        return this.items.remove(this.items.size() - 1);
    }
}
