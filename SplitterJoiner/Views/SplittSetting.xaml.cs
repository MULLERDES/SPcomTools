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
    /// Логика взаимодействия для SplittSetting.xaml
    /// </summary>
    public partial class SplittSetting :UserControl, IFileInfoViewer
    {
        public SplittSetting()
        {
            InitializeComponent();
            spl.ValueChanged += Spl_ValueChanged;
            IsEnabled = false; 
        }

        private void Spl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
#if DEBUG
            Console.WriteLine("spl changed");
#endif

            t1.Text = spl.Value.ToString();
            t2.Text = (_mdl.LengthInBytes - spl.Value).ToString();
        }

        public long VAL1
        {
            get
            {
                return (long)spl.Value;
            }
        }
        public long VAL2
        {
            get
            {
                return(long)(_mdl.LengthInBytes - spl.Value);
            }
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
                if(_mdl!= null)
                {
                    IsEnabled = true;
                    spl.Maximum = _mdl.LengthInBytes;
                    spl.Value = _mdl.LengthInBytes / 2;
                    spl.TickFrequency = 1;
                    t1.Text = spl.Value.ToString();
                    t2.Text = (_mdl.LengthInBytes - spl.Value).ToString();
                }
                
               
            }
        }

        private void t1changed(object sender, TextChangedEventArgs e)
        {
#if DEBUG
            Console.WriteLine("t1 changed");
#endif
        }

        private void t2changed(object sender, TextChangedEventArgs e)
        {
#if DEBUG
            Console.WriteLine("t2 changed");
#endif


        }


    }
}
