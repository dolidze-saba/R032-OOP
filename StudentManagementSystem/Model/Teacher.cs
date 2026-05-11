using System;
using System.Collections.Generic;
using StudentManagementSystem.Interfaces;

namespace StudentManagementSystem.Model {
    public class Teacher : Person, IPrintable {
        public List<Course> Courses { get; set; } = new List<Course>();

        public Teacher(int id, string name)
            : base(id, name) {
        }

        public override void PrintInfo() {
            Console.WriteLine($"Teacher {Name} ({Id}).");
            Console.WriteLine("Currently teaching the following courses:");

            foreach (var course in Courses) {
                Console.WriteLine($"{course.Name} ({course.Id})");
            }
        }
    }
}
