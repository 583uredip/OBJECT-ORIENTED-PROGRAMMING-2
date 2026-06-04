using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labexam1
{
    class Book
    {
        private string bookName;
        private string bookAuthor;
        private string bookId;
        private string bookType;
        private int bookCopy;
        private static int bookCounter = 0;


        public Book()
        {

        }

        public Book(string bookName, string bookAuthor, string bookId, string bookType, int bookCopy)
        {
            this.bookName = bookName;
            this.bookAuthor = bookAuthor;
            this.bookId = bookId;
            this.bookType = bookType;
            this.bookCopy = bookCopy;
            bookCounter++;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Book Name:"+bookName);
            Console.WriteLine("Author Name:" + bookAuthor);
            Console.WriteLine("Book Id:" +bookId);
            Console.WriteLine("Book Type:" + bookType);
            Console.WriteLine("Book Copy:" + bookCopy);
            Console.WriteLine("------------------------------------");

        }
        public void AddBookCopy(int x)
        {
            bookCopy += x;
        }
        public static void ShowTotalBookInfo()
        {
            Console.WriteLine("Show Total Object Credit:"+bookCounter);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book[] b = new Book[3];
            b[0] = new Book("C# Programming", "Herbert Schildt", "B101", "Programming", 5);
            b[1]= new Book("Data Structures", "Mark Allen", "B102", "CS", 3);
            b[2] = new Book("Algorithm", "CLRS", "B103", "CS", 2);
            for(int i=0;i<b.Length;i++)
            {
                b[i].ShowInfo();
            }
            Book.ShowTotalBookInfo();
            Console.ReadKey();
        }
    }
}
