using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitterJoiner.Models
{
    public interface IFileInfoViewer
    {
        FileInfoViewModel ViewModel { get; set; }
    }
}
