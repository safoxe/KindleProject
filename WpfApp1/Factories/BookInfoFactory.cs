using KindleReader.Model;

namespace KindleReader.Factories
{
    public class BookInfoFactory
    {
        public static IBookInfo GetAdditionalBookInfoObject()
        {
            return new AdditionalBookInfo();
        }
    }
}
