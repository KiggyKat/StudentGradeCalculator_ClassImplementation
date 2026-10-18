namespace StudentGradeCalculator.Models;

// Parent class: common student information and behavior.
public class GradeRecord
{
    private string _studentName;

    public string StudentName
    {
        get => _studentName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Enter the student's name.");
            _studentName = value.Trim();
        }
    }

    public GradeRecord(string studentName)
    {
        _studentName = string.Empty;
        StudentName = studentName;
    }

    public virtual string Describe() => $"Student: {StudentName}";
}
