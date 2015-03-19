using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOS
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book() { }
        public Book(string title, string author, int year)
        {
            this.Author = author;
            this.Title = title;
            this.Year = year;
        }
    }
}