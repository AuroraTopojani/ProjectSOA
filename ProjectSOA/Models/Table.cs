namespace ProjectSOA.Models
{
    public class Table
    {
        public int tId { get; set; }
        public bool tAvailability { get; set; }

        public ICollection<Student> students { get; set; }
    }
}
