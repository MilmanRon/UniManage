namespace UniManage;

/// <summary>
/// Manages the core operations of the university system.
/// Handles student and professor registration, course enrollment, and data storage.
/// </summary>

public class University : IGraduatable
{
    private Dictionary<string, Person> people = new Dictionary<string, Person>();

    public void AddPerson(Person person)
    {
        if (people.ContainsKey(person.Id))
            throw new UniversityValidationException($"The ID '{person.Id}' already exists. " +
                                                    "Please choose a unique ID.");
        people.Add(person.Id, person);

    }

    public void EnrollStudentToCourse(string id, string course)
    {
        Person person = FindPerson(id);
        if (person is not Student) throw new UniversityValidationException($"The person with ID: '{person.Id}' is not a Student. " +
                                                                            "Please try a different ID");
        (person as Student).EnrollCourse(course);
    }

    public void AssignSubjectToProfessor(string id, string subject)
    {
        Person person = FindPerson(id);
        if (person is not Professor) throw new UniversityValidationException($"The person with ID: '{person.Id}' is not a Professor. " +
                                                                             "Please try a different ID");
        (person as Professor).AssignSubject(subject);
    }

    public Person FindPerson(string id)
    {
        if (people.ContainsKey(id)) return people[id];

        throw new PersonNotFoundException($"Person with ID '{id}' not found.");
    }

    public void DisplayAllPeople()
    {
        if (people.Count > 0)
            people.Values.ToList().ForEach(p => Console.WriteLine(p.GetInfo()));
        else
            throw new EmptyDataException("There are no people to display.");
    }

    public void Graduate()
    {
        if (people.Count == 0 || people is null)
            throw new EmptyDataException("There are no students in the university.");
        var students = people.Where(p => p.Value is Student).ToDictionary(p => p.Key, p => (Student)p.Value);
        if (students.Count == 0)
            throw new EmptyDataException("There are no students in the university.");
        foreach (var student in students)
        {
            if (student.Value.GPA > GPAConstants.GraduationThreshold)
                people.Remove(student.Key);
        }

    }

    public void Load()
    {
        people = DemoData.GetDictionaryDemoData();
    }
}
