using UniManage;

namespace UniManage;

public class DemoData
{
    public static Dictionary<string, Person> GetDictionaryDemoData()
    {
        return new Dictionary<string, Person> {
            { "001", new Student("001", "Alice Johnson", 20, 3.8, new List<string> { "Math", "Physics", "Computer Science" })},
            { "002",  new Student("002", "Bob Williams", 22, 3.5, new List<string> { "History", "Literature", "Philosophy" })},
            { "003", new Student("003", "Charlie Brown", 19, 3.9, new List<string> { "Biology", "Chemistry", "Statistics" })},
            { "004", new Student("004", "David Smith", 21, 3.2, new List<string> { "Economics", "Business", "Finance" })},
            { "005", new Student("005", "Emma Davis", 23, 3.7, new List<string> { "Art", "Design", "Psychology" })},
            { "006", new Professor("006", "Dr John Smith", 45, 85000m, new List<string> { "Mathematics", "Physics" })},
            { "007", new Professor("007", "Dr Emily Brown", 50, 92000m, new List<string> { "Computer Science", "Data Structures" })},
            { "008", new Professor("008", "Dr Robert Williams", 38, 78000m, new List<string> { "History", "Political Science" })},
            { "009", new Professor("009", "Dr Sarah Johnson", 55, 97000m, new List<string> { "Biology", "Genetics" })},
            { "010", new Professor("010", "Dr Michael Davis", 42, 86000m, new List<string> { "Economics", "Finance" })}
        };
    }
}
