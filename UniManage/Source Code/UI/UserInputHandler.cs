using System.Text.RegularExpressions;
namespace UniManage;

/// <summary>
/// Handles user input.
/// Responsible for receiving input from the console and performing basic validation.
/// </summary>

public class UserInputHandler
{
    private University _university = new University();

    public UserInputHandler(University university)
    {
        _university = university;
    }

    public Student AddStudent()
    {
        Console.Write("Enter Student ID: ");
        string id = GetPersonId();

        Console.Write("Enter Name: ");
        string name = GetPersonName();

        Console.Write("Enter Age: ");
        int age = GetPersonAge();

        Console.Write("Enter GPA: ");
        double gpa = GetStudentGPA();

        Console.Write("Enter Courses (comma-separated): ");
        List<string> courses = GetStudentCourses();

        return new Student(id, name, age, gpa, courses);
    }

    public Professor AddProfessor()
    {
        Console.Write("Enter Professor ID: ");
        string id = GetPersonId();

        Console.Write("Enter Name: ");
        string name = GetPersonName();

        Console.Write("Enter Age: ");
        int age = GetPersonAge();

        Console.Write("Enter Salary: ");
        decimal salary = GetProfessorSalary();

        Console.Write("Enter Subjects Taught (comma-separated):");
        List<string> subjectsTaught = GetProfessorSubjects();

        return new Professor(id, name, age, salary, subjectsTaught);

    }

    private List<string> GetProfessorSubjects()
    {
        List<string> subjects = new List<string>();

        string input = Console.ReadLine();
        subjects = new List<string>(input.Split(','));
        if (subjects.Count > 0 && !subjects.Any(c => string.IsNullOrWhiteSpace(c)))
            return subjects;
        throw new InvalidUserInputException("Please enter valid subject only.");
    }

    private decimal GetProfessorSalary()
    {
        decimal salary;
        string input = Console.ReadLine();
        if (decimal.TryParse(input, out salary) && salary > 0)
            return salary;
        throw new InvalidUserInputException("Invalid Salary. Please enter a valid positive salary.");
    }

    private List<string> GetStudentCourses()
    {
        List<string> courses = new List<string>();

        string input = Console.ReadLine();
        courses = new List<string>(input.Split(','));
        if (courses.Count > 0 && !courses.Any(c => string.IsNullOrWhiteSpace(c)))
            return courses;
        throw new InvalidUserInputException("Please enter valid courses only.");
    }

    public string GetCourseOrSubject()
    {
        string course = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(course))
            throw new InvalidUserInputException("Please enter valid course/subject only.");
        return course;

    }

    private double GetStudentGPA()
    {
        double gpa;
        Regex gpaRegex = new Regex(@"^(?![0-9]*\.[0-9]{3,})\d(\.\d{1,2})?$"); // Matches GPA between 0.0 and 4.0

        string input = Console.ReadLine();
        if (gpaRegex.IsMatch(input) && double.TryParse(input, out gpa) && gpa >= GPAConstants.MinGPA && gpa <= GPAConstants.MaxGPA)
            return gpa;
        throw new InvalidUserInputException("Invalid GPA. Please enter a GPA between 0.0 and 4.0 with at most two decimal places.");

    }


    private int GetPersonAge()
    {
        int age;
        string input = Console.ReadLine();
        if (int.TryParse(input, out age) && age > 0)
            return age;
        throw new InvalidUserInputException("Invalid age. Please enter a valid positive integer for age.");
    }

    private string GetPersonName()
    {
        string name;
        Regex nameRegex = new Regex(@"^[A-Za-z\s]+$"); // Only letters and spaces
        name = Console.ReadLine();
        if (nameRegex.IsMatch(name)) return name;
        throw new InvalidUserInputException("Invalid name. Please enter a name with only letters and spaces.");
    }

    public string GetPersonId()
    {
        string id = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(id)) throw new InvalidUserInputException("Invalid ID. Please enter a valid ID");
        return id;
    }


    public int GetChoice()
    {
        int choice;
        while (true)
        {
            
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && (choice > 0 && choice < 8)) return choice;

            Console.Clear();

            DisplayUserMenu();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nError: ");
            Console.ResetColor();

            Console.Write("Invalid choice. Please try entering a number (1 - 7).");
            Console.Write("\nEnter your selection: ");
            continue;
        }
    }

    public void DisplayUserMenu()
    {
        Console.WriteLine("Please choose an action:\n");
        Console.WriteLine("[1]:     Add a student\n" +
                          "[2]:     Add a professor\n" +
                          "[3]:     Enroll student in a course\n" +
                          "[4]:     Assign a subject to a professor\n" +
                          "[5]:     Display all people\n" +
                          "[6]:     Graduate students\n" +
                          "[7]:     Exit");
    }
}