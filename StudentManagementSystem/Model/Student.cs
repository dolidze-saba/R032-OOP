using System;
using StudentManagementSystem.Interfaces;
using System.Collections.Generic;


namespace StudentManagementSystem.Model {
    public class Student : Person, IPrintable {
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Grade> Grades { get; set; } = new List<Grade>();

        public Student(int id, string name)
            : base(id, name) {
        }

        public override void PrintInfo() {
            Console.WriteLine($"Student {Name} ({Id}).");
            Console.WriteLine("Currently enrolled in the following courses:");

            foreach (var course in Courses) {
                Console.WriteLine($"{course.Name} ({course.Id})");
            }
        }
    }
}
