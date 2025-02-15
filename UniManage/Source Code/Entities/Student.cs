namespace UniManage;

/// <summary>
/// Represents a student in the university system.
/// Inherits from the Person class and includes student-specific properties.
/// </summary>

public class Student : Person
{
    public double GPA { get; set; }
    public List<string> Courses { get; set; }

    public Student(string id,
                   string name,
                   int age,
                   double gpa,
                   List<string> courses) : base(id, name, age)
    {
        GPA = gpa;
        Courses = courses;
    }

    public void EnrollCourse(string course)
    {
        if (Courses.Any(c => c == course)) return;
        Courses.Add(course);
    }

    public override string GetInfo()
    {
        // Prefixed the {Id} with S to indicate that it's a student
        return $"S{base.GetInfo()}, GPA: {GPA}, Courses: [{string.Join(", ", Courses)}]";
    }




}
