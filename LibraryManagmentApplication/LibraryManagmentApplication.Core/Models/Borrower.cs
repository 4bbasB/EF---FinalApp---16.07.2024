namespace LibraryManagmentApplication.Core.Models;

public class Borrower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int BookId { get; set; }
    public List<Book> Books { get; set; }
}
