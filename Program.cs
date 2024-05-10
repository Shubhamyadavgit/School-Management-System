// See https://aka.ms/new-console-template for more information
using StudentManagementSystem;

Console.WriteLine("-----------!Student Management System!-----------");
//Student s1 = new Student("Roronoa", "", "Zoro", 25, 101, Subject.X, new[] { "Maths", "Science", "English", "Hindi", "Social Studies" }, new[] { 80, 60, 99, 45, 78 }, "jaipur", new[] { "Swordsmith", "Fighting" });
//Student s2 = new Student("Vinsmoke", "", "Sanji", 24, 102, Subject.IX, new[] { "Maths", "Science", "English", "Hindi", "Social Studies" }, new[] { 90, 66, 42, 48, 48 }, "korba", new[] { "Cooking", "Football" });
//Student s3 = new Student("Portgas", "D", "Ace", 27, 103, Subject.IX, new[] { "Maths", "Science", "English", "Hindi", "Social Studies" }, new[] { 80, 70, 49, 85, 28 }, "Raipur", new[] { "Reading", "Studying" });
//Student s4 = new Student("Gold", "D", "Rogers", 42, 104, Subject.X, new[] { "Maths", "Science", "English", "Hindi", "Social Studies" }, new[] { 80, 80, 99, 95, 18 }, "bsp", new[] { "Singing", "Dancing" });
//Student s5 = new Student("Monkey", "D", "Luffy", 24, 105, Subject.X, new[] { "Maths", "Science", "English", "Hindi", "Social Studies" }, new[] { 70, 67, 79, 75, 78 }, "Raipur", new[] { "Eating", "Writing" });
//s1.AddedDateTime = DateTime.Parse("2023-04-03");
//s2.AddedDateTime = DateTime.Parse("2022-04-03");
//s3.AddedDateTime = DateTime.Parse("2023-01-03");
//StudentManagement studentlog = new StudentManagement();
UserInput ui = new UserInput();
//studentlog.AddStudent(s1);
//studentlog.AddStudent(s2);
//studentlog.AddStudent(s3);
//studentlog.AddStudent(s4);
//studentlog.AddStudent(s5);

while (true)
{
    Console.WriteLine("1. Add Student to system");
    Console.WriteLine("2. Get all the students with all the details");
    Console.WriteLine("3. Filter students by different fields");
    Console.WriteLine("4. Find the student(s) whose age is in between 15 to 25");
    Console.WriteLine("5. Find the details of the student who is topper of the class");
    Console.WriteLine("6. Find the roll no of students who is in the Nth position of topper list");
    Console.WriteLine("7. Find all the classes where the student belongs to every 10 seconds");
    Console.WriteLine("8. Exit Program");
    try
    {
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ui.AddStudent();
                Console.WriteLine();
                break;
            case 2:
                ui.GetAllStudents();
                Console.WriteLine();
                break;
            case 3:
                Console.WriteLine("1. Filter the students by their First name.");
                Console.WriteLine("2. Filter the students by their Middle name.");
                Console.WriteLine("3. Filter the students by their Last name.");
                Console.WriteLine("4. Filter the students by their Class.");
                Console.WriteLine("5. Filter the students by their Address.");
                Console.WriteLine("6. Filter the students by their Hobby.");
                Console.WriteLine("7. Filter the students by their Added date.");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ui.FilterByFirstName();
                        Console.WriteLine();
                        break;
                    case 2:
                        ui.FilterByMiddleName();
                        Console.WriteLine();
                        break;
                    case 3:
                        ui.FilterByLastName(); Console.WriteLine(); break;
                    case 4:
                        ui.FilterStudentByStandard(); Console.WriteLine(); break;
                    case 5:
                        ui.FilterStudentByAddress(); Console.WriteLine(); break;
                    case 6:
                        ui.FilterStudentByHobby(); Console.WriteLine(); break;
                    case 7:
                        ui.FilterStudentByDateTime(); Console.WriteLine(); break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine();
                        break;
                }
                break;
            case 4:
                ui.GetStudentByAge();
                Console.WriteLine();
                break;
            case 5:
                ui.GetClassTopper(); Console.WriteLine();
                break;
            case 6:
                ui.GetNthTopper(); Console.WriteLine();
                break;
            case 7:
                ui.DisplayStudentEveryTenSeconds();
                Console.WriteLine();
                break;
                case 8:
                Console.WriteLine("Exiting Program!!");
                return;
            default:
                Console.WriteLine("Invalid Input!!");
                Console.WriteLine();
                break;
        }
    }catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

//Student topper = studentlog.GetClassTopper(Standard.IV);
//Console.WriteLine($"Topper  : {topper.FirstName} {topper.MiddleName} {topper.LastName}");

//List<Student> studentOfAge = studentlog.GetStudentByAge(25, 30);
//foreach (Student student in studentOfAge)
//{
//    Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}, Age: {student.Age}, RollNo: {student.RollNo}, Class: {student.Standard}, Subjects: {string.Join(", ", student.Subjects)}, Marks: {string.Join(", ", student.Marks)}, Address: {student.Address}, Hobbies: {string.Join(", ", student.Hobby)}");
//    Console.WriteLine();
//}

//Student NthTopper = studentlog.GetNthTopper(Standard.X,5);
//Console.WriteLine($"The Roll No is : {NthTopper.RollNo} and Name is : {NthTopper.FirstName} {NthTopper.MiddleName} {NthTopper.LastName}");

//List<Student> found = studentlog.GetStudentsByAddedDateTime("2023-04-01");
//foreach (Student student in found)
//{
//    Console.WriteLine(student.FirstName);
//}


