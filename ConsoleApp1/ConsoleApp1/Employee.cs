namespace ConsoleApp1;

public class Employee : Person
{
    private double Salary { get; set;}

    public Employee(double salary, string name, int age) : base(name, age)
    {
        Salary = salary;
    }
}