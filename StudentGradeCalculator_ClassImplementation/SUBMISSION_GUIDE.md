# Seven-part submission guide

1. **Project:** Open `StudentGradeCalculator.sln` in Visual Studio; build.
2. **Classes:** Inspect the three individual files in `Models`.
3. **Encapsulation:** Explain `StudentName`, `_studentName`, `_grades`, `SetGrade`, and `GetGrade`.
4. **Inheritance:** Show both `: GradeRecord` declarations, `base(...)` constructors, and overridden `Describe()`.
5. **Logic:** Run with Alex and 90, 80, 100, 70; expected 85.00, B.
6. **Testing:** Run `dotnet run -- --test` and save the output. Also test a blank name and grade 101 interactively. Take a screenshot of a successful application run.
7. **GitHub:** Create a repository, upload the solution, `.csproj`, `Program.cs`, and `Models/*.cs`; commit and verify it is accessible. Submit the URL.

## Reflection draft — personalize after actually testing
My Student Grade Calculator implementation uses a shared `GradeRecord` base class and two derived classes, `AssignmentGradeRecord` and `GradeReport`. The base class stores and validates the student's name, while the assignment class manages four grades and calculates their average. The report class uses those grades to determine a letter grade and format the results. Both derived classes override `Describe()`, showing how inheritance and polymorphism can reuse shared behavior. This hierarchy is a proposed design based on the assignment instructions; I will compare it with my original UML diagram and revise any differences before submission.

One challenge I anticipated was keeping grades valid without allowing other parts of the program to change the underlying array directly. I addressed this by making the grade array private and adding `GetGrade()` and `SetGrade()` methods that check the index and permitted grade range. [After testing, replace this sentence with the actual challenge you encountered and how you resolved it.]

## Evidence still needed
- Visual Studio build success on your Windows computer
- Real screenshot showing the app running
- GitHub repository URL after your push
- Personal reflection describing your real implementation experience
