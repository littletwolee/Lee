using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_Files
    {
        public Model_Files() { }
        private int _ID;
        private string _FName;
        private string _FType;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }
        public string FType
        {
            get { return _FType; }
            set { _FType = value; }
        }
    }
}
