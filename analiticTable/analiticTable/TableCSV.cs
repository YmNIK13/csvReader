using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace analiticTable
{
    public class TableCSV
    {
        private string _path;
        private string _nameFie;
        private string _extension;
        private char[] _separators;


        public ColumnCSV[] _listCol;



        public TableCSV(string path, char separator = ';')
        {
            this._path = path;
            FileInfo file = new FileInfo(path);
            this._separators = new char[1];
            this._separators[0] = separator;

            CreateTable(file);
        }

        public TableCSV(string path, char[] separator)
        {
            this._path = path;
            FileInfo file = new FileInfo(path);
            this._separators.CopyTo(separator, 0);

            CreateTable(file);
        }

        private void CreateTable(FileInfo file)
        {
            this._nameFie = file.Name;
            this._extension = file.Extension;

            this._nameTable = file.Name.Remove(file.Name.Length - file.Extension.Length);

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(this._path))
            {
                string firstString = "";
                if ((firstString = sr.ReadLine()) != null)
                {
                    FirstString(firstString);
                }
            }
        }




        private string _nameTable;

        public string NameTable
        {
            get { return _nameTable; }
            set { _nameTable = value; }
        }


        private void FirstString(string str)
        {
            string[] first = str.Split(this._separators);

            this._listCol = new ColumnCSV[first.Length];

            for (int i = 0; i < first.Length; i++)
            {
                this._listCol[i] = new ColumnCSV(first[i]);
            }
        }


    }
}