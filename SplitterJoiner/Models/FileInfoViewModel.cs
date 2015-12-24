using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitterJoiner.Controllers;
namespace SplitterJoiner.Models
{
    public class FileInfoViewModel
    {
        public FileInfoViewModel(string filename, long len)
        {
            FileName = filename;
            _len = len;
        }

        public string FileNameWothoutPath
        {
            get
            {
                return Path.GetFileName(fname);
            }
        }
        private string fname;
        public string FileName
        {
            get
            {
                return fname;
            }
            private set { fname = value; }
        }
        public long LengthInBytes
        {
            get
            {
                return _len;
            }
        }
        public long LengthInKBytes
        {
            get
            {
                return _len.GetKilobytes();
            }
        }
        public long LengthInMBytes
        {
            get
            {
                return _len.GetMegabytes();
            }
        }


        private long _len;


    }
}
