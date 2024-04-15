using APIRest_ASP.Data.VO;
using APIRest_ASP.Model;

namespace APIRest_ASP.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
