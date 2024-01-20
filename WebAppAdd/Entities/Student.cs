namespace WebAppAdd.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public School School { get; set; }
        public int Sch { get; set; } // foreign key

    }
}
