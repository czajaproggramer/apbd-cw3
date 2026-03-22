namespace ConsoleApp1;

public class Service
{
    private List<Student> students;
    private List<Employee> employees;
    private List<Device> devices;
    private List<Record> records;

    public Service()
    {
        students = new List<Student>();
        employees = new List<Employee>();
        devices = new List<Device>();
        records = new List<Record>();
    }

    public void Add(Student stud) {students.Add(stud);}
    public void Add(Employee emp) {employees.Add(emp);}
    public void Add(Device dev) {devices.Add(dev);}

    public void AddRecord(int studPesel, int empPesel, int leaseDays, int devId, float price, float dayPenalty)
    {
        var stud = (from stu in students where stu.Pesel == studPesel select stu).Single();
        if (stud.ActiveReservations >= 2)
        {
            // throw new Exception("Student posiada juz dwie aktywne rezerwacje");
            Console.WriteLine("!!!!Student posiada juz dwie aktywne rezerwacje!!!!");
            return;
        }
        var empl = (from emp in employees where emp.Pesel == empPesel select emp).Single();
        var devi = (from dev in devices where dev.DId == devId select dev).Single();
        
        records.Add(new Record(DateTime.Now, leaseDays, empl, stud, devi, price, dayPenalty));
        devi.IsAvailable = false;
        stud.ActiveReservations += 1;
        Console.WriteLine(stud.ActiveReservations);
    }

    public void PrintDevices()
    {
        Console.WriteLine("----Baza urządzeń----");
        foreach (Device dev in devices)
        {
            Console.WriteLine(dev.DId + "\t" + dev.Name + "\t" + (dev.IsAvailable ? "DOSTĘPNE" : "NIEDOSTĘPNE"));
        }
    }

    public void PrintAvailableDevices()
    {
        Console.WriteLine("----Baza dostępnych urządzeń----");
        foreach (Device dev in devices)
        {
            if(dev.IsAvailable)
                Console.WriteLine(dev.Name + "\t" + dev.Brand + "\t" + dev.RegularPrice);
        }
    }

    public void PrintAllRecords()
    {
        Console.WriteLine("----Historia wypoyczeń----");
        Console.WriteLine("ID\tP. std\tP. prac.\tData startu\tKoniec wypoz.\tData oddania");
        foreach (Record rec in records)
        {
            Console.WriteLine(rec.Id + "\t" + rec.User.Pesel + "\t" + rec.Worker.Pesel + "\t"
             + rec.LeaseDate + "\t" + rec.GetEndDate() + 
            "\t" + (rec.RealReturnDate.HasValue ? rec.RealReturnDate.Value : "-"));
        }
    }

    public void HandleReturn(int leaseId, DateTime returnDate)
    {
        Record rec = (from r in records where r.Id == leaseId select r).Single();
        if (rec == null)
        {
            throw new Exception("Nie ma wypozyczenia o podanym id");
        }

        rec.RealReturnDate = returnDate;
        rec.LeaseObject.IsAvailable = true;
        rec.User.ActiveReservations -= 1;
        
        if (returnDate > rec.GetEndDate())
        {
            float penalty = rec.CalculatePenalty();
            Console.WriteLine("Student " + rec.User.Name + " musi zaplacic " + penalty + " kary.");
        }
    }

    public void MarkDeviceUnavailable(int devId)
    {
        Device dev = (from d in devices where d.DId == devId select d).Single();
        if (dev == null)
        {
            throw new Exception("Nie istnieje urządzenie o podanym id");
        }

        if (!dev.IsAvailable)
        {
            throw new Exception("Urządzenie jest juz niedostępne");
        }

        dev.IsAvailable = false;
    }

    public void PrintUserHistory(int uPesel)
    {
        Student stud = (from s in students where s.Pesel == uPesel select s).Single();
        if (stud == null)
        {
            throw new Exception("Nie ma wypozyczenia o podanym id");
        }
        Console.WriteLine($"----Historia wypoyczeń studenta ({stud.Index}) ----");
        Console.WriteLine("ID\ttP. prac.\tData startu\tKoniec wypoz.\tData oddania");
        foreach (Record rec in records)
        {
            Console.WriteLine(rec.Id + "\t" + rec.Worker.Pesel + "\t"
                              + rec.LeaseDate + "\t" + rec.GetEndDate() + 
                              "\t" + (rec.RealReturnDate.HasValue ? rec.RealReturnDate.Value : "-"));
        }
        
    }
    
    public void PrintPastRecords()
    {
        Console.WriteLine("----Historia przedawnionych wypozyczen----");
        Console.WriteLine("ID\tP. std\tP. prac.\tData startu\tKoniec wypoz.\tData oddania");
        foreach (Record rec in records)
        {
            if (rec.GetEndDate() < DateTime.Now && rec.RealReturnDate != null)
                Console.WriteLine(rec.Id + "\t" + rec.User.Pesel + "\t" + rec.Worker.Pesel + "\t"
                              + rec.LeaseDate + "\t" + rec.GetEndDate() + 
                              "\t" + (rec.RealReturnDate.HasValue ? rec.RealReturnDate.Value : "-"));
        }
    }

    public void PrintRaport()
    {
        Console.WriteLine($"----Raport na dzień {DateTime.Now.ToShortDateString()}----");
        int allDevices = (from d in devices select 1).Count();
        int allAvailableDevices = (from d in devices where d.IsAvailable select 1).Count();
        // int studentsWithDelayInReturn = (from s in students where 
        //     (from r in records where
        //         (s.Pesel == r.User.Pesel && (r.RealReturnDate != null && r.RealReturnDate > r.GetEndDate())
        //             || (r.RealReturnDate == null && DateTime.Now > r.GetEndDate())) select 1)
        //     .Single() select 1).Count();
        int studsWithDelayInReturn = 0;
        foreach (var stud in students)
        {
            int delayCount = (from r in records
                where (r.User.Pesel == stud.Pesel && !r.NoDelay() ) select 1).Count();
            studsWithDelayInReturn += delayCount > 0 ? 1 : 0;
        }
        double penaltySum = 0;
        double moneyMade = 0;
        foreach (Record rec in records)
        {
            penaltySum += rec.CalculatePenalty();
            moneyMade += rec.CalculatePenalty() + rec.BasePrice;
        }
        
        Console.WriteLine($"WSZYSTKICH URZADZ.\t{allDevices}" +
                          $"\nDOST. URZADZ\t{allAvailableDevices}\n" +
                          $"STUD. Z OPOZN.\t{studsWithDelayInReturn}" +
                          $"\nPROG. PRZYCHOD\t{moneyMade}" +
                          $"\nW TYM KARY\t{penaltySum}");
    }
    
}