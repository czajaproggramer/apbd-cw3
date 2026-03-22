namespace ConsoleApp1;

public class Person
{
    public string Name {get; set;}
    public int Age { get; set; }
    public int Pesel { get; }
    private static int lastPesel = 0;
    
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Pesel = ++lastPesel;
    }
    
    //Dodac fk. zwracajaca typ uzytkownika
}