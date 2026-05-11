namespace StudentManagementSystem.Model {
    public class Grade {
        public double Score { get; set; } 
        public Course Course { get; set; } 

        public Grade(double score, Course course) {
            Score = score;
            Course = course;
        }
    }
}
