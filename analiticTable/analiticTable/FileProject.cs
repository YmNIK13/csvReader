using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace analiticTable
{
    public abstract class FileProject
    {
        protected string _path;
        protected string _nameFie;
        protected string _extension;

        public FileProject(string path)
        {
            this._path = path;
            FileInfo file = new FileInfo(_path);
            this._nameFie = file.Name;
            this._extension = file.Extension;
        }

        public string GetPath
        {
            get
            {
                return this._path;
            }
        }
    }
}
