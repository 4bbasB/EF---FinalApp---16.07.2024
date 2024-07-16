namespace LibraryManagmentApplication.Core.Models;

public class Loan
{
    public int Id { get; set; }
    public int BorrowerId { get; set; }
    public Borrower Borrower { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime MustReturnDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public List<LoanItem> LoanItems { get; set; }
}
