namespace Langs.Models.Books
{
    public class BookIndexModel
    {
        public (int ID, string Name, string LanguageName, string Description, int WordCount)[] Books { get; set; }
    }
}
