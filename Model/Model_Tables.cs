using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_Tables
    {
        private string _TableName;
        private int _PrimaryKey;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        public int PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }
    }
}
