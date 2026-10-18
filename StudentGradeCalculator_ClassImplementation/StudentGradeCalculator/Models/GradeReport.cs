namespace StudentGradeCalculator.Models;

// Child class 2: produces a letter grade and a readable report.
public class GradeReport : GradeRecord
{
    private readonly AssignmentGradeRecord _assignments;

    public GradeReport(AssignmentGradeRecord assignments) : base(
        (assignments ?? throw new ArgumentNullException(nameof(assignments))).StudentName)
    {
        _assignments = assignments;
    }

    public double Average => _assignments.CalculateAverage();

    public string DetermineLetterGrade()
    {
        double average = Average;
        if (average >= 90) return "A";
        if (average >= 80) return "B";
        if (average >= 70) return "C";
        if (average >= 60) return "D";
        return "F";
    }

    public override string Describe() =>
        $"{base.Describe()}\nAverage: {Average:F2}\nLetter Grade: {DetermineLetterGrade()}";
}
