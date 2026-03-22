namespace ConsoleApp1;

public class Student : Person
{
    public string Index { get; set; }
    public int ActiveReservations { get; set; }
    public Student (string index, string name, int age) : base(name, age)
    {
        Index = index;
        ActiveReservations = 0;
    }
}