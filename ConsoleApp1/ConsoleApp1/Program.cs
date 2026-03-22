// uzyt. x wypozycza od pracownika y sprzet z

using ConsoleApp1;

Student stud1 = new Student("s33205", "Antek", 18);
Employee emp1 = new Employee(4800.5, "Zenon", 25);
Laptop dev1 = new Laptop("Macbook air", "Apple", 4800, "MacOS", 2021);
Camera dev2 = new Camera("Dron Szached", "Korpus Straznikow Rewolucji", 9000, new int[]{1920, 1080}, 
    60, .5f, new int[]{30, 50, 10});
Laptop dev3 = new Laptop("Zen Book", "Asus", 3200, "Windows 33", 2024);

Service s = new Service();
s.Add(stud1);
s.Add(emp1);
s.Add(dev1);
s.Add(dev2);
s.Add(dev3);
s.AddRecord(1, 2, 5, 1, 50, 100);
s.AddRecord(1, 2, 7, 2, 100, 200);
s.AddRecord(1, 2, 7, 0, 100, 200);

s.PrintDevices();
s.PrintAvailableDevices();
s.PrintAllRecords();
s.PrintAllRecords();
s.PrintUserHistory(1);
s.PrintRaport();

