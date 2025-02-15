namespace UniManage;

public class UniversityValidationException : Exception
{
    public UniversityValidationException(string message) : base(message) { }
}

public class PersonNotFoundException : Exception
{
    public PersonNotFoundException(string message) : base(message) { }
}

public class InvalidUserInputException : Exception
{
    public InvalidUserInputException(string message) : base(message) { }
}

public class EmptyDataException : Exception
{
    public EmptyDataException(string message) : base(message) { }
}
