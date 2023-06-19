using System.ComponentModel.DataAnnotations;

namespace ProjectSOA.Models
{
    public class Book
    {
        public string Title { get; set; }
        [Key]
        public int bId { get; set; }

        public bool availability { get; set; }

        public string Genre { get; set; }


        public Author Author { get; set; }

        public int Written { get; set; }

    }
}
