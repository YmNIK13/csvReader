using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace analiticTable
{
    [Serializable]
    public class DataBaseCSV
    {
        public string pathProject;
        public List<Branch> listBranch = new List<Branch>();

        /// <summary>
        /// Создать базу дуанных
        /// </summary>
        /// <param name="path">путь к проекту</param>
        /// <param name="branch">Лист путей к отдельно выбранным веткам</param>
        public DataBaseCSV(string path, List<string> branch)
        {
            pathProject = path;

            foreach (string item in branch)
            {
                listBranch.Add(new Branch(path, item));
            }
        }
    }
}
