using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Model_FResumeDownloads
    {
        public Model_FResumeDownloads() { }
        private int _ID;
        private int _FID;
        private string _FName;
        private int _FTotalLength;
        private int _FBeenPassed;
        private byte[] _FileBody;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }
        public int FTotalLength
        {
            get { return _FTotalLength; }
            set { _FTotalLength = value; }
        }
        public int FBeenPassed
        {
            get { return _FBeenPassed; }
            set { _FBeenPassed = value; }
        }
        public byte[] FileBody
        {
            get { return _FileBody; }
            set { _FileBody = value; }
        }
    }
}
