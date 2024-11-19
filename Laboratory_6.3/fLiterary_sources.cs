using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_6._3
{
	public partial class fLiterary_sources : Form
	{
		public fLiterary_sources(Literary_sources t)
		{
			TheLiterary_sources = t;
			InitializeComponent();
		}

		public Literary_sources TheLiterary_sources;

		private void fBook_Load(object sender, EventArgs e)
		{
			if (TheLiterary_sources != null)
			{
				tbName.Text = TheLiterary_sources.Title;
				tbAuthor.Text = TheLiterary_sources.Author;
				tbLanguage.Text = TheLiterary_sources.Language;
				tbYearPublished.Text = TheLiterary_sources.YearPublished.ToString();
				tbGenre.Text = TheLiterary_sources.Genre;
				tbPublisher.Text = TheLiterary_sources.Publisher;
				tbNumPages.Text = TheLiterary_sources.NumPages.ToString();
				tbWordCount.Text = TheLiterary_sources.WordCount.ToString();
			}


		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			TheLiterary_sources.Title = tbName.Text.Trim();
			TheLiterary_sources.Author = tbAuthor.Text.Trim();
			TheLiterary_sources.Language = tbLanguage.Text.Trim();
			TheLiterary_sources.YearPublished = int.Parse(tbYearPublished.Text.Trim());
			TheLiterary_sources.Genre = tbGenre.Text.Trim();
			TheLiterary_sources.Publisher = tbPublisher.Text.Trim();
			TheLiterary_sources.NumPages = int.Parse(tbNumPages.Text.Trim());
			TheLiterary_sources.WordCount = int.Parse(tbWordCount.Text.Trim());

			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		
	}
}
