using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagementSystem
{
    public class UserInput
    {
        StudentManagement studentmanagement = new StudentManagement();
        

        public void AddStudent()
        {
            try
            {
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
                int Standard = int.Parse(Console.ReadLine());
                if(Standard == 0)
                {
                    throw new Exception("Class is mandatory.");
                }
                Dictionary<Subject,int> marks = new Dictionary<Subject, int>();
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
            Console.WriteLine("Enter Your hobbies : ");
            string[] hobbies = new string[7];
                for (int i = 0; i < hobbies.Length; i++)
            {
                string value = Console.ReadLine();
                hobbies[i] = value;
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
            //Hobby = hobbies;
           // student.Marks = marks.Select(pair=>pair.Value).ToArray();
            studentmanagement.AddStudentInfo(student);
            Console.WriteLine("Student Added Successfully!!");
            Console.WriteLine();
            }catch (Exception ex)
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
            uint minAge = uint.Parse(Console.ReadLine());
            Console.WriteLine("Enter the maximum age : ");
            uint maxAge = uint.Parse(Console.ReadLine());
            List<Student> students = studentmanagement.GetStudentByAgeInfo(minAge, maxAge);
            if(students.Count == 0)
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
            int val = int.Parse(Console.ReadLine());
            Student topper = studentmanagement.GetClassTopperInfo(val);
            if(topper == null)
            {
                Console.WriteLine("No students Found!!");
            }
            Console.WriteLine($"Name: {topper.FirstName} {topper.MiddleName} {topper.LastName}");
        }

        public void GetNthTopper()
        {
            Console.WriteLine("Enter the class : ");
            int standard = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Rank : ");
            int rank = int.Parse(Console.ReadLine());
            Student NthTopper = studentmanagement.GetNthTopperInfo(standard, rank);
            if(NthTopper == null)
            {
                Console.WriteLine("Write a valid Rank to find the student : ");
            }
            Console.WriteLine($"RollNo : {NthTopper.RollNo} Name: {NthTopper.FirstName} {NthTopper.MiddleName} {NthTopper.LastName}");
        }

        public void FilterByFirstName()
        {
            Console.WriteLine("Enter the First name : ");
            string name = Console.ReadLine();
            List<Student> students = studentmanagement.GetStudentsByFirstName(name);
            if(students.Count == 0)
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
            string name = Console.ReadLine();
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
            string name = Console.ReadLine();
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
            int standard = int.Parse(Console.ReadLine());
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
            string address = Console.ReadLine();
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
            string hobby = Console.ReadLine();
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
            string dateTime = Console.ReadLine();
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
    }
}
