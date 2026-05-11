using StudentManagementSystem.Model;
using StudentManagementSystem.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.Services {
    public class StudentService {
        private List<Student> Students = new List<Student>();

        public void AddStudent(Student student) {  
            var PersonCollision = Students.FirstOrDefault(p => p.Id == student.Id);

            if (PersonCollision != null) 
                throw new DuplicatePersonException(student);

            Students.Add(student);
        }

        public Student GetStudent(int id) {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null) {
                throw new StudentNotFoundException($"Student with id {id} not found.");
            }

            return student;
        }

        public List<Student> GetAllStudents() {
            return Students;
        }
    }
}
