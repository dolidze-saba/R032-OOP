using System;
using StudentManagementSystem.Interfaces;

namespace StudentManagementSystem.Model {
    public class Person : IPrintable {
        public int Id { get; set; } 
        public String Name { get; set; }

        public Person(int id, string name) {
            Id = id;
            Name = name;
        }

        public virtual void PrintInfo() {
            Console.WriteLine($"Person: {Name} ({Id}).");
        }
    } 
}
