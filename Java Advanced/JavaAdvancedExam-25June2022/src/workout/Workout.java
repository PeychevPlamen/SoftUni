package workout;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Workout {
    private List<Exercise> exercises;
    private String type;
    private int exerciseCount;

    public Workout(String type, int exerciseCount) {
        this.type = type;
        this.exerciseCount = exerciseCount;
        this.exercises = new ArrayList<>();
    }

    public String getType() {
        return type;
    }

    public void addExercise(Exercise exercise) {
        if (exerciseCount > exercises.size()) {
            exercises.add(exercise);
        }
    }

    public boolean removeExercise(String name, String muscle) {
        return this.exercises.removeIf(e -> e.getName().equals(name) && e.getMuscle().equals(muscle));
    }

    public Exercise getExercise(String name, String muscle) {
        return this.exercises.stream()
                .filter(e -> e.getName().equals(name) && e.getMuscle().equals(muscle))
                .findFirst()
                .orElse(null);
    }

    public Exercise getMostBurnedCaloriesExercise() {
        return this.exercises.stream()
                .max(Comparator.comparing(Exercise::getBurnedCalories))
                .orElse(null);
    }

    public int getExerciseCount() {
        return this.exercises.size();
    }

    public String getStatistics() {
        StringBuilder sb = new StringBuilder();
        sb.append("Workout type: ").append(getType());
        this.exercises.forEach(exercise -> {
            sb.append(System.lineSeparator());
            sb.append(exercise);
        });
        return sb.toString().trim();
    }
}
