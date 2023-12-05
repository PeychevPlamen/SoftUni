package zoo.entities.areas;

import zoo.entities.animals.Animal;
import zoo.entities.foods.Food;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

import static zoo.common.ExceptionMessages.AREA_NAME_NULL_OR_EMPTY;
import static zoo.common.ExceptionMessages.NOT_ENOUGH_CAPACITY;

public abstract class BaseArea implements Area {
    private String name;
    private int capacity;
    private Collection<Food> foods;
    private Collection<Animal> animals;

    public BaseArea(String name, int capacity) {
        setName(name);
        this.capacity = capacity;
        this.foods = new ArrayList<>();
        this.animals = new ArrayList<>();
    }

    public void setName(String name) {
        if (name == null || name.isBlank()) {
            throw new NullPointerException(AREA_NAME_NULL_OR_EMPTY);
        }
        this.name = name;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public Collection<Animal> getAnimals() {
        return Collections.unmodifiableCollection(animals);
    }

    @Override
    public Collection<Food> getFoods() {
        return Collections.unmodifiableCollection(foods);
    }

    @Override
    public int sumCalories() {
        return foods.stream().mapToInt(Food::getCalories).sum();
    }

    @Override
    public void addAnimal(Animal animal) {
        if (capacity <= animals.size()) {
            throw new IllegalStateException(NOT_ENOUGH_CAPACITY);
        }
        animals.add(animal);
    }

    @Override
    public void removeAnimal(Animal animal) {
        animals.remove(animal);
    }

    @Override
    public void addFood(Food food) {
        foods.add(food);
    }

    @Override
    public void feed() {
        animals.forEach(Animal::eat);
    }

    @Override
    public String getInfo() {
//        "{areaName} ({areaType}):
//        Animals: {animalName1} {animalName2} {animalName3} (…) / Animals: none
//        Foods: {foodsCount}
//        Calories: {sumCalories}"
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("%s (%s)", getName(), getClass().getSimpleName()));
        sb.append(System.lineSeparator());
        sb.append("Animals:");
        if (animals.isEmpty()){
            sb.append(" none");
        } else {
            for (Animal animal: animals) {
                sb.append(String.format(" %s", animal.getName()));
            }
        }
        sb.append(System.lineSeparator());
        sb.append(String.format("Foods: %d", foods.size()));
        sb.append(System.lineSeparator());
        sb.append(String.format("Calories: %d", sumCalories()));

        return sb.toString().trim();
    }
}
