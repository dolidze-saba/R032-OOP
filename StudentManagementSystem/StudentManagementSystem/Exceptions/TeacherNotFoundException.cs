using System;

namespace StudentManagementSystem.Exceptions {
    public class TeacherNotFoundException : Exception { 
        public TeacherNotFoundException() 
        {
        }

        public TeacherNotFoundException(string message) 
            : base(message) 
        {
        }

        public TeacherNotFoundException(string message, Exception innerException) 
            : base(message, innerException) 
        {
        }
    }
}
