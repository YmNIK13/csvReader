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
    public partial class OpenProjectDialog : Form
    {
        public OpenProjectDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выбираем проект
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            folderDialog.Description = "Укажите путь к проекту";
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;        
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath != "")
            {
                if (folderDialog.SelectedPath != tbPathToProject.Text)
                {
                    lstBoxPath.Items.Clear();
                }
                tbPathToProject.Text = folderDialog.SelectedPath;
            }

            if (lstBoxPath.Items.Count>0)
            {
                tbPathToProject.Enabled = false;
            }
            else
            {
                tbPathToProject.Enabled = true;
            }               
            
        }

        /// <summary>
        /// Добавляем ветвь для обработки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            folderDialog.Reset();
            folderDialog.Description = "Выберите ветвь";
            folderDialog.SelectedPath = tbPathToProject.Text;
            folderDialog.RootFolder = Environment.SpecialFolder.LocalizedResources;
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath.StartsWith(tbPathToProject.Text))
            {                
                lstBoxPath.Items.Add(folderDialog.SelectedPath.Remove(0, tbPathToProject.Text.Length));
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstBoxPath.SelectedIndex >= 0)
            {
                folderDialog.Reset();
                folderDialog.Description = "Выберите ветвь";
                folderDialog.SelectedPath = tbPathToProject.Text + (string)lstBoxPath.SelectedValue;
                folderDialog.RootFolder = Environment.SpecialFolder.LocalizedResources;
                folderDialog.ShowDialog();

                if (folderDialog.SelectedPath.StartsWith(tbPathToProject.Text))
                {
                    lstBoxPath.SelectedValue = (object)folderDialog.SelectedPath.Remove(0, tbPathToProject.Text.Length);
                }
                lstBoxPath.Items.Remove(lstBoxPath.SelectedItem);
            }
        }

        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstBoxPath.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Вы уверены что хотите уделать ветвь: /n" + (string)lstBoxPath.SelectedValue, 
                    "Удалить ветвь?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lstBoxPath.Items.Remove(lstBoxPath.SelectedItem);
                }
            }
        }


        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        /// <summary>
        /// Получить путь к проекту
        /// </summary>
        public string GetPathPriject
        {
            get {

                return tbPathToProject.Text;
            }
        }

        /// <summary>
        /// Получить лист отдельных выбранных веток
        /// </summary>
        public List<string> GetListBranch
        {
            get
            {
                List<string> myVar = new List<string>();
                foreach (string item in lstBoxPath.Items)
                {
                    myVar.Add(item);
                }
                return myVar;
            }
        }


        /// <summary>
        /// Удалить выбранны ветки если изменился путь к проекту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPathToProject_TextChanged(object sender, EventArgs e)
        {
            if (folderDialog.SelectedPath != tbPathToProject.Text)
            {
                lstBoxPath.Items.Clear();
            }
        }


    }
}
