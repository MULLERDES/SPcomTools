using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SplitterJoiner.Models;
namespace SplitterJoiner.Views
{
    /// <summary>
    /// Логика взаимодействия для FileInfo.xaml
    /// </summary>
    public partial class FileInfo :UserControl, IFileInfoViewer
    {
        public FileInfo()
        {
            InitializeComponent();
        }

        private FileInfoViewModel _mdl;
        public FileInfoViewModel ViewModel
        {
            get
            {
                return _mdl;
            }

            set
            {
                _mdl = value;
                DataContext = value;
            }
        }
    }
}
