namespace UniManage;

/// <summary>
/// Represents a generic person in the university system.
/// This is the base class for specific roles such as students and professors.
/// </summary>

public abstract class Person
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string id,
                  string name,
                  int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public virtual string GetInfo()
    {
        return $"{Id}: {Name}, Age: {Age}";
    }

}

