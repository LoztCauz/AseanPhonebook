using System;
using System.Collections.Generic;
using System.Linq;

enum MenuChoice
{
    Store = 1,
    Edit,
    Search,
    Exit
}

class ASEANStudent
{
    public int StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public string Gender { get; set; }
    public string CountryCode { get; set; }
    public string AreaCode { get; set; }
    public string Number { get; set; }
}

class ASEANPhonebook
{
    static readonly List<ASEANStudent> phonebook = new List<ASEANStudent>();

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMainMenu();
            MenuChoice choice = GetMenuChoice();

            switch (choice)
            {
                case MenuChoice.Store:
                    Store();
                    break;
                case MenuChoice.Edit:
                    Edit();
                    break;
                case MenuChoice.Search:
                    Search();
                    break;
                case MenuChoice.Exit:
                    Console.WriteLine("Exiting the ASEAN Phonebook program. Goodbye!");
                    return;
            }
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("1. Store to ASEAN phonebook");
        Console.WriteLine("2. Edit entry in ASEAN phonebook");
        Console.WriteLine("3. Search ASEAN phonebook by country");
        Console.WriteLine("4. Exit");
    }

    static MenuChoice GetMenuChoice()
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MenuChoice), choice))
            {
                return (MenuChoice)choice;
            }

            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    static void Store()
    {
        ASEANStudent newStudent = new ASEANStudent();

        Console.Write("Enter student number: ");
        while (!int.TryParse(Console.ReadLine(), out newStudent.StudentNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for student number.");
            Console.Write("Enter student number: ");
        }

        Console.Write("Enter surname: ");
        newStudent.Surname = Console.ReadLine();
        Console.Write("Enter first name: ");
        newStudent.FirstName = Console.ReadLine();
        Console.Write("Enter occupation: ");
        newStudent.Occupation = Console.ReadLine();
        Console.Write("Enter gender: ");
        newStudent.Gender = Console.ReadLine();
        Console.Write("Enter country code: ");
        newStudent.CountryCode = Console.ReadLine();
        Console.Write("Enter area code: ");
        newStudent.AreaCode = Console.ReadLine();
        Console.Write("Enter number: ");
        newStudent.Number = Console.ReadLine();

        phonebook.Add(newStudent);

        Console.WriteLine("Entry stored successfully.");
        Console.Write("Do you want to enter another entry (Y/N): ");
        string response = Console.ReadLine()?.ToUpper();
        if (response != null && response == "Y")
        {
            Store();
        }
    }

    static void Edit()
    {
        Console.Write("Enter student number: ");
        if (!int.TryParse(Console.ReadLine(), out int studentNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid student number.");
            return;
        }

        ASEANStudent student = phonebook.FirstOrDefault(s => s.StudentNumber == studentNumber);

        if (student == null)
        {
            Console.WriteLine("No student found with that student number.");
            return;
        }

        while (true)
        {
            DisplayStudentInfo(student);
            Console.WriteLine("Which information do you wish to change?");
            Console.WriteLine("1. Student number");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Occupation");
            Console.WriteLine("5. Country code");
            Console.WriteLine("6. Area code");
            Console.WriteLine("7. Phone number");
            Console.WriteLine("8. None – Go back to main menu");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new student number: ");
                    if (!int.TryParse(Console.ReadLine(), out int newStudentNumber))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid student number.");
                        continue;
                    }
                    student.StudentNumber = newStudentNumber;
                    break;
                case 2:
                    Console.Write("Enter new surname: ");
                    student.Surname = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter new gender: ");
                    student.Gender = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Enter new occupation: ");
                    student.Occupation = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Enter new country code: ");
                    student.CountryCode = Console.ReadLine();
                    break;
                case 6:
                    Console.Write("Enter new area code: ");
                    student.AreaCode = Console.ReadLine();
                    break;
                case 7:
                    Console.Write("Enter new phone number: ");
                    student.Number = Console.ReadLine();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayStudentInfo(ASEANStudent student)
    {
        Console.WriteLine($"Here is the existing information about {student.FirstName} {student.Surname}:");
        Console.WriteLine($"Student number: {student.StudentNumber}");
        Console.WriteLine($"Surname: {student.Surname}");
        Console.WriteLine($"Gender: {student.Gender}");
        Console.WriteLine($"Occupation: {student.Occupation}");
        Console.WriteLine($"Country code: {student.CountryCode}");
        Console.WriteLine($"Area code: {student.AreaCode}");
        Console.WriteLine($"Phone number: {student.Number}");
    }

    static void Search()
    {
        Console.Write("Enter country code: ");
        string countryCode = Console.ReadLine();

        List<ASEANStudent> foundStudents = phonebook.Where(s => s.CountryCode == countryCode).ToList();

        if (foundStudents.Count == 0)
        {
            Console.WriteLine("No students found from that country.");
        }
        else
        {
            Console.WriteLine("Here are the students from that country:");
            foreach (ASEANStudent student in foundStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.Surname} - {student.CountryCode} {student.AreaCode} {student.Number}");
            }
        }
    }
}