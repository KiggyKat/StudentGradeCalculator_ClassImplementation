# Student Grade Calculator — Class Implementation (SDEV 240)

This is a **console demonstration of object-oriented classes**, separate from the earlier Windows Forms GUI exercise. It targets **.NET 8** and requires no third-party packages.

## Open and run
1. Extract the ZIP.
2. In Visual Studio 2022 (with .NET 8 installed), open `StudentGradeCalculator.sln`.
3. Choose **Build > Build Solution**.
4. Press **Ctrl+F5** to run; enter a student name and four grades between 0 and 100.
5. To run built-in tests, open a terminal in the `StudentGradeCalculator` project folder and run `dotnet run -- --test`.

## Class hierarchy
```
GradeRecord (base)
├── AssignmentGradeRecord (derived): validates/stores 4 grades; calculates average
└── GradeReport (derived): determines letter grade; displays formatted report
    └── holds an AssignmentGradeRecord object (association)
```
Each class lives in a separate file under `Models`. Both child classes override `Describe()`; the main program uses a `GradeRecord[]` to demonstrate polymorphism.

## Key design decisions
- The private `_studentName` field is protected through a validating public property.
- The private `_grades` array is accessible only through `GetGrade`/`SetGrade`.
- Grades are `double` values between 0 and 100 inclusive; decimals are accepted.
- Average = (grade1 + grade2 + grade3 + grade4) / 4.
- Letter grade: A >=90, B >=80, C >=70, D >=60, otherwise F.
- This proposed hierarchy is based on the assignment guide and GUI worksheet; the earlier UML diagram was not supplied. Compare names and relationships against your actual UML before submitting.

## Submission
Capture an authentic screenshot after running the app. Push the full solution to GitHub and submit the repository URL, screenshot, and a personalized reflection. Do not upload `bin/` or `obj/` folders.
