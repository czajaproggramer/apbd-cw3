namespace ConsoleApp1;

public class Student : Person
{
    public string Index { get; set; }
    public Student (string index, string name, int age) : base(name, age)
    {
        Index = index;
    }
}