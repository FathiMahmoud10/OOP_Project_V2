using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_Pro.Models
{
    public class Student
    {
        
        public string Name { get; set; } // اسم الطالب 

        public List<StudentCourse> Courses;     // اسماء الكورسات 
        public int Attendance { get; set; } 

        public Student(string name)
        {
            Name = name;
            Courses = new List<StudentCourse>();  
            Attendance = 0;                       
        }

        #region Assign grades 
        public static void AssignGrade(Student student, List<Course> courses, List<double> scores)
        {
            // تأكد إن عدد المواد = عدد الدرجات
            if (courses.Count != scores.Count)
            {
                Console.WriteLine("Courses and scores count must be equal.");
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Course course = courses[i];
                double score = scores[i];

                // نشوف هل المادة دي موجودة قبل كده عند الطالب
                var existing = student.Courses
                                      .FirstOrDefault(sc => sc.Course == course);

                if (existing != null)
                {
                    existing.Grade = score;
                }
                else
                {
                    student.Courses.Add(new StudentCourse(course, score));
                }
            }
        }

        #endregion


        public override string ToString()
        {
            string coursesInfo;

            if (Courses.Count == 0) coursesInfo = "No courses enrolled";
            else coursesInfo = string.Join(", ", Courses);

            return $"Name: {Name}, Attendance: {Attendance}%, Courses: [{coursesInfo}]";
        }
    }
}
