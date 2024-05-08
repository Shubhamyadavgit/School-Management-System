using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName {  get; set; }
        public string LastName {  get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Standard {  get; set; }
        public Subject Subjects { get; set; }
        public Dictionary<Subject,int> Marks { get; set; }
        public string Address {  get; set; }
        public string[] Hobby { get; set; }
        public DateTime AddedDateTime { get; set; }
        //public Student()
        //{
        //    // Initialize Marks as an empty array of integers
        //    Marks = new int[0];
        //}

        //public Student(string firstname, string middlename, string lastname, int age, int rollno, string standard, Dictionary<Subject,int> marks, string address, string[] hobby)
        //{
        //    FirstName = firstname;
        //    MiddleName = middlename;
        //    LastName = lastname;
        //    Age = age;
        //    RollNo = rollno;
        //    Standard = standard;
        //    Marks = marks;
        //    Address = address;
        //    Hobby = hobby;
        //    AddedDateTime = DateTime.Now;
        //}
        //Helper Method for TotalMarks

        public int CompareTo(Student? other)
        {
           if(other == null) return 1;
           return this.TotalMarks().CompareTo(other.TotalMarks());
        }
    }
    public static class StudentExtension
    {
        public static int TotalMarks(this Student student)
        {
            int TotalMarks = 0;
            foreach (int mark in student.Marks.Values)
            {
                TotalMarks += mark;
            }
            return TotalMarks;
        }
    }
}
