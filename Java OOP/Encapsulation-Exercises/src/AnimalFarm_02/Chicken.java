package AnimalFarm_02;

public class Chicken {
    private final int MIN_AGE = 0;
    private final int MAX_AGE = 15;
    private String name;
    private int age;

    public Chicken(String name, int age) {
        setName(name);
        setAge(age);
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    private void setName(String name) {
        if (name == null || name.isBlank()) {
            throw new IllegalArgumentException("Name cannot be empty.");
        }
        this.name = name;
    }

    private void setAge(int age) {
        if (age < MIN_AGE || age > MAX_AGE) {
            throw new IllegalArgumentException("Age should be between " + MIN_AGE + " and " + MAX_AGE + ".");
        }
        this.age = age;
    }

    public double productPerDay(){
        return calculateProductPerDay();
    }
    private double calculateProductPerDay(){
        double eggsPerDay;
        if (getAge() <= 5){
            eggsPerDay = 2;
        } else if (getAge() <= 11) {
            eggsPerDay = 1;
        } else {
            eggsPerDay = 0.75;
        }
        return eggsPerDay;
    }

    @Override
    public String toString() {
        return String.format("Chicken %s (age %d) can produce %.2f eggs per day.", getName(), getAge(), productPerDay());
    }
}
