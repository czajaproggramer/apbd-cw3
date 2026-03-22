namespace ConsoleApp1;

public class Record
{
    public DateTime LeaseDate { get; }
    public int LeaseDays { get; set; }
    public DateTime? RealReturnDate { get; set; }
    public Employee Worker { get; }
    public Student User { get; }
    public Device LeaseObject { get; }
    public float BasePrice { get; }
    public float LateFees { get; }
    private static int lastId = 0;
    public int Id { get; }

    public Record(DateTime leaseDate, int leaseDays, Employee worker, Student user, Device leaseObject, float basePrice, float lateFees)
    {
        LeaseDate = leaseDate;
        LeaseDays = leaseDays;
        RealReturnDate = null;
        Worker = worker;
        User = user;
        LeaseObject = leaseObject;
        BasePrice = basePrice;
        LateFees = lateFees;
        Id = lastId++;
        //okresla kare na dzien
    }

    public override string ToString()
    {
        return "Dnia " + LeaseDate.ToShortDateString() + " student " + User.Name + " (" + User.Index +
               ") wypoyczył " + LeaseObject.Name + " na okres " + LeaseDays + "dni.";
    }

    public float CalculatePenalty()
    {
        if (RealReturnDate.HasValue)
        {
            DateTime endDate = LeaseDate.AddDays(LeaseDays);
            int daysOver = (int) Math.Floor((RealReturnDate.Value.Date - endDate).TotalDays);
            if (daysOver > 0)
            {
                return LateFees * daysOver;
            }
        }
        return 0f;
    }

    public bool NoDelay()
    {
        if (!RealReturnDate.HasValue)
        {
            DateTime crrDate = DateTime.Now;
            int deltaDays = (int)Math.Floor((crrDate - GetEndDate()).TotalDays);
            return deltaDays <= 0;
        }
        else
        {
            int deltaDays = (int)Math.Floor((RealReturnDate.Value - GetEndDate()).TotalDays);
            return deltaDays <= 0;
        }
    }

    public DateTime GetEndDate()
    {
        return LeaseDate.AddDays(LeaseDays);
    }
}