namespace UniManage;

public enum MenuChoices
{
    AddStudent = 1,
    AddProfessor,
    Enroll,
    Assign,
    Display,
    Graduate,
    Exit
}

/// <summary>
/// Handles the console-based user interface for the university system.
/// Displays the menu and processes user input.
/// </summary>

public class ApplicationMenu
{
    private UserInputHandler _inputHandler;
    private University _university = new University();

    public ApplicationMenu(University university)
    {
        _university = university;
        _inputHandler = new UserInputHandler(university);
    }

    public void StartMenuLoop()
    {
        int currentAction = 0; // A way to store the current action of a user to be able to resume it.
        int choice;
        while (true)
        {
            try
            {
                if (currentAction == 0) //currentAction = 0 : Default (Main Menu).
                {
                    Console.Clear();
                    _inputHandler.DisplayUserMenu();
                    Console.Write("\nEnter your selection: ");
                    choice = _inputHandler.GetChoice();
                }
                else
                    choice = currentAction;
                Console.WriteLine();

                switch (choice)
                {
                    case (int)MenuChoices.AddStudent:
                        currentAction = 1;
                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Add a student\n");
                        Console.ResetColor();

                        _university.AddPerson(_inputHandler.AddStudent());
                        Console.WriteLine("\nStudent added successfully!");
                        currentAction = 0;
                        break;

                    case (int)MenuChoices.AddProfessor:
                        currentAction = 2;
                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Add a professor\n");
                        Console.ResetColor();

                        _university.AddPerson(_inputHandler.AddProfessor());
                        Console.WriteLine("\nProfessor added successfully!");
                        currentAction = 0;
                        break;

                    case (int)MenuChoices.Enroll:
                        currentAction = 3;
                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Enroll student in a course\n");
                        Console.ResetColor();

                        Console.Write("Enter Student ID: ");
                        string studentId = _inputHandler.GetPersonId();
                        Console.Write("Enter course: ");
                        string course = _inputHandler.GetCourseOrSubject();

                        _university.EnrollStudentToCourse(studentId, course);
                        Console.WriteLine($"\n'{course}' has been added successfully to {_university.FindPerson(studentId).Name}'s courses");
                        currentAction = 0;
                        break;

                    case (int)MenuChoices.Assign:
                        currentAction = 4;
                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Assign a subject to a professor\n");
                        Console.ResetColor();

                        Console.Write("Enter Professor ID: ");
                        string professorId = _inputHandler.GetPersonId();
                        Console.Write("Enter subject: ");
                        string subject = _inputHandler.GetCourseOrSubject();

                        _university.AssignSubjectToProfessor(professorId, subject);
                        Console.WriteLine($"\n'{subject}' has been added successfully to {_university.FindPerson(professorId).Name}'s subjects");
                        currentAction = 0;
                        break;

                    case (int)MenuChoices.Display:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Display all people\n");
                        Console.ResetColor();

                        _university.DisplayAllPeople();
                        break;

                    case (int)MenuChoices.Graduate:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Action: Graduate students\n");
                        Console.ResetColor();

                        _university.Graduate();
                        Console.WriteLine($"Students with GPA above{GPAConstants.GraduationThreshold : 0.0} have been graduated!");
                        break;

                    case (int)MenuChoices.Exit:
                        Console.Write("Are you sure you want to exit the application? (Y/N): ");
                        var confirmation = Console.ReadLine().ToUpper()[0];
                        Console.WriteLine();
                        if (confirmation == 'Y')
                        {
                            Console.WriteLine("Exiting the application...");
                            return; // Exit the Main method
                        }
                        Console.Clear();
                        continue;

                }

                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: ");
                Console.ResetColor();
                Console.WriteLine(e.Message);
                Console.Write("\nWould you like to resume action? (Y/N): ");
                var confirmation = Console.ReadLine().ToUpper()[0];
                Console.WriteLine();
                if (confirmation != 'Y')
                    currentAction = 0;
                Console.Clear();
            }

        }


    }
}
