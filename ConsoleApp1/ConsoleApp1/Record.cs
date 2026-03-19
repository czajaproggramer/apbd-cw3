namespace ConsoleApp1;

public class Record
{
    public DateTime LeaseDate { get; }
    public int LeaseDays { get; set; }
    public Employee Worker { get; }
    public Student User { get; }
    public float BasePrice { get; }
    public float LateFees { get; set; }

    public Record(DateTime leaseDate, int leaseDays, Employee worker, Student user, float basePrice, float lateFees)
    {
        LeaseDate = leaseDate;
        LeaseDays = leaseDays;
        Worker = worker;
        User = user;
        BasePrice = basePrice;
        LateFees = lateFees;
    }
}