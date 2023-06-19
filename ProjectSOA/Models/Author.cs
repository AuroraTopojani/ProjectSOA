using System.ComponentModel.DataAnnotations;

namespace ProjectSOA.Models
{
    public class Author
    {
        [Key]
        public int AId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Born { get; set; }
       
    }
}
