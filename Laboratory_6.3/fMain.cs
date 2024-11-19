﻿using Laboratory_6._3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_6._3
{
	public partial class fMain : Form
	{
		public fMain()
		{
			InitializeComponent();
			this.Width = 990;
			this.Height = 400;
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			gvBooks.AutoGenerateColumns = false;

			DataGridViewColumn column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "title";
			column.Name = "Назва";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "author";
			column.Name = "Автор";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "NumPages";
			column.Name = "Кільість сторінок";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "WordCount"; 
			column.Name = "Загальна кількість слів";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "publisher";
			column.Name = "Видавництво";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "yearpublished";
			column.Name = "Рік опублікування";
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "language";
			column.Name = "Мова";
			column.Width = 60;
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "genre";
			column.Name = "Жанр";
			column.Width = 60;
			gvBooks.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "WordsPerPage"; 
			column.Name = "Кількість слів на одній сторінці";
			gvBooks.Columns.Add(column);

			column = new DataGridViewCheckBoxColumn();
			column.DataPropertyName = "BigorSmall";
			column.Name = "Книжка велика";
			gvBooks.Columns.Add(column);


			bindSrcBooks.Add(new Book ("Фах","Айзек Азімов", 40, 12000, "Astounding Science Fiction", 1957,
				"англійська", "наукова фантастика", 300, false));
			EventArgs args = new EventArgs(); OnResize(args);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Literary_sources literary_sources = new Book();

			fLiterary_sources ft = new fLiterary_sources(literary_sources);
			if (ft.ShowDialog() == DialogResult.OK)
			{
				bindSrcBooks.Add(literary_sources);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Literary_sources literary_sources = (Literary_sources)bindSrcBooks.List[bindSrcBooks.Position];

			fLiterary_sources fb = new fLiterary_sources(literary_sources);
			if (fb.ShowDialog() == DialogResult.OK)
			{
				bindSrcBooks.List[bindSrcBooks.Position] = literary_sources;
			}
		}


		private void btnDel_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Видалити поточний запис?", "Видалення запису",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
			{
				bindSrcBooks.RemoveCurrent();

			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Очистити таблицю?\n\nВсі дані будуть втрачені", "Очищення даних",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				bindSrcBooks.Clear();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Закрити застосунок?", "Вихід з програми", MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void fMain_Resize(object sender, EventArgs e)
		{
			int buttonsSize = 9 * btnAdd.Width + 3 * tsSeparator1.Width + 30;
			btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
		}

        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
			saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog.Title = "Зберегти дані у текстовому форматі";
			saveFileDialog.InitialDirectory = Application.StartupPath;
			StreamWriter sw;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8);
				try
				{
					foreach (Literary_sources literary_sources in bindSrcBooks.List)
					{
						sw.Write(literary_sources.Title + "\t" + literary_sources.Author + "\t" + literary_sources.NumPages + "\t" +
							literary_sources.WordCount + "\t" + literary_sources.Publisher + "\t" + literary_sources.YearPublished + "\t" +
							literary_sources.Language + "\t" + literary_sources.Genre + "\t" + literary_sources.Onthepage + "\t" + literary_sources.SizeofBook + "\t\n");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Сталась помилка: \n{0}", ex.Message, 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally { sw.Close(); }
			}
        }

        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Файли даних (*.books)|*.books|All files (*.*)|*.*";
            saveFileDialog.Title = "Зберегти дані у бінарному форматі";
            saveFileDialog.InitialDirectory = Application.StartupPath;
			BinaryWriter bw;
			if (saveFileDialog.ShowDialog() == DialogResult.OK )
			{
				bw = new BinaryWriter (saveFileDialog.OpenFile());
				try
				{
					foreach (Literary_sources literary_sources in bindSrcBooks.List)
					{
						bw.Write(literary_sources.Title);
						bw.Write(literary_sources.Author);
						bw.Write(literary_sources.NumPages);
						bw.Write(literary_sources.WordCount);
						bw.Write(literary_sources.Publisher);
						bw.Write(literary_sources.YearPublished);
						bw.Write(literary_sources.Language);
						bw.Write(literary_sources.Genre);
						bw.Write(literary_sources.Onthepage);
						bw.Write(literary_sources.SizeofBook);
					}
				}
				catch (IOException ex) 
				{ 
					MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally { bw.Close(); }
			}
        }

        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
			OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Прочитати дані у текстовому форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
			StreamReader sr;
			if (openFileDialog.ShowDialog() == DialogResult.OK )
			{
				bindSrcBooks.Clear();
				sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
				string s;
				try
				{
					while ((s=sr.ReadLine()) != null)
					{
						string[] split = s.Split('\t');
						Literary_sources literary_sources = new Book(split[0], split[1], int.Parse(split[2]), int.Parse(split[3]),
							split[4], int.Parse(split[5]), split[6], split[7], int.Parse(split[8]), bool.Parse(split[9]));
						bindSrcBooks.Add(literary_sources);
					}
				}
				catch (Exception ex) 
				{ 
					MessageBox.Show("Сталась помилка: \n{0}", ex.Message, 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally { sr.Close(); }
			}
        }

        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли даних (*.books)|*.books|All files (*.*)|*.*";
            openFileDialog.Title = "Прочитати дані у бінарному форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
			BinaryReader br;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				bindSrcBooks.Clear();
				br = new BinaryReader(openFileDialog.OpenFile());
				try
				{
					Literary_sources literary_sources;
					while (br.BaseStream.Position < br.BaseStream.Length)
					{
						literary_sources = new Book();
						for (int i=1; i<=10; i++)
						{
							switch (i)
							{
								case 1:
									literary_sources.Title = br.ReadString(); break;
								case 2:
									literary_sources.Author = br.ReadString(); break;
								case 3:
									literary_sources.NumPages = br.ReadInt32(); break;
								case 4:
									literary_sources.WordCount = br.ReadInt32(); break;
								case 5:
									literary_sources.Publisher = br.ReadString(); break;
								case 6:
									literary_sources.YearPublished = br.ReadInt32(); break;
								case 7:
									literary_sources.Language = br.ReadString(); break;
								case 8:
									literary_sources.Genre = br.ReadString(); break;
								case 9:
									literary_sources.Onthepage = br.ReadInt32(); break;
								case 10:
									literary_sources.SizeofBook = br.ReadBoolean(); break;
							}
						}
						bindSrcBooks.Add(literary_sources);
					}
				}
				catch (Exception ex) 
				{ 
					MessageBox.Show("Сталась помилка: \n{0}", ex.Message,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally { br.Close(); }
			}
        }
    }
}
