namespace WebAppAdd.Entities
{
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Student> Students { get; set; } // navigation property


    }
}
