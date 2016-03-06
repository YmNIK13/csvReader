using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace analiticTable
{
    public partial class CSVReaderForm : Form
    {
        public CSVReaderForm()
        {
            InitializeComponent();
        }



        private void CSVReaderForm_Load(object sender, EventArgs e)
        {
            //
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileCSV.ShowDialog();

            TableCSV table = new TableCSV(fileCSV.FileName);


            //создаём таблицу
            DataTable dt = new DataTable(table.NameTable);

            for (int i = 0; i < table._listCol.Length; i++)
            {
                //создаём колонки
                DataColumn col = new DataColumn(table._listCol[i].GetName, typeof(String));

                //добавляем колонки в таблицу
                dt.Columns.Add(col);
            }

            dgMainTable.DataSource = dt;


            this.Text = table.NameTable;
        }
    }
}
