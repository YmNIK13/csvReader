using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace analiticTable
{
    public class Branch
    {
        ///физический путь к проекту
        private string projectPath;
        ///ветвь (урезанный путь проекта)
        private string branchPath;

        ///структура файлов
        public FileStruct filesNode;

        ///лист файлов, находящийся в данной ветке
        public List<FileProject> fileBranch = new List<FileProject>();

        /// <summary>
        /// Конструктор ветки
        /// </summary>
        /// <param name="project">путь к проекту</param>
        /// <param name="branch">путь к данной ветке</param>
        public Branch(string project, string branch)
        {
            this.projectPath = project;
            this.branchPath = branch;

            FindFile(this.projectPath + this.branchPath);

            string[] branchMas = branch.Split('\\');
            string nameBranch = branchMas[branchMas.Length - 1];

            filesNode = new FileStruct(nameBranch);

            int countChars = (this.projectPath + this.branchPath).Length - (nameBranch).Length;
            foreach (FileProject filePath in fileBranch)
            {                
                //если совпадает тогда добавляем ***доп проверка на целостность путей***
                if (filePath.GetPath.StartsWith(this.projectPath))
                {
                    filesNode.AddPath(filePath.GetPath.Remove(0, countChars));
                }
            }
        }


        /// <summary>
        /// Посик всех файлов в ветке
        /// </summary>
        /// <param name="path">путь к ветке</param>
        /// <param name="maska">маска поиска</param>
        /// <returns>лист файлов</returns>
        private void FindFile(string path, string maska = "*.csv")
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo item in dirs)
            {
                FindFile(path + '\\' + item.Name);
            }

            foreach (FileInfo f in dir.GetFiles(maska))
            {
                fileBranch.Add(new TableCSV(f.FullName));
            }
        }



    }

    /// <summary>
    /// Класс структуры файлов
    /// </summary>
    public class FileStruct
    {
        //Имя элемента
        string name;
        //Ссылка Предыдущий елемент
        FileStruct prew;
        //Список следующих елекментов
        List<FileStruct> next = new List<FileStruct>();
        //Ссылка на корневой елемент
        FileStruct root;

        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }


        /// <summary>
        /// Конструктор элемента структуры файлов
        /// </summary>
        /// <param name="Name">Имя элемента</param>
        public FileStruct(string Name)
        {
            name = Name;
            root = this;
        }

        /// <summary>
        /// Добавить в структуру новый файл
        /// </summary>
        /// <param name="path">путь к файлу внутри ветки</param>
        public void AddPath(string path)
        {
            string[] pathMass = path.Split('\\');

            //Принадлежит ли файл данной структуре
            if (pathMass[0] == this.root.name)
            {
                string[] newPath;
                Array.Copy(pathMass, 1, newPath = new string[pathMass.Length - 1], 0, pathMass.Length-1);
                AddElement(this.root, newPath);
            }
        }

        /// <summary>
        /// Добавляем или ищем елемент
        /// </summary>
        /// <param name="root">узел</param>
        /// <param name="path">путь к узлу</param>
        /// <returns></returns>
        private bool AddElement(FileStruct root, string[] path)
        {
            //если еще есть елементы
            if (path.Length > 0)
            {
                string[] newPath;
                Array.Copy(path, 1, newPath = new string[path.Length - 1], 0, newPath.LongLength);

                //если такой элемент существует
                FileStruct next = root.IsNext(path[0]);
                //если нет
                if (next == null)
                {
                    //создаем
                    next = root.NewNext(path[0]);
                }
                //следующий блок
                return AddElement(next, newPath);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Добавить следующий елемент в структуру
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private FileStruct NewNext(string Name)
        {
            FileStruct result = new FileStruct(Name);
            result.root = this.root;
            result.prew = this;
            this.next.Add(result);
            return result;
        }

        /// <summary>
        /// Сушествует ли такой следующий элемент с таким именем
        /// </summary>
        /// <param name="name">имя элемента</param>
        /// <returns>если да - то ссылка на элемент иначе NULL</returns>
        private FileStruct IsNext(string name)
        {
            foreach (FileStruct item in next)
            {
                if (item.name == name)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Получить внутренний путь к элементу
        /// </summary>
        public string GetPathThisNode
        {
            get
            {
                string result = "";

                FileStruct node = this;

                while (node != node.root)
                {
                    result = this.name + '\\' + result;
                    node = node.prew;
                }
                return result;
            }
        }


        public TreeNode GetTreeNodeFile
        {
            get
            {
                return ConverToTreeNode(this);
            }
        }

        /// <summary>
        /// преобразовать в Node
        /// </summary>
        /// <param name="fileStruct">Элемент структуры</param>
        /// <returns>Дерево нодов относительно этого элемента</returns>
        private TreeNode ConverToTreeNode(FileStruct fileStruct)
        {
            TreeNode[] NodeCollection = null;
            if (fileStruct.next.Count > 0)
            {
                NodeCollection = new TreeNode[fileStruct.next.Count];
                int i = 0;
                foreach (FileStruct f in fileStruct.next)
                {
                    NodeCollection[i] = ConverToTreeNode(f);
                    i++;
                }
            }

            if (NodeCollection != null)
            {
                return new TreeNode(fileStruct.Name, NodeCollection);
            }
            else
            {
                return new TreeNode(fileStruct.Name);
            }
        }


    }
}

