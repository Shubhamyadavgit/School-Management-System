using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Student : IComparable<Student>
    {
        public string? FirstName { get; set; }
        public string? MiddleName {  get; set; }
        public string? LastName {  get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public int Standard {  get; set; }
        public Subject Subjects { get; set; }
        public Dictionary<Subject,int>? Marks { get; set; }
        public string? Address {  get; set; }
        public string[]? Hobby { get; set; }
        public DateTime AddedDateTime { get; set; }
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
            foreach (var mark in student.Marks.Values)
            {
                TotalMarks += mark;
            }
            return TotalMarks;
        }
    }
}
