using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Services {
    public class GradingService : IGradingService {
        private void ValidateGrade(Teacher teacher, Student student, Grade grade) {
            // For some reason, I'm forced on an older NET version. 
            // Since ThrowIfNull does not exist, I have to write this 
            // awful code.
            if (grade == null)
                throw new InvalidGradeException("Grade cannot be null.");

            if (grade.Course == null) 
                throw new InvalidGradeException("Course cannot be null.");

            if (grade.Score < 0 || grade.Score > 100) 
                throw new InvalidGradeException("Grade must be between 0 and 100.");

            if (!student.Courses.Contains(grade.Course)) 
                throw new InvalidGradeException(
                    $"Student {student.Name} ({student.Id}) is not enrolled in {grade.Course.Name}."
                );

            if (!teacher.Courses.Contains(grade.Course))
                throw new InvalidGradeException(
                    $"Teacher {teacher.Name} ({teacher.Id}) is not assigned to course {grade.Course.Name}."
                );  
        }

        public void AddGrade(Teacher teacher, Student student, Grade grade) {
            // Helper function just to check exceptions.
            ValidateGrade(teacher, student, grade);

            if (student == null) 
                throw new StudentNotFoundException("Student cannot be null.");

            if (teacher == null)
                throw new TeacherNotFoundException("Teacher cannot be null.");
            
            student.Grades.Add(grade);
        }

        public double CalculateAverageGrade(Student student, Course course) {
            if (student == null) 
                throw new StudentNotFoundException("Student cannot be null.");

            if (!student.Courses.Contains(course)) 
                throw new InvalidGradeException(
                    $"Student {student.Name} ({student.Id}) is not enrolled in course {(course.Name)}."
                );

            double AverageGrade = 0;

            foreach (var grade in student.Grades) {
                if (grade.Course == course) {
                    AverageGrade += grade.Score;
                }
            }

            return AverageGrade;
        }
    }
}
