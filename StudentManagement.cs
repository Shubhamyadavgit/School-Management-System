﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class StudentManagement
    {
        //Creating a list to store students//
        List<Student> students = new List<Student>();
        Student student;

        //1. Method to add student in the list
        public void AddStudentInfo(Student student)
        {
            students.Add(student);
        }

        //2. Method to Fetch all the student from the records
        public List<Student> GetAllStudentsInfo() {
            return students;
        }

        //3. Method to get student between an age range
        public List<Student> GetStudentByAgeInfo(int minAge , int maxAge) 
        {
            return students.FindAll(student => student.Age >= minAge && student.Age <= maxAge);
        }

        //4. Method to find the topper of the class
        public Student GetClassTopperInfo(string standard)
        {
            List<Student> StudentInClass = students.FindAll(student => student.Standard == standard);
            if(StudentInClass.Count == 0)
            {
                return null;
            }
            else
            {
                Student topper = StudentInClass[0];
                for(int i = 0;i< StudentInClass.Count; i++)
                {
                    //Getting help from the helper Method TotalMarks() from the Student Class..
                    if (StudentInClass[i].TotalMarks() > topper.TotalMarks())
                    {
                        topper = StudentInClass[i];
                    }
                }
                return topper;
            }
        }

        //5. Method to get the Nth topper of the class 
        public Student GetNthTopperInfo(string standard,int Rank)
        {
            List<Student> StudentInClass = students.FindAll(student => student.Standard == standard);
            if (StudentInClass.Count == 0)
            {
                return null;
            }
            else
            {
                StudentInClass.Sort();
                StudentInClass.Reverse();
            }
            if (Rank <= 0)
            {
                Console.WriteLine("Invalid input!!");
            }
             return StudentInClass[Rank - 1];
        }

        //Method to Filter Students
        public List<Student> GetStudentsByFirstName(string firstname)
        {
            Predicate<Student> FilterStudent = student =>
            {

                bool name = string.IsNullOrEmpty(firstname)|| student.FirstName.Contains(firstname, StringComparison.OrdinalIgnoreCase);
                return name;
            }; 
            return students.FindAll(FilterStudent);
        }
        
        public List<Student> GetStudentsByLastName(string lastName)
        {
            Predicate<Student> FilterStudent = student =>
            {
                bool lastn = string.IsNullOrEmpty(lastName) || student.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase);
                return lastn;
            };
            return students.FindAll(FilterStudent);
        }
       
        public List<Student> GetStudentsByMiddleName(string middlename)
        {
            Predicate<Student> FilterStudent = student =>
            {
                bool middlen = string.IsNullOrEmpty(middlename) || student.MiddleName.Contains(middlename, StringComparison.OrdinalIgnoreCase);
                return middlen;
            };
            return students.FindAll(FilterStudent);
        }
        public List<Student> GetStudentsByStandard(string Input)
        {
            Predicate<Student> FilterStudent = student =>
            {
                bool standard = string.IsNullOrEmpty(Input) || student.Standard.Contains(Input, StringComparison.OrdinalIgnoreCase);
                return standard;
            };
            return students.FindAll(FilterStudent);
        }

        public List<Student> GetStudentsByAddress(string loc)
        {
            Predicate<Student> FilterDelegate = student =>
            {
                bool FindLoc = string.IsNullOrEmpty(loc) || student.Address.Contains(loc, StringComparison.OrdinalIgnoreCase);
                return FindLoc;
            };
            return students.FindAll(FilterDelegate);
        }

        public List<Student> GetStudentsByHobby(string hobby)
        {
            Predicate<Student> FilterDelegate = student =>
            {
                bool FindHobby = string.IsNullOrEmpty(hobby) || Array.Exists(student.Hobby,hobbies => string.Equals(hobbies,hobby, StringComparison.OrdinalIgnoreCase));
                return FindHobby;
            };
            return students.FindAll(FilterDelegate);
        }

        public List<Student> GetStudentsByAddedDateTime(string dt)
        {
            DateTime dateTime = DateTime.Parse(dt);
            Predicate<Student> FilterDelegate = student => student.AddedDateTime >= dateTime;
            return students.FindAll(FilterDelegate);
        }
    }
}