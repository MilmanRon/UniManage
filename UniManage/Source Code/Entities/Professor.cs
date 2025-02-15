namespace UniManage;

/// <summary>
/// Represents a professor in the university system.
/// Inherits from the Person class and includes professor-specific properties.
/// </summary>

public class Professor : Person
{
    public decimal Salary { get; set; }
    public List<string> SubjectsTaught { get; set; }

    public Professor(string id,
                     string name,
                     int age,
                     decimal salary,
                     List<string> subjectsTaught) : base(id, name, age)
    {
        Salary = salary;
        SubjectsTaught = subjectsTaught;
    }

    public void AssignSubject(string subject)
    {
        if (SubjectsTaught.Any(s => s == subject)) return;
        SubjectsTaught.Add(subject);
    }

    public override string GetInfo()
    {
        // Prefixed with P to indicate that it's a professor
        return $"P{base.GetInfo()}, Salary: ${Salary:0,0.00}, Subjects: [{string.Join(", ", SubjectsTaught)}]";
    }
}
