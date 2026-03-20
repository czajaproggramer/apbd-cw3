// uzyt. x wypozycza od pracownika y sprzet z

using ConsoleApp1;

Student stud1 = new Student("s33205", "Antek", 18);
Employee emp1 = new Employee(4800.5, "Zenon", 25);
Laptop dev1 = new Laptop("Macbook air", "Apple", 4800, "MacOS", 2021);

Record rec1 = new Record(DateTime.Parse("2026-02-02"), 7, emp1, stud1, dev1,0, 0);
Console.WriteLine(rec1);
