using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_6._3
{
    public abstract class Literary_sources
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumPages { get; set; }
        public int WordCount { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public int Onthepage { get; set; }
        public bool SizeofBook { get; set; }

        public Literary_sources() { }


        public Literary_sources(string title, string author, int numPages, int wordCount, string publisher, int yearPublished,
            string language, string genre, int onthepage, bool sizeofbook)
        {
            Title = title;
            Author = author;
            NumPages = numPages;
            WordCount = wordCount;
            Publisher = publisher;
            YearPublished = yearPublished;
            Language = language;
            Genre = genre;
            Onthepage = onthepage;
            SizeofBook = sizeofbook;
        }

        public abstract bool BigorSmall { get; }
        public abstract double WordsPerPage { get; }
        public abstract bool IsLargeBook();
        public abstract int CalculateWordsPerPage();
    }
}
