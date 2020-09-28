using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToObjects
{
    class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishYear { get; set; }

        public Book(string title, int authorId, int year)
        {
            this.Title = title;
            this.AuthorId = authorId;
            this.PublishYear = year;
        }

        public override string ToString()
        {
            return $"{Title} - {PublishYear}";
        }
    }

    class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author (int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book("The da Vinci Code", 1, 2000),
                new Book("Origin",1, 2017),
                new Book("The girl with the dragon tattoo",2, 2005),
                new Book("The girl who played with fire",2, 2006),
                new Book("The girl Who Kicked the Hornets' Nest", 2, 2007),
                new Book("The burning chambers", 3, 2018)
            };   

            List<Author> authors = new List<Author>
            {
                new Author(1, "Dan", "Brown"),
                new Author(2, "Stieg", "Larsson"),
                new Author(3, "Kate", "Mosse")
            };
        
            PrintBooks<Book>("Original list", books);

            var allBooks = from book in books select book;
            PrintBooks<Book>("All books", allBooks);

            //order by title
            var ordered = from book in books
                          orderby book.Title.ToLower() 
                          descending select book;

            PrintBooks<Book>("Ordered by titles", ordered);

            //filter
            var before2010 = from book in books
                             where book.PublishYear < 2010
                             select book;

            PrintBooks<Book>("Books before 2010", before2010);

        
            //filter on multiple criteria

            //filter and project out title
            var justTitlesAfter2010 = from book in books
                                      where book.PublishYear > 2010
                                      select book.Title;

            PrintBooks<string>("Titles of books after 2010", justTitlesAfter2010);

            //join books with authors
            var withAuthors = from book in books
                              join author in authors on book.AuthorId 
                                    equals author.Id
                              select new { Book = book.Title, Author = author.FirstName + " " + author.LastName };
            Console.WriteLine("Join books with authors:");
            foreach (var bookAndAuthor in withAuthors)
            {
                Console.WriteLine("{0}, {1}", bookAndAuthor.Book, bookAndAuthor.Author);
            }


            //Demo van GroupJoin: join books with authors
            var joinAuthorsWithBooks = from author in authors
                              join book in books on author.Id
                                    equals book.AuthorId
                              into g
                              select new { Author = author.FirstName + " " + author.LastName, Books = g};

            Console.WriteLine("\n\nJoin authors with their books:");

            // expressie om boektitels af te drukken
            Func<string, Book, string> JoinTitles = (ts, t) => ts + (ts == "" ? "" : ", ") + t;
            foreach (var authorAndBook in joinAuthorsWithBooks)
            {
                Console.WriteLine("{0} wrote the books: {1}"
                    , authorAndBook.Author
                    , authorAndBook.Books.Aggregate("", JoinTitles));
            }

            Console.ReadKey();            
        }



        static void PrintBooks<T>(string title, IEnumerable<T> books)
        {
            Console.WriteLine($"{title}:");
            string allbooks = books.Aggregate("", (bs, b) => bs + "\n" + b);
            Console.WriteLine(allbooks);
    
            Console.WriteLine();
        }
    }
}
