using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Using the Bookstore classes:
namespace BookTestClient
{
    using Bookstore;

    // Class to total and average prices of books:
    class PriceTotaller  {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book) {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice() {
            return priceBooks / countBooks;
        }
    }

    // Class to test the book database:
    class Test
    {
        // Print the title of the book.
        static void PrintTitle(Book b) {
            Console.WriteLine("   {0}", b.Title);
        }

        // Execution starts here.
        static void Main() {
            BookStore bookStore = new BookStore();

            // Initialize the database with some books:
            AddBooks(bookStore);

            // Print all the titles of paperbacks:
            Console.WriteLine("Paperback Book Titles:");
            // Create a new delegate object associated with the static method Test.PrintTitle:
            // in oudere C# versies: 
            // bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));
            bookStore.ProcessPaperbackBooks(PrintTitle);

            // Get the average price of a paperback by using
            // a PriceTotaller object:
            PriceTotaller totaller = new PriceTotaller();
            // Create a new delegate object associated with the nonstatic 
            // method AddBookToTotal on the object totaller:
            bookStore.ProcessPaperbackBooks(totaller.AddBookToTotal);
            Console.WriteLine($"Average Paperback Book Price: {totaller.AveragePrice():#.##}");
        }

        // Initialize the book database with some test books:
        static void AddBooks(BookStore bookDB)  {
            bookDB.AddBook("Life 3.0", "Max Tegmark", 19.95m, true);
            bookDB.AddBook("Professional Android 4th edition", "Reto Meijer", 28.50m, false);
            bookDB.AddBook("It","Stephan King", 27m, true);
            bookDB.AddBook("Origin","Dan Brown", 17.95m, true);
        }
    }
}
