using System.ComponentModel.DataAnnotations;

namespace ProjectSOA.Models
{
    public class BookTable
    {
        [Key]
        public int tId { get; set; }
        public bool tAvailability { get; set; }

       
    }
}
