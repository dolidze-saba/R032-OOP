using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace StudentManagementSystem.Services {
    public class CourseService {
        private List<Course> Courses = new List<Course>();

        public void AddCourse(Course course) {
            var CourseCollision = Courses.FirstOrDefault(c => c.Id == course.Id);

            if (CourseCollision != null) 
                throw new DuplicateCourseException(course);

            Courses.Add(course);
        }

        public void AssignTeacher(Course course, Teacher teacher) {
            if (course == null)
                throw new CourseNotFoundException("Course cannot be null.");

            if (teacher == null)
                throw new TeacherNotFoundException("Teacher cannot be null.");

            course.Teacher = teacher;

            if (!teacher.Courses.Contains(course)) {
                teacher.Courses.Add(course);    
            }
        }

        public void EnrollStudent(Course course, Student student) {
            if (course == null)
                throw new CourseNotFoundException("Course cannot be null.");

            if (student == null)
                throw new StudentNotFoundException("Student cannot be null.");

            if (!course.Students.Contains(student)) { 
                course.Students.Add(student);
            }

            if (!student.Courses.Contains(course)) {
                student.Courses.Add(course);
            }
        }

        public Course GetCourse(int id) {
            var course = Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new CourseNotFoundException($"Course with id {id} not found.");

            return course;
        }
    }
}
