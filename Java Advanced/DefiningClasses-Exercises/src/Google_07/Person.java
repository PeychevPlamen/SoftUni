package Google_07;

import java.util.ArrayList;
import java.util.List;

public class Person {
    //1 компания
    private Company company;
    //1 кола
    private Car car;
    //списък с родители
    private List<Parent> parents;
    //списък с деца
    private List<Child> children;
    //списък с покемони
    private List<Pokemon> pokemons;

    public Person () {
        //company = null
        //car = null
        //parents = празен списък
        this.parents = new ArrayList<>();
        //children = празен списък
        this.children = new ArrayList<>();
        //pokemons = празен списък
        this.pokemons = new ArrayList<>();
    }

    public Person(Company company, Car car, List<Parent> parents, List<Child> children, List<Pokemon> pokemons) {
        this.company = company;
        this.car = car;
        this.parents = parents;
        this.children = children;
        this.pokemons = pokemons;
    }
    //setter
    public void setCompany(Company company) {
        this.company = company;
    }

    //getter for pokemons
    public List<Pokemon> getPokemons() {
        return this.pokemons;
    }

    public List<Parent> getParents() {
        return this.parents;
    }

    public List<Child> getChildren() {
        return this.children;
    }

    public void setCar(Car car) {
        this.car = car;
    }
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        //Company:
        //Car:
        //Trabant 30
        //Pokemon:
        //Electrode Electricity
        //Parents:
        //Children:
        sb.append("Company:").append("\n");
        if (company != null) {
            sb.append(company).append("\n");
        }
        sb.append("Car:").append("\n");
        if (car != null) {
            sb.append(car).append("\n");
        }

        sb.append("Pokemon:").append("\n");
        for (Pokemon pokemon : pokemons) {
            sb.append(pokemon).append("\n");
        }

        sb.append("Parents:").append("\n");
        for (Parent parent : parents) {
            sb.append(parent).append("\n");
        }

        sb.append("Children:").append("\n");
        for (Child child : children) {
            sb.append(child).append("\n");
        }

        return sb.toString();
    }
}
