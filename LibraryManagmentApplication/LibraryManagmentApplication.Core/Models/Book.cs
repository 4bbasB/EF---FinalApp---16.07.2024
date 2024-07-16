namespace LibraryManagmentApplication.Core.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int PublishedYear { get; set; }
    public int? BorrowerId { get; set; }
    public Borrower? Borrower { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
    public List<LoanItem> LoanItems { get; set; }
}
