using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // читаем список из xml файла
        private void button4_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (dataGridView1.RowCount > 0)
            {
                DialogResult result = MessageBox.Show("данные будут удалены!", "внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    ok = true;
                }
            }
            else { ok = true; }
            if (ok)
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;
                    XMLWorker worker = new XMLWorker();
                    List<Book> list = worker.DesirealizeXML(file);

                    dataGridView1.RowCount = list.Count()+1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = list[i].Title;
                        dataGridView1.Rows[i].Cells[1].Value = list[i].Author;
                        dataGridView1.Rows[i].Cells[2].Value = list[i].Year;
                    }
                }
            }
                

        }

        // сохранить список в файл
        private void button5_Click(object sender, EventArgs e)
        {
            List<Book> list = new List<Book>();
            try
            {
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    string title = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string author = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    int year = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString().Length != 4) 
                    {
                        throw new Exception("Неверно введен год!");
                    }
                    list.Add(new Book(title, author, year));
                }

                saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = saveFileDialog1.FileName;
                    XMLWorker worker = new XMLWorker();
                    worker.SerializeXML(list, file);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка ввода!");
            }
            
        }
    }
}
