// create a 'BookCollection' class that represents a collection of books and allows the collection to be searched based on the topics of the books.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder
{
    /// <summary>
    /// Simple representation of a book with its title and topics.
    /// - Do not change this code - 
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        private List<string> topics;

        /// <summary>
        /// Constructs a book object with the provided title and topics.
        /// </summary>
        /// <param name="title">String representing the title of the book.</param>
        /// <param name="topics">List of significant topics in the book</param>
        public Book(string title, List<string> topics)
        {
            Title = title;
            this.topics = topics;
        }

        /// <summary>
        /// Returns whether the book contains the provided topic.
        /// </summary>
        /// <param name="topic">Topic to check for</param>
        /// <returns>True if the book contains the topic, false otherwise</returns>
        public bool ContainsTopic(string topic)
        {
            return topics.Contains(topic);
        }
    }


    public class BookCollection
    {
        private List<Book> books;
        private List<Book> bookCollect;

        /// Implement your BookCollection class here
        public BookCollection()
        {
            bookCollect = new List<Book>();
        }

        public BookCollection(List<Book> books)
        {
            bookCollect = new List<Book>();
            bookCollect.AddRange(books);
        }
        public void AddBook(Book book)
        {
            bookCollect.Add(book);
        }

        public List<Book> GetBooks()
        {
            return bookCollect;
        }
        public List<string> BooksWithTopic(string topic)
        {
            List<string> result = new List<string>();
            foreach (var book in bookCollect)
            {
                if (book.ContainsTopic(topic))
                {
                    result.Add(book.Title);
                }
            }
            return result;
        }

        public List<string> BooksWithAnyTopic(string[] topics)
        {
            List<string> result = new List<string>();
            List<string> noDupes = new List<string>();
            foreach (var item in topics)
            {
                result.AddRange(BooksWithTopic(item));
            }
            //removing duplicates in a list using linq
            noDupes = result.Distinct().ToList();


            return noDupes;
        }

        public List<string> BooksWithAllTopics(string[] topics)
        {
            List<string> result = new List<string>();
            List<string> duplicates = new List<string>();
            foreach (var item in topics)
            {
                result.AddRange(BooksWithTopic(item));
            }
            // the Groupby groups the elements that are the same together and the Where filters out the elements that appear once 
            //and is not equal to number of topics. Group by returns a set of collection.strings will be in a collection and each collection
            //will have a key and an inner collection.GroupBy returns IEnumerable<IGrouping<TKey,Strings>> which is why in Select you used g.key.
            //The collection here is <string,string>.The key is the same as inner collection string.
            //where(g=> g.Count()>1 ...) will essentially count the number of same collections and checks whether the number is equal to topic length.
            duplicates = result.GroupBy(x => x)
                            .Where(g => g.Count() > 1 && g.Count() == topics.Length)
                            .Select(g => g.Key)
                            .ToList();
            return duplicates;


        }

    }

    /// <summary>
    /// Simple tester for the program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create list of books for the collection
            List<Book> books = new List<Book>() {
                new Book("Game of Thrones", new List<string>() { "fantasy", "dragons", "drama",
                    "fiction", "king", "queen", "medieval", "epic"}),
                new Book("The Fellowship of the Ring", new List<string>() {"fantasy", "fiction",
                    "epic", "wizard", "elves"}),
                new Book("Small Gods", new List<string>() {"fantasy", "fiction", "religion",
                    "philosophy", "satire"}),
                new Book("The Gene: An Intimate History", new List<string>() {"non-fiction",
                    "science", "genetics", "medicine" }),
                new Book("Sapiens: A brief History of Humankind", new List<string>() {"non-fiction",
                    "anthropology", "evolution", "history"}),
                new Book("The Martian", new List<string>() {"fiction", "science", "science fiction",
                    "space" })
            };
            BookCollection library = new BookCollection(books);
            foreach (var item in library.GetBooks())
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine();
            // Some simple test cases are included here - you may want to test more. 
            // The AMS will not use the same test cases.
            // Check for single topic:
            string topic = "fantasy";
            List<string> results = library.BooksWithTopic(topic);
            // Display results
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // Check for any of several topics 
            string[] topics = new string[] { "science", "fiction" };
            results = library.BooksWithAnyTopic(topics);
            // Display results
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            // Check for all of several topics
            results = library.BooksWithAllTopics(topics);
            // Display results
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }


            // Exit
            Console.WriteLine("\n\nPress enter to exit.");
            Console.ReadLine();
        }

        // You might want to write some simple helper methods for displaying lists here 
        // (Remember DRY [Don't Repeat Yourself]- if you're writing the same chunk of code 
        // over and over, it should probably be a method!)

    }

}

