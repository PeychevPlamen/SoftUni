package CompanyRoster_02;

import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        Map<String, Department> departments = new HashMap<>();

        for (int i = 0; i < n; i++) {
            Employee employee;
            String[] input = scanner.nextLine().split("\\s+");
            // name, salary, position, department are mandatory
            String name = input[0];
            double salary = Double.parseDouble(input[1]);
            String position = input[2];
            String department = input[3];
            if (input.length == 4) {
                employee = new Employee(name, salary, position, department);
            }
            // check if we have email/age
            else if (input.length == 5) {
                String token = input[4];
                if (token.contains("@")) {
                    String email = token;
                    employee = new Employee(name, salary, position, department, email);
                } else {
                    int age = Integer.parseInt(token);
                    employee = new Employee(name, salary, position, department, age);
                }
            } else {
                String email = input[4];
                int age = Integer.parseInt(input[5]);
                employee = new Employee(name, salary, position, department, email, age);
            }
            if (!departments.containsKey(department)) {
                departments.put(department, new Department(department));
            }

            departments.get(department).getEmployees().add(employee);
        }

        Department maxAverageSalaryDepartment = departments.entrySet()
                .stream()
                .max(Comparator.comparingDouble(e -> e.getValue().getAverageSalary()))
                .get()
                .getValue();

        System.out.println("Highest Average Salary: " + maxAverageSalaryDepartment.getName());

        maxAverageSalaryDepartment.getEmployees()
                .stream()
                .sorted((e1, e2) -> Double.compare(e2.getSalary(), e1.getSalary()))
                .forEach(employee -> System.out.println(employee.toString()));
    }
}
