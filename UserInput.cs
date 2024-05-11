using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;

namespace StudentManagementSystem
{
    public class UserInput
    {
        private StudentManagement studentmanagement = new();
        private bool IsRollNoUniqueForClass(int rollNo, int standard)
        {
            List<Student> students = studentmanagement.GetStudentsByStandard(standard);
            return !students.Any(student => student.RollNo == rollNo);
        }

        public void AddStudent()
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
                try
            {
                Console.WriteLine("Enter First Name : ");
                string? FirstName = Console.ReadLine();
                while (string.IsNullOrEmpty(FirstName) || FirstName.Any(char.IsDigit)|| !regexItem.IsMatch(FirstName))
                {
                    Console.WriteLine("Enter a correct First Name : ");
                    FirstName = Console.ReadLine();
                }

                Console.WriteLine("Enter Middle Name : ");
                string? MiddleName = Console.ReadLine();
                while (MiddleName.Any(char.IsDigit))
                {
                    Console.WriteLine("Enter a correct middle Name : ");
                    MiddleName = Console.ReadLine();
                }

                Console.WriteLine("Enter Last Name : ");
                string? LastName = Console.ReadLine();
                while (string.IsNullOrEmpty(LastName) || LastName.Any(char.IsDigit) || !regexItem.IsMatch(LastName))
                {
                    Console.WriteLine("Enter a correct last Name : ");
                    LastName = Console.ReadLine();
                }

                Console.WriteLine("Enter Age : ");
                int Age;
                while (!int.TryParse(Console.ReadLine(), out Age) || Age < 0 || Age>100 )
                {
                    Console.WriteLine("Enter a correct age : ");
                }

                Console.WriteLine("Enter Address : ");
                string? Address = Console.ReadLine();
                while (string.IsNullOrEmpty(Address) || !(regexItem.IsMatch(Address)))
                {
                    Console.WriteLine("Address cannot be null write a correct address");
                    Address = Console.ReadLine();
                }
                Console.WriteLine("Enter RollNo : ");
                int RollNo;
                while (!int.TryParse(Console.ReadLine(), out RollNo) || RollNo <= 0)
                {
                    Console.WriteLine("Invalid input. RollNo must be a positive integer. Please enter a correct RollNo : ");
                }

                int Standard;
                while (true)
                {
                    Console.WriteLine("Enter Class : ");
                    while (!int.TryParse(Console.ReadLine(), out Standard) || Standard < 0 || Standard > 12)
                    {
                        Console.WriteLine("Enter a valid class : ");
                    }

                    if (IsRollNoUniqueForClass(RollNo, Standard))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Roll number {RollNo} already exists for class {Standard}. Please enter a different roll number.");
                        while (!int.TryParse(Console.ReadLine(), out RollNo) || RollNo <= 0)
                        {
                            Console.WriteLine("Invalid input. RollNo must be a positive integer. Please enter a correct RollNo : ");
                        }
                    }
                }
                var marks = new Dictionary<Subject, int>();
                    foreach (Subject subject in Enum.GetValues(typeof(Subject)))
                    {
                        int marksValue;
                        while (true)
                        {
                            Console.WriteLine($"Enter the marks in {subject} : ");
                            if (int.TryParse(Console.ReadLine(), out marksValue))
                            {
                                if (marksValue >= 0 && marksValue <= 100)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Marks should be between 0 and 100.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer value.");
                            }
                        }
                        marks[subject] = marksValue;
                    }

