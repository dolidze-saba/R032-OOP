using System;
using System.Linq;
using StudentManagementSystem.Model;
using StudentManagementSystem.Services;

namespace StudentManagementSystem {
    internal class Program {
        public static void Main() {
            try {
                CourseService courseService = new CourseService();
                GradingService gradingService = new GradingService();
                StudentService studentService = new StudentService();

                Teacher teacher1 = new Teacher(1, "John");
                Teacher teacher2 = new Teacher(3, "Anna");
                Teacher teacher3 = new Teacher(5, "Ian");

                Student student1 = new Student(2, "Mike");
                Student student2 = new Student(4, "George");
                Student student3 = new Student(6, "Liz");

                studentService.AddStudent(student1);
                studentService.AddStudent(student2);
                studentService.AddStudent(student3);

                Course course1 = new Course(1, "Mathematics");
                Course course2 = new Course(2, "English");
                Course course3 = new Course(3, "History");

                courseService.AddCourse(course1);
                courseService.AddCourse(course2);
                courseService.AddCourse(course3);

                courseService.AssignTeacher(course1, teacher1);
                courseService.AssignTeacher(course2, teacher2);
                courseService.AssignTeacher(course3, teacher3);

                courseService.EnrollStudent(course1, student1);
                courseService.EnrollStudent(course2, student1);

                courseService.EnrollStudent(course1, student2);
                courseService.EnrollStudent(course3, student2);

                courseService.EnrollStudent(course2, student3);

                Console.WriteLine("=== VALID GRADES ===");

                gradingService.AddGrade(
                    teacher1,
                    student1,
                    new Grade(95, course1)
                );

                gradingService.AddGrade(
                    teacher2,
                    student1,
                    new Grade(88, course2)
                );

                gradingService.AddGrade(
                    teacher1,
                    student2,
                    new Grade(76, course1)
                );

                gradingService.AddGrade(
                    teacher3,
                    student2,
                    new Grade(91, course3)
                );

                gradingService.AddGrade(
                    teacher2,
                    student3,
                    new Grade(84, course2)
                );

                Console.WriteLine("Grades added successfully.\n");


                double mikeMathAverage = student1.Grades
                    .Where(g => g.Course == course1)
                    .Average(g => g.Score);

                Console.WriteLine($"Mike's Math Average: {mikeMathAverage}");

                Console.WriteLine();


                try {
                    Course duplicateCourse = new Course(1, "Physics");
                    courseService.AddCourse(duplicateCourse);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Duplicate Course Test: {ex.Message}");
                }

                try {
                    Student duplicatePerson = new Student(2, "Jen"); 
                    studentService.AddStudent(duplicatePerson);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Duplicate Person Test: {ex.Message}");
                }

                try {
                    gradingService.AddGrade(
                        teacher1,
                        student1,
                        new Grade(150, course1)
                    );
                }
                catch (Exception ex) {
                    Console.WriteLine($"Invalid Grade Test: {ex.Message}");
                }

                try {
                    gradingService.AddGrade(
                        teacher1,
                        student1,
                        new Grade(-20, course1)
                    );
                }
                catch (Exception ex) {
                    Console.WriteLine($"Negative Grade Test: {ex.Message}");
                }

                try {
                    gradingService.AddGrade(
                        teacher1,
                        null,
                        new Grade(90, course1)
                    );
                }
                catch (Exception ex) {
                    Console.WriteLine($"Null Student Test: {ex.Message}");
                }

                try {
                    gradingService.AddGrade(
                        null,
                        student1,
                        new Grade(90, course1)
                    );
                }
                catch (Exception ex) {
                    Console.WriteLine($"Null Teacher Test: {ex.Message}");
                }

                try {
                    gradingService.AddGrade(
                        teacher1,
                        student3,
                        new Grade(90, course1)
                    );
                }
                catch (Exception ex) {
                    Console.WriteLine($"Student Not Enrolled Test: {ex.Message}");
                }

                try {
                    Student invalidStudent = new Student(10, "");
                    studentService.AddStudent(invalidStudent);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Empty Student Name Test: {ex.Message}");
                }

                try {
                    double average = student3.Grades
                        .Where(g => g.Course == course3)
                        .Average(g => g.Score);

                    Console.WriteLine($"Liz's History Average: {average}");
                }
                catch (Exception ex) {
                    Console.WriteLine($"No Grades Average Test: {ex.Message}");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Fatal Error: {ex.Message}");
            }
        }
    }
}
