using System;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Exceptions {
    public class DuplicatePersonException : Exception {
        public int PersonId { get; }
        public string PersonName { get; }

        public DuplicatePersonException(Person person)
            : base($"Person with ID {person.Id} already exists (conflict with '{person.Name}').") {
            PersonId = person.Id;
            PersonName = person.Name;
        }

        public DuplicatePersonException(string message)
            : base(message) {
        }

        public DuplicatePersonException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
