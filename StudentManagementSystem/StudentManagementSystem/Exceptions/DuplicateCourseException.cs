using System;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Exceptions {
    public class DuplicateCourseException : Exception {
        public int CourseId { get; }
        public string CourseName { get; }

        public DuplicateCourseException(Course course)
            : base($"Course ID {course.Id} already exists (conflict with '{course.Name}').") {
            CourseId = course.Id;
            CourseName = course.Name;
        }

        public DuplicateCourseException(string message)
            : base(message) {
        }

        public DuplicateCourseException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
