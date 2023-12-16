using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public char Gender { get; set; }
    public int CountryCode { get; set; }
    public int AreaCode { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    static List<Student> phonebook = new List<Student>();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("Welcome to the ASEAN Phonebook!\n");
            Console.WriteLine("[1] Add a new entry");
            Console.WriteLine("[2] Edit an entry");
            Console.WriteLine("[3] Search by country");
            Console.WriteLine("[4] Exit\n");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddNewEntry();
                    break;
                case 2:
                    EditEntry();
                    break;
                case 3:
                    SearchByCountry();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        } while (choice != 4);
    }

    static void AddNewEntry()
    {
        do
        {
            Student student = new Student();
            Console.Write("\nEnter student number: ");
            student.StudentNumber = Console.ReadLine();

            Console.Write("Enter surname: ");
            student.Surname = Console.ReadLine();

            Console.Write("Enter first name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Enter occupation: ");
            student.Occupation = Console.ReadLine();

            Console.Write("Enter gender (M for male, F for female): ");
            student.Gender = Convert.ToChar(Console.ReadLine());

            Console.Write("Country Code:\n[63], Philippines \n[66], Thailand \n[65], Singapore \n[64], Indonesia \n[62], Malaysia");

            Console.Write("\nEnter country code: ");
            student.CountryCode = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter area code: ");
            student.AreaCode = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter phone number: ");
            student.PhoneNumber = Console.ReadLine();

            phonebook.Add(student);

            Console.Write("\nDo you want to enter another entry [Y/N]? ");
        } while (Console.ReadLine().ToUpper() == "Y");
    }

    static void EditEntry()
    {
        Console.Write("\nEnter student number: ");
        string studentNumber = Console.ReadLine();

        Student student = phonebook.FirstOrDefault(s => s.StudentNumber == studentNumber);

        if (student != null)
        {
            Console.WriteLine($"\nExisting information for student number {studentNumber}:");
            Console.WriteLine($"{student.FirstName} {student.Surname} works as {student.Occupation}. Their number is {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}\n");

            int choice;
            do
            {
                Console.WriteLine("What information would you like to change?");
                Console.WriteLine("[1] Student number [2] Surname [3] Gender [4] Occupation");
                Console.WriteLine("[5] Country code [6] Area code [7] Phone number [8] None - Go back to main menu");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new student number: ");
                        student.StudentNumber = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new surname: ");
                        student.Surname = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new gender (M for male, F for female): ");
                        student.Gender = Convert.ToChar(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Enter new occupation: ");
                        student.Occupation = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter new country code: ");
                        student.CountryCode = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Enter new area code: ");
                        student.AreaCode = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter new phone number: ");
                        student.PhoneNumber = Console.ReadLine();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            } while (choice != 8);
        }
        else
        {
            Console.WriteLine("Student number not found. Please try again.\n");
        }
    }

    static void SearchByCountry()
    {
        Dictionary<int, string> countryCodes = new Dictionary<int, string>
        {
            { 63, "Philippines" },
            { 66, "Thailand" },
            { 65, "Singapore" },
            { 62, "Indonesia" },
            { 60, "Malaysia" }
        };

        List<Student> studentsFromSelectedCountries = new List<Student>();

        do
        {
            Console.WriteLine("\nFrom which country:");
            Console.WriteLine("\n[1] Philippines \n[2] Thailand \n[3] Singapore \n[4] Indonesia \n[5] Malaysia \n[6] ALL \n[0] No More");

            Console.Write("Enter choice: ");
            int chosenCountry = int.Parse(Console.ReadLine());

            if (chosenCountry == 0)
                break;

            int countryCode = GetCountryCode(chosenCountry);

            if (countryCode == 0)
            {
                studentsFromSelectedCountries.AddRange(phonebook);
                break;
            }

            studentsFromSelectedCountries.AddRange(phonebook.Where(s => s.CountryCode == countryCode));
        } while (true);

        if (studentsFromSelectedCountries.Count == 0)
        {
            Console.WriteLine("No students found for the selected countries.");
            return;
        }

        studentsFromSelectedCountries = studentsFromSelectedCountries.OrderBy(s => s.Surname).ToList();

        Console.WriteLine("\nStudents found:");

        foreach (var student in studentsFromSelectedCountries)
        {
            Console.WriteLine($"{student.Surname}, {student.FirstName}, with student number {student.StudentNumber}, works as a {student.Occupation}. Phone: {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}");
        }
    }

    static int GetCountryCode(int chosenCountry)
    {
        switch (chosenCountry)
        {
            case 1: return 63; // Philippines
            case 2: return 66; // Thailand
            case 3: return 65; // Singapore
            case 4: return 62; // Indonesia
            case 5: return 60; // Malaysia
            case 6: return 0;  // ALL
            default: return 0;
        }
    }
}
