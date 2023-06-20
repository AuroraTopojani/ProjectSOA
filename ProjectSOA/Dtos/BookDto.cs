using ProjectSOA.Models;

namespace ProjectSOA.Dtos
{
    public class BookDto
    {
        public int bId { get; set; }
        public string Title { get; set; }
        

        public bool availability { get; set; }

        public string Genre { get; set; }


        public Author Author { get; set; }

      
    }
}
