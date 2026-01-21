
using OOP_Pro.Models;
using System;
using System.Collections.Generic;
using System.Timers;

namespace OOP_Pro
{
    internal class Program
    {



        static void Main(string[] args)
        {
            // قراءة المواد من الشيت
            var coursesData = FileManager.ReadCoursesFromExcel("Courses.xlsx");// ليست للكورسات 
            var StudentsData = FileManager.ReadStudentsFromExcel("Students.xlsx"); // ليست للطلاب
            List<Course> courses = new List<Course>();
            List<Student> student = new List<Student>();

            #region Courses



            Console.WriteLine("Do you want to add a subject? (y/n)");
            string input = Console.ReadLine();


            if (input.ToLower() != "n")
            {
                // إضافة مواد جديدة

                while (input.ToLower() == "y")
                {
                    Console.WriteLine("Enter subject name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter subject hours:");
                    int hours;

                    while (!int.TryParse(Console.ReadLine(), out hours))
                    {
                        Console.WriteLine("Enter subject hours again:");
                    }

                    courses.Add(new Course(name, hours));

                    Console.WriteLine("Do you want to add another subject? (y/n)");
                    input = Console.ReadLine();
                }


                courses.AddRange(coursesData);// دمج المواد القديمة والجديدة

                // حفظ كل المواد في Excel
                FileManager.SaveCoursesToExcel(courses, "Courses.xlsx");

                Console.WriteLine("Courses saved successfully.\n");

                // عرض المواد من Excel

                Console.WriteLine("Courses from Excel:");
                var allCourses = FileManager.ReadCoursesFromExcel("Courses.xlsx");
                foreach (var item in allCourses)
                {
                    Console.WriteLine($"Course Name: {item.Name}  Hours:{item.CreditHours}");
                }

            }
            #endregion

            #region Students
            Console.WriteLine("Do you want to add a Student? (y/n)");
            string inputstudent = Console.ReadLine();

            var oldStudents = FileManager.ReadStudentsFromExcel("Students.xlsx");

            while (inputstudent.ToLower() == "y")
            {

                Console.WriteLine("StudentName : ");
                var studentname = Console.ReadLine();


                student.Add(new Student(studentname));

                Console.WriteLine("Do you want to add another subject? (y/n)");
                inputstudent = Console.ReadLine();
            }
            FileManager.SaveStudentsToExcel(student, "Students.xlsx");
            Console.WriteLine("Students saved successfully.\n");

            // قراءة وعرض الطلاب من Excel
            var allStudents = FileManager.ReadStudentsFromExcel("Students.xlsx");
            Console.WriteLine("Students from Excel:");
            foreach (var s in allStudents)
            {
                Console.WriteLine($"Student Name: {s.Name}");
            }

            #endregion
        }





        //#region Testing by omnia

        //Course math = new Course("Math", 3);
        //Course physics = new Course("Physics", 4);


        //Student s1 = new Student("Ahmed");
        //Student s2 = new Student("Mostafa");

        //Student.AssignGrade(s1, new List<Course>() { math, physics }, new List<double>() { 90, 100 });

        //GradeManager.CalculateGPA(s1); Console.WriteLine("========>Test for calcGPA");

        //Console.WriteLine("-----------------------");

        //Student.AssignGrade(s2, new List<Course>() { math, physics }, new List<double>() { 40, 30 });
        //GradeManager.CalculateGPA(s2); Console.WriteLine("========>Test for calcGPA");

        //Console.WriteLine("-----------------------");

        //List<Student> students = new List<Student>();
        //students.Add(s1);
        //students.Add(s2);





        //GradeManager.riskandtopstudents(students); Console.WriteLine("========>Test for risk , top");

        //Console.WriteLine("-----------------------");

        //Console.WriteLine(s1);


        //#endregion
    }
}
