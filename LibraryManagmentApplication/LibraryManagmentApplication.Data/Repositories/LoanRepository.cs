using LibraryManagmentApplication.Core.Models;
using LibraryManagmentApplication.Core.Repositories;

namespace LibraryManagmentApplication.Data.Repositories;

public class LoanRepository : GenericRepository<Loan>, ILoanRepository { }