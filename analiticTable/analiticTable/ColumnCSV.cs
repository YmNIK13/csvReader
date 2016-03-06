using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analiticTable
{
    public class ColumnCSV
    {
        private string _name;
        private Type _typeField;

        private bool NotNull = true;
        private bool NotEmpty = true;

        public ColumnCSV(string name)
        {
            this._name = name;
        }

        public string GetName
        {
            get
            {
                return this._name;
            }
        }
    }
}
