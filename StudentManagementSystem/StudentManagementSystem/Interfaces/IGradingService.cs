using StudentManagementSystem.Model;

namespace StudentManagementSystem.Interfaces {
    internal interface IGradingService {
        void AddGrade(Teacher teacher, Student student, Grade grade); 

        double CalculateAverageGrade(Student student, Course course);
    }
}
