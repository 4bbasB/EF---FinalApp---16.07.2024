using LibraryManagmentApplication.Business.Services.Implementations;
using LibraryManagmentApplication.Business.Services.Interfaces;
using LibraryManagmentApplication.Core.Models;

namespace LibraryManagmentApplication.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAuthorService authorService = new AuthorService();
            IBookService bookService = new BookService();
            IBorrowerService borrowerService = new BorrowerService();
            ILoanService loanService = new LoanService();

            while (true)
            {
                ShowMenu();

                int choice = Choice();

                switch (choice)
                {
                    case 1:
                        AuthorMenu(authorService);
                        break;
                    case 2:
                        BookMenu(bookService);
                        break;
                    case 3:
                        BorrowerMenu(borrowerService);
                        break;
                    case 9:
                        Console.WriteLine("Enter the title to filter:");
                        string titleFilter = EnterValidString();
                        List<Book> filteredBooksByTitle = bookService.FilterBooksByTitle(titleFilter);
                        filteredBooksByTitle.ForEach(b => Console.WriteLine($"{b.Id} - {b.Title} ({b.PublishedYear})"));
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1) Author actions");
            Console.WriteLine("2) Book actions");
            Console.WriteLine("3) Borrower actions");
            //Console.WriteLine("4) Borrow Book");
            //Console.WriteLine("5) Return Book");
            //Console.WriteLine("6) Most Borrowed Book");
            //Console.WriteLine("7) Delayed Borrowers");
            //Console.WriteLine("8) Borrowers' Books");
            Console.WriteLine("9) Filter Books By Title");
            Console.WriteLine("10) Filter Books By Author");
            Console.WriteLine("0) Exit");
            Console.Write("Enter your choice: ");

        }


        private static void AuthorMenu(IAuthorService authorService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Author Menu:");
                Console.WriteLine("1 - All Authors");
                Console.WriteLine("2 - Create new Author");
                Console.WriteLine("3 - Edit Author");
                Console.WriteLine("4 - Delete Author");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = Choice();

                switch (choice)
                {
                    case 1:
                        List<Author> authors = authorService.GetAll();
                        if (authors == null || authors.Count == 0)
                            Console.WriteLine("No Author found!");
                        else
                            authors.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));

                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Author newAuthor = CreateAuthor();
                        authorService.CreateAsync(newAuthor);
                        Console.WriteLine("Author created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Author> authorsToUpdate = authorService.GetAll();
                        if (authorsToUpdate == null || authorsToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Author found!");
                        }
                        else
                        {
                            authorsToUpdate.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                            Console.Write("Enter Id of the author to update: ");
                            int updateId = Choice();
                            var authorToUpdate = authorsToUpdate.FirstOrDefault(a => a.Id == updateId);
                            if (authorToUpdate != null)
                            {
                                Console.Write("Enter new name: ");
                                authorToUpdate.Name = EnterValidString();
                                authorService.UpdateAsync(authorToUpdate);
                                Console.WriteLine("Author updated successfully!");
                            }
                            else
                                Console.WriteLine("Author not found!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Author> authorsToDelete = authorService.GetAll();
                        if (authorsToDelete == null || authorsToDelete.Count == 0)
                        {
                            Console.WriteLine("No Author found!");
                        }
                        else
                        {
                            authorsToDelete.ForEach(a => Console.WriteLine(a.Id + " " + a.Name));
                            Console.Write("Enter Id of the author to delete: ");
                            int deleteId = Choice();
                            authorService.DeleteAsync(deleteId);
                            Console.WriteLine("Author deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }


        private static void BookMenu(IBookService bookService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Book Menu:");
                Console.WriteLine("1 - List all books");
                Console.WriteLine("2 - Create new book");
                Console.WriteLine("3 - Edit book");
                Console.WriteLine("4 - Delete book");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = Choice();

                switch (choice)
                {
                    case 1:
                        List<Book> books = bookService.GetAll();
                        if (books == null || books.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            books.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Book newBook = CreateBook();
                        bookService.CreateAsync(newBook);
                        Console.WriteLine("Book created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Book> booksToUpdate = bookService.GetAll();
                        if (booksToUpdate == null || booksToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            booksToUpdate.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                            Console.Write("Enter Id of the book to update: ");
                            int updateId = Choice();
                            var bookToUpdate = booksToUpdate.FirstOrDefault(b => b.Id == updateId);
                            if (bookToUpdate != null)
                            {
                                Console.Write("Enter new title: ");
                                bookToUpdate.Title = EnterValidString();
                                Console.WriteLine("Enter new Description:");
                                bookToUpdate.Description = EnterValidString();
                                Console.WriteLine("Enter new Publish Year");
                                bookToUpdate.PublishedYear = Choice();
                                bookService.UpdateAsync(bookToUpdate);
                                Console.WriteLine("Book updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Book not found!");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Book> booksToDelete = bookService.GetAll();
                        if (booksToDelete == null || booksToDelete.Count == 0)
                        {
                            Console.WriteLine("No Book found!");
                        }
                        else
                        {
                            booksToDelete.ForEach(b => Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear));
                            Console.Write("Enter Id of the book to delete: ");
                            int deleteId = Choice();
                            bookService.DeleteAsync(deleteId);
                            Console.WriteLine("Book deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }


        private static void BorrowerMenu(IBorrowerService borrowerService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Borrower Menu:");
                Console.WriteLine("1 - List all borrowers");
                Console.WriteLine("2 - Create new borrower");
                Console.WriteLine("3 - Edit borrower");
                Console.WriteLine("4 - Delete borrower");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Enter your choice: ");
                int choice = Choice();

                switch (choice)
                {
                    case 1:
                        List<Borrower> borrowers = borrowerService.GetAll();
                        if (borrowers == null || borrowers.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowers.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Borrower newBorrower = CreateBorrower();
                        borrowerService.CreateAsync(newBorrower);
                        Console.WriteLine("Borrower created successfully!");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 3:
                        List<Borrower> borrowersToUpdate = borrowerService.GetAll();
                        if (borrowersToUpdate == null || borrowersToUpdate.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowersToUpdate.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                            Console.Write("Enter Id of the borrower to update: ");
                            int updateId = Choice();
                            var borrowerToUpdate = borrowersToUpdate.FirstOrDefault(b => b.Id == updateId);
                            if (borrowerToUpdate != null)
                            {
                                Console.Write("Enter new name: ");
                                borrowerToUpdate.Name = EnterValidString();
                                Console.Write("Entewr new email: ");
                                borrowerToUpdate.Email = EnterValidString();
                                borrowerService.UpdateAsync(borrowerToUpdate);
                                Console.WriteLine("Borrower updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Borrower not found!");
                            }
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        List<Borrower> borrowersToDelete = borrowerService.GetAll();
                        if (borrowersToDelete == null || borrowersToDelete.Count == 0)
                        {
                            Console.WriteLine("No Borrower found!");
                        }
                        else
                        {
                            borrowersToDelete.ForEach(b => Console.WriteLine(b.Id + " " + b.Name + " " + b.Email));
                            Console.Write("Enter Id of the borrower to delete: ");
                            int deleteId = Choice();
                            borrowerService.DeleteAsync(deleteId);
                            Console.WriteLine("Borrower deleted successfully!");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
        public static Author CreateAuthor()
        {
            Author author = new Author();
            Console.WriteLine("Enter Author Name:");
            author.Name = EnterValidString();
            return author;
        }
        public static Book CreateBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter Book Title:");
            book.Title = EnterValidString();
            Console.WriteLine("Enter Book Description:");
            book.Description = EnterValidString();
            Console.WriteLine("Enter Book's Publish Year");
            book.PublishedYear = Choice();
            return book;
        }
        public static Borrower CreateBorrower()
        {
            Borrower borrower = new Borrower();
            Console.WriteLine("Enter Borrower Name:");
            borrower.Name = EnterValidString();
            Console.WriteLine("Enter Borrower's Email:");
            borrower.Email = EnterValidString();
            return borrower;
        }
        public static string EnterValidString()
        {
            string input;
            do
            {
                input = Console.ReadLine();

                if (input is not null)
                    return input;
                else
                    Console.WriteLine("Not a valid input!");
            } while (!true);
            return input;
        }

        public static int Choice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter right!");
                Console.Write("Enter your choice: ");
            }
            return choice;
        }
    }
}
