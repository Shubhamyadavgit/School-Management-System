using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class UserInput
    {
        StudentManagement studentmanagement = new StudentManagement();
        

        public void AddStudent()
        {
            //Student student = new Student();
            Console.WriteLine("Enter First Name : ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter Middle Name : ");
            string MiddleName = Console.ReadLine();
            Console.WriteLine("Enter Last Name : ");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter Age : ");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Address : ");
            string Address = Console.ReadLine();
            Console.WriteLine("Enter RollNo : ");
            int RollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Standard : ");
            string Standard = Console.ReadLine();
            Dictionary<Subject,int> marks = new Dictionary<Subject,int>();
            foreach (Subject subject in Enum.GetValues(typeof(Subject)))
            {
                int marksValue;
                while (true)
                {
                    Console.WriteLine($"Enter the marks in {subject} : ");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out marksValue))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                }
                marks[subject] = marksValue;
            }
            Console.WriteLine("Enter Your hobbies : ");
            string[] hobbies = new string[7];
            for(int i = 0; i <hobbies.Length; i++)
            {
                string value = Console.ReadLine();
                hobbies[i] = value;
            }
            DateTime AddedDateTime = DateTime.Now;
            var student = new Student() {
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
            //Hobby = hobbies;
           // student.Marks = marks.Select(pair=>pair.Value).ToArray();
            studentmanagement.AddStudentInfo(student);
            Console.WriteLine("Student Added Successfully!!");
            Console.WriteLine();
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
            int minAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the maximum age : ");
            int maxAge = int.Parse(Console.ReadLine());
            List<Student> students = studentmanagement.GetStudentByAgeInfo(minAge, maxAge);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void GetClassTopper()
        {
            Console.WriteLine("Enter the class : ");
            string val = Console.ReadLine();
            Student topper = studentmanagement.GetClassTopperInfo(val);
            Console.WriteLine($"Name: {topper.FirstName} {topper.MiddleName} {topper.LastName}");
        }

        public void GetNthTopper()
        {
            Console.WriteLine("Enter the class : ");
            string standard = Console.ReadLine();
            Console.WriteLine("Enter Rank : ");
            int rank = int.Parse(Console.ReadLine());
            Student NthTopper = studentmanagement.GetNthTopperInfo(standard, rank);
            Console.WriteLine($"Name: {NthTopper.FirstName} {NthTopper.MiddleName} {NthTopper.LastName}");
        }

        public void FilterByFirstName()
        {
            Console.WriteLine("Enter the First name : ");
            string name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByFirstName(name);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterByLastName()
        {
            Console.WriteLine("Enter the Last name : ");
            string name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByLastName(name);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }
        public void FilterByMiddleName()
        {
            Console.WriteLine("Enter the Middle name : ");
            string name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByMiddleName(name);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByStandard()
        {
            Console.WriteLine("Enter the class : ");
            string standard = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByStandard(standard);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByAddress()
        {
            Console.WriteLine("Enter the location : ");
            string address = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByAddress(address);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByHobby()
        {
            Console.WriteLine("Enter Hobby : ");
            string hobby = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByHobby(hobby);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }

        public void FilterStudentByDateTime()
        {
            Console.WriteLine("Enter date(yyyy-mm-dd) : ");
            string dateTime = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByAddedDateTime(dateTime);
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            }
        }
    }
}
