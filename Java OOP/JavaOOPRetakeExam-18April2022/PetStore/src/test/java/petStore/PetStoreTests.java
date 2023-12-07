package petStore;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class PetStoreTests {
    PetStore petStore = new PetStore();

    @Test
    public void test_ConstructorAnimal() {
        Animal animal = new Animal("dog", 15, 5000);
    }
    @Test
    public void test_ConstructorPetStore() {
        Assert.assertEquals(0, petStore.getCount());
    }

    @Test
    public void test_addAnimal() {
        Animal animal = new Animal("dog", 15, 5000);
        petStore.addAnimal(animal);
        Assert.assertEquals(1, petStore.getCount());
    }
    @Test (expected = IllegalArgumentException.class)
    public void test_addAnimalNull() {
                petStore.addAnimal(null);
    }
    @Test
    public void test_getAnimals() {
        Animal animal = new Animal("dog", 15, 5000);
        List<Animal> animals = new ArrayList<>();
        animals.add(animal);
        petStore.addAnimal(animal);
        Assert.assertEquals(animals, petStore.getAnimals());
    }

    @Test
    public void test_findAllAnimalsWithMaxKilograms() {
        Animal animal = new Animal("dog", 15, 5000);
        Animal animal2 = new Animal("dog2", 20, 2000);
              petStore.addAnimal(animal);
        petStore.addAnimal(animal2);
        Assert.assertEquals(1, petStore.findAllAnimalsWithMaxKilograms(19).size());
    }
    @Test
    public void test_getTheMostExpensiveAnimal() {
        Animal animal = new Animal("dog", 15, 5000);
        Animal animal2 = new Animal("dog2", 20, 2000);
        petStore.addAnimal(animal);
        petStore.addAnimal(animal2);
        Assert.assertEquals(animal, petStore.getTheMostExpensiveAnimal());
    }
    @Test
    public void test_findAllAnimalBySpecie() {
        Animal animal = new Animal("dog", 15, 5000);
        Animal animal2 = new Animal("dog2", 20, 2000);
        petStore.addAnimal(animal);
        petStore.addAnimal(animal2);
        Assert.assertEquals(1, petStore.findAllAnimalBySpecie("dog").size());
    }
    @Test
    public void test_setAgeAnimal(){
        Animal animal = new Animal("dog", 15, 5000);
        animal.setAge(15);
        Assert.assertEquals(15, animal.getAge());
    }

}

