using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_6._3
{
	public class Book : Literary_sources
	{ 
		public override int CalculateWordsPerPage()
		{
			if (NumPages > 0)
			{
				return (int)WordCount / NumPages;
			}
			else
			{
				Console.WriteLine("Кількість сторінок не може бути 0 або менше.");
				return 0;
			}
		}

		public override bool IsLargeBook()
		{
			if (NumPages >= 500)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		public override double WordsPerPage
		{
			get { return CalculateWordsPerPage(); }
		}



		public override bool BigorSmall
		{
			get
			{
				return NumPages >= 500;
			}
		}


	
		public Book() : base () { }


		public Book(string title, string author, int numPages, int wordCount, string publisher, int yearPublished, 
			string language, string genre, int onthepage, bool sizeofbook) : base (title, author, numPages, wordCount,
				publisher, yearPublished,language, genre, onthepage, sizeofbook)
		{
		}
	}
}
