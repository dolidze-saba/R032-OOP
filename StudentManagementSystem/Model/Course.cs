using System;
using System.Collections.Generic;
using StudentManagementSystem.Interfaces;

namespace StudentManagementSystem.Model {
    public class Course : IPrintable {
        public int Id { get; set; }
        public string Name { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public Course(int id, string name) {
            Id = id;
            Name = name;
        }

        public void PrintInfo() {
            Console.WriteLine($"Course {Name} ({Id}) is being taught by {Teacher}.");
            Console.WriteLine("Students currently enrolled:");

            foreach (var student in Students) {
                Console.WriteLine($"{student.Name};");
            }
        }
    }
}
