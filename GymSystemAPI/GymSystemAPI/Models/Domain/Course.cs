namespace GymSystemAPI.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string FirstDay { get; set; } = "";
        public string SecondDay { get; set; } = "";
        public string ThirdDay { get; set; } = "";
        public string ForthDay { get; set; } = "";
        public string FifthDay { get; set; } = "";

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int Exerciseid { get; set; }

        public Exersice Exercise { get; set; }

    }
}