                    Console.WriteLine("Enter Your hobbies(if want to skip then press enter)  : ");
                    HashSet<string> hobbies = new HashSet<string>();
                    while (true)
                    {
                        string? hobby = Console.ReadLine();
                        if (!string.IsNullOrEmpty(hobby) && hobbies.Contains(hobby) || !regexItem.IsMatch(hobby))
                    {
                            Console.WriteLine("Same hobby cannot be inserted write another hobby : ");
                            hobby = Console.ReadLine();
                        }
                        if (string.IsNullOrEmpty(hobby) || string.IsNullOrWhiteSpace(hobby))
                        {
                            break;
                        }
                        hobbies.Add(hobby);
                    }
                    DateTime AddedDateTime = DateTime.Now;
                    var student = new Student()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        MiddleName = MiddleName,
                        Age = Age,
                        Address = Address,
                        Marks = marks,
                        Hobby = hobbies,
                        AddedDateTime = AddedDateTime,
                        Standard = Standard,
                        RollNo = RollNo,
                    };
                    studentmanagement.AddStudentInfo(student);
                    Console.WriteLine("Student Added Successfully!!");
                    Console.WriteLine();  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllStudents()
        {
            List<Student> studentlist = studentmanagement.GetAllStudentsInfo();
            foreach (Student student in studentlist)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}, Age: {student.Age}, RollNo: {student.RollNo}, Class: {student.Standard}, Subjects: {string.Join(", ", student.Subjects)}, Marks: {string.Join(", ", student.Marks)}, Address: {student.Address}, Hobbies: {string.Join(", ", student.Hobby)}");
                Console.WriteLine();
            }
        }

        public void GetStudentByAge()
        {
            Console.WriteLine("Enter the minimum age : ");
            uint minAge = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter the maximum age : ");
            uint maxAge = Convert.ToUInt32(Console.ReadLine());
            List<Student> students = studentmanagement.GetStudentByAgeInfo(minAge, maxAge);
            if (students.Count == 0)
            {
                Console.WriteLine("No data Found within this age!!");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void GetClassTopper()
        {
            Console.WriteLine("Enter the class : ");
            int val = Convert.ToInt32(Console.ReadLine());
            Student topper = studentmanagement.GetClassTopperInfo(val);

            if (topper == null)
            {
                Console.WriteLine("No students Found!!");
            }
            else
            {
                Console.WriteLine($"Name: {topper.FirstName} {topper.MiddleName} {topper.LastName}");
            }
        }

        public void GetNthTopper()
        {
            Console.WriteLine("Enter the class : ");
            int standard = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rank : ");
            int rank = Convert.ToInt32(Console.ReadLine());
            Student NthTopper = studentmanagement.GetNthTopperInfo(standard, rank);
            if (NthTopper == null)
            {
                Console.WriteLine("Write a valid Rank to find the student : ");
            }
            else
            {
                Console.WriteLine($"RollNo : {NthTopper.RollNo} Name: {NthTopper.FirstName} {NthTopper.MiddleName} {NthTopper.LastName}");
            }
        }

        public void FilterByFirstName()
        {
            Console.WriteLine("Enter the First name : ");
            string? name = Console.ReadLine();

            bool FilterByName(Student student, string firstName)
            {
                return string.IsNullOrEmpty(firstName) || student.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase);
            }
            List<Student> students = studentmanagement.GetStudentsByFirstName(name, FilterByName);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found with FirstName {name}");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterByLastName()
        {
            Console.WriteLine("Enter the Last name : ");
            string? name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByLastName(name);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found with LastName {name}");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }
        public void FilterByMiddleName()
        {
            Console.WriteLine("Enter the Middle name : ");
            string? name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByMiddleName(name);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found with MiddleName {name}");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByStandard()
        {
            Console.WriteLine("Enter the class : ");
            int standard = Convert.ToInt32(Console.ReadLine());
            List<Student> students = studentmanagement.GetStudentsByStandard(standard);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found in class {standard}");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByAddress()
        {
            Console.WriteLine("Enter the location : ");
            string? address = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByAddress(address);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found at {address}");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByHobby()
        {
            Console.WriteLine("Enter Hobby : ");
            string? hobby = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByHobby(hobby);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student has {hobby} as their hobby.");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByDateTime()
        {
            Console.WriteLine("Enter date(yyyy-mm-dd) : ");
            string? dateTime = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByAddedDateTime(dateTime);
            if (students.Count == 0)
            {
                Console.WriteLine($"No student found!!");
            }
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void DisplayStudentEveryTenSeconds()
        {
            List<Student> students = studentmanagement.GetAllStudentsInfo();
            foreach (Student student in students)
            {
                Console.WriteLine($"Student name : {student.FirstName} {student.MiddleName} {student.LastName} , Class : {student.Standard}");
                Thread.Sleep(10000);
            }
        }
    }
}
