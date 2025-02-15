namespace UniManage;

/// <summary>
/// Entry point of the university management system.
/// Initializes the university, loads demo data, and starts the console menu.
/// </summary>

public class Program
{
    static void Main(string[] args)
    {
        University Harvard = new University();
        Harvard.Load(); //Loading University instance with demo data

        ApplicationMenu applicationMenu = new ApplicationMenu(Harvard);

        applicationMenu.StartMenuLoop();
    }
}
