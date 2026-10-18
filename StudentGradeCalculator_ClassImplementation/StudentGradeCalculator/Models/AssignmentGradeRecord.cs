namespace StudentGradeCalculator.Models;

// Child class 1: owns and validates the four assignment grades.
public class AssignmentGradeRecord : GradeRecord
{
    private readonly double[] _grades = new double[4];

    public AssignmentGradeRecord(string studentName, double grade1, double grade2,
                                 double grade3, double grade4) : base(studentName)
    {
        double[] entered = { grade1, grade2, grade3, grade4 };
        for (int i = 0; i < entered.Length; i++)
            SetGrade(i, entered[i]);
    }

    public double GetGrade(int index)
    {
        CheckIndex(index);
        return _grades[index];
    }

    public void SetGrade(int index, double grade)
    {
        CheckIndex(index);
        if (double.IsNaN(grade) || double.IsInfinity(grade) || grade < 0 || grade > 100)
            throw new ArgumentOutOfRangeException(nameof(grade),
                $"Assignment {index + 1} must be a number from 0 to 100.");
        _grades[index] = grade;
    }

    private static void CheckIndex(int index)
    {
        if (index < 0 || index >= 4)
            throw new ArgumentOutOfRangeException(nameof(index), "Use an index from 0 to 3.");
    }

    public double CalculateAverage() => (_grades[0] + _grades[1] + _grades[2] + _grades[3]) / 4.0;

    public override string Describe() => $"{base.Describe()} | Four assignments entered";
}
