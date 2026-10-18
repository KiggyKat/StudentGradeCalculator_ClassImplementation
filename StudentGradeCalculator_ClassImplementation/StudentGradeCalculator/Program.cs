using System.Globalization;
using StudentGradeCalculator.Models;

namespace StudentGradeCalculator;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Contains("--test"))
        {
            RunTests();
            return;
        }

        Console.WriteLine("STUDENT GRADE CALCULATOR");
        string studentName = ReadName();
        double[] grades = new double[4];
        for (int i = 0; i < grades.Length; i++)
            grades[i] = ReadGrade(i + 1);

        AssignmentGradeRecord assignments = new AssignmentGradeRecord(
            studentName, grades[0], grades[1], grades[2], grades[3]);
        GradeReport report = new GradeReport(assignments);

        Console.WriteLine("\nRESULTS");
        Console.WriteLine(report.Describe());
        Console.WriteLine("\nInheritance demonstration:");
        GradeRecord[] records = { assignments, report };
        foreach (GradeRecord record in records)
            Console.WriteLine(record.Describe());
    }

    private static string ReadName()
    {
        while (true)
        {
            Console.Write("Student name: ");
            string name = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(name)) return name.Trim();
            Console.WriteLine("Enter the student's name.");
        }
    }

    private static double ReadGrade(int number)
    {
        while (true)
        {
            Console.Write($"Assignment {number} (0-100): ");
            string text = Console.ReadLine() ?? "";
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out double grade)
                && double.IsFinite(grade) && grade >= 0 && grade <= 100)
                return grade;
            Console.WriteLine($"Enter a number from 0 to 100 for Assignment {number}.");
        }
    }

    private static void RunTests()
    {
        int passed = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception("FAILED: " + description);
            passed++;
            Console.WriteLine("PASS: " + description);
        }

        var grades = new AssignmentGradeRecord(" Alex ", 90, 80, 100, 70);
        var report = new GradeReport(grades);
        Check(grades.StudentName == "Alex", "Student name trimmed");
        Check(report.Average == 85, "Average 85.00");
        Check(report.DetermineLetterGrade() == "B", "Letter B");
        Check(grades is GradeRecord && report is GradeRecord, "Both classes inherit GradeRecord");
        Check(report.Describe().Contains("Average: 85.00"), "Overridden report description");
        grades.SetGrade(3, 90);
        Check(report.Average == 90, "Changing grade updates average");
        Check(report.DetermineLetterGrade() == "A", "Grade A at 90");
        Check(new GradeReport(new AssignmentGradeRecord("Test", 60, 60, 60, 60)).DetermineLetterGrade() == "D", "Grade D at 60");
        Check(new GradeReport(new AssignmentGradeRecord("Test", 59, 59, 59, 59)).DetermineLetterGrade() == "F", "Grade F below 60");
        bool rejected = false;
        try { grades.SetGrade(0, 101); }
        catch (ArgumentOutOfRangeException) { rejected = true; }
        Check(rejected, "Out-of-range grade rejected");
        rejected = false;
        try { _ = new AssignmentGradeRecord(" ", 70, 70, 70, 70); }
        catch (ArgumentException) { rejected = true; }
        Check(rejected, "Blank name rejected");
        Console.WriteLine($"\n{passed} tests passed.");
    }
}
