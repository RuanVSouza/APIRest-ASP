using APIRest_ASP.Data.Converter.Contract;
using APIRest_ASP.Data.VO;
using APIRest_ASP.Model;

namespace APIRest_ASP.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {

        //VO para person
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
                return new Book
                {
                    Id = origin.Id,
                    Title = origin.Title,
                    Author = origin.Author,
                    Price = origin.Price,
                    LaunchDate = origin.LaunchDate,
                };

        }

        public List<Book> Parse(List<BookVO> origin)
        {

            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        //Person para VO
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
