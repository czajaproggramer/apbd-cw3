namespace ConsoleApp1;

public class Record
{
    public DateTime LeaseDate { get; }
    public int LeaseDays { get; set; }
    public Employee Worker { get; }
    public Student User { get; }
    public Device LeaseObject { get; }
    public float BasePrice { get; }
    public float LateFees { get; set; }

    public Record(DateTime leaseDate, int leaseDays, Employee worker, Student user, Device leaseObject, float basePrice, float lateFees)
    {
        LeaseDate = leaseDate;
        LeaseDays = leaseDays;
        Worker = worker;
        User = user;
        LeaseObject = leaseObject;
        BasePrice = basePrice;
        LateFees = lateFees;
    }

    public override string ToString()
    {
        return "Dnia " + LeaseDate.ToShortDateString() + " student " + User.Name + " (" + User.Index +
               ") wypoyczył " + LeaseObject.Name + " na okres " + LeaseDays + "dni.";
    }
}