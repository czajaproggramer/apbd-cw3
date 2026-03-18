namespace ConsoleApp1;

public class Person
{
    public string Name {get; set;}
    public int Age { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    
    //Dodac fk. zwracajaca typ uzytkownika
}