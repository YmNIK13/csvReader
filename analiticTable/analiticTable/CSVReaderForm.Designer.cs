namespace analiticTable
{
    partial class CSVReaderForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Корень", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateProgect = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tv_MainTree = new System.Windows.Forms.TreeView();
            this.dgMainTable = new System.Windows.Forms.DataGridView();
            this.fileCSV = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(884, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateProgect,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miCreateProgect
            // 
            this.miCreateProgect.Name = "miCreateProgect";
            this.miCreateProgect.Size = new System.Drawing.Size(158, 22);
            this.miCreateProgect.Text = "Создать проект";
            this.miCreateProgect.Click += new System.EventHandler(this.miCreateProgect_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tv_MainTree
            // 
            this.tv_MainTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_MainTree.Location = new System.Drawing.Point(0, 24);
            this.tv_MainTree.Name = "tv_MainTree";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Узел1";
            treeNode2.BackColor = System.Drawing.Color.Aqua;
            treeNode2.ForeColor = System.Drawing.Color.Blue;
            treeNode2.Name = "root";
            treeNode2.Text = "Корень";
            treeNode2.ToolTipText = "Корнище";
            this.tv_MainTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tv_MainTree.Size = new System.Drawing.Size(186, 378);
            this.tv_MainTree.TabIndex = 1;
            // 
            // dgMainTable
            // 
            this.dgMainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMainTable.Location = new System.Drawing.Point(186, 24);
            this.dgMainTable.Name = "dgMainTable";
            this.dgMainTable.Size = new System.Drawing.Size(698, 378);
            this.dgMainTable.TabIndex = 2;
            // 
            // fileCSV
            // 
            this.fileCSV.Filter = "\"*.csv - файлы|*.csv|Все файлы|*.*\"";
            // 
            // CSVReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 402);
            this.Controls.Add(this.dgMainTable);
            this.Controls.Add(this.tv_MainTree);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "CSVReaderForm";
            this.Text = "CSV Reader";
            this.Load += new System.EventHandler(this.CSVReaderForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMainTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView tv_MainTree;
        private System.Windows.Forms.DataGridView dgMainTable;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileCSV;
        private System.Windows.Forms.ToolStripMenuItem miCreateProgect;
    }
}

