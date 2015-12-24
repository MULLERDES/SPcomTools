using System;
using System.Collections.Generic;
using System.IO;
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

using Microsoft.Win32;
using SplitterJoiner.Models;

namespace SplitterJoiner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private FileInfoViewModel _vmfileinfo1;
        private FileInfoViewModel _vmfileinfo2;
        private FileInfoViewModel vmfileinfo1
        {
            get
            {
                return _vmfileinfo1;
            }
            set
            {
                _vmfileinfo1 = value;
                if(_vmfileinfo1 != null)
                {
                    fileinfo1.ViewModel = value;
                    splitterSetting1.ViewModel = value;
                }
            }
        }
        private FileInfoViewModel vmfileinfo2
        {
            get
            {
                return _vmfileinfo2;
            }
            set
            {
                _vmfileinfo2 = value;
                if(_vmfileinfo2 != null)
                {
                    fileinfo2.ViewModel = value;
                    splitterSetting2.ViewModel = value;
                }
            }
        }

        private void BLoad1FileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".*";
            dlg.Filter = "All files (*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                try
                {
                    using(var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        // MessageBox.Show(fs.Length.ToString()); 
                        vmfileinfo1 = new FileInfoViewModel(fs.Name, fs.Length);
                        fs.Close();
                    }
                }
                catch(IOException)
                {

                }
            }
        }

        private void BLoad2FileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".*";
            dlg.Filter = "All files (*.*)|*.*";
            if(dlg.ShowDialog() == true)
            {
                try
                {
                    using(var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        // MessageBox.Show(fs.Length.ToString()); 
                        vmfileinfo2 = new FileInfoViewModel(fs.Name, fs.Length);
                        fs.Close();
                    }
                }
                catch(IOException)
                {

                }
            }
        }
        private void ReadAndSaveToFile(FileStream fs, string fn, long start, long length)
        {
            byte[] buffer = new byte[length];
            fs.Seek(start, SeekOrigin.Begin);
            fs.Read(buffer, 0, (int)length);


            using(var sw = new FileStream(fn, FileMode.Create))
            {
                sw.Write(buffer, 0, buffer.Length);
                sw.Close();
            }
        }
        private void BSplitt1Click(object sender, RoutedEventArgs e)
        {
            if(vmfileinfo1 != null)
                try
                {
                    using(var fs = new FileStream(_vmfileinfo1.FileName, FileMode.Open, FileAccess.Read))
                    {

                        long len1 = splitterSetting1.VAL1;
                        long len2 = splitterSetting1.VAL2;
                        string path = Path.GetDirectoryName(fs.Name);
                        string fn1 = path + "\\part1_" + Path.GetFileName(fs.Name);
                        string fn2 = path + "\\part2_" + Path.GetFileName(fs.Name);

                        if(len1 > 0)
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName =fn1;
                            dlg.DefaultExt = ".bin";
                            dlg.Filter = "All files (*.*)|*.*";
                            if(dlg.ShowDialog() == true)
                            {
                                ReadAndSaveToFile(fs, dlg.FileName, 0, len1);
                            }
                               
                        }
                        if(len2 > 0)
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName = fn2;
                            dlg.DefaultExt = ".bin";
                            dlg.Filter = "All files (*.*)|*.*";
                            if(dlg.ShowDialog() == true)
                            {
                                ReadAndSaveToFile(fs, dlg.FileName, len1, len2);
                            }
                        }
                        fs.Close();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
        }

        private void BSplitt2Click(object sender, RoutedEventArgs e)
        {
            if(vmfileinfo2 != null)
                try
                {
                    using(var fs = new FileStream(_vmfileinfo2.FileName, FileMode.Open, FileAccess.Read))
                    {

                        long len1 = splitterSetting2.VAL1;
                        long len2 = splitterSetting2.VAL2;
                        string path = Path.GetDirectoryName(fs.Name);
                        string fn1 = path + "\\part1_" + Path.GetFileName(fs.Name);
                        string fn2 = path + "\\part2_" + Path.GetFileName(fs.Name);
                        if(len1 > 0)
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName = fn1;
                            dlg.DefaultExt = ".bin";
                            dlg.Filter = "All files (*.*)|*.*";
                            if(dlg.ShowDialog() == true)
                            {
                                ReadAndSaveToFile(fs, dlg.FileName, 0, len1);
                            }

                        }
                        if(len2 > 0)
                        {
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName = fn2;
                            dlg.DefaultExt = ".bin";
                            dlg.Filter = "All files (*.*)|*.*";
                            if(dlg.ShowDialog() == true)
                            {
                                ReadAndSaveToFile(fs, dlg.FileName, len1, len2);
                            }
                        }
                        fs.Close();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
        }

        private void BJoinClick(object sender, RoutedEventArgs e)
        {
            if(vmfileinfo1 != null && vmfileinfo1 != null)
            {
                try
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.FileName = "";
                    dlg.DefaultExt = ".bin";
                    dlg.Filter = "All files (*.*)|*.*";
                    if(dlg.ShowDialog() == true)
                    {
                        using(var sw = new FileStream(dlg.FileName, FileMode.Create))
                        {

                            using(var fs = new FileStream(vmfileinfo1.FileName, FileMode.Open, FileAccess.Read))
                            {
                                byte[] buff = new byte[fs.Length];
                                fs.Read(buff, 0, buff.Length);
                                sw.Write(buff, 0, buff.Length);
                                fs.Close();
                            }
                            using(var fs = new FileStream(vmfileinfo2.FileName, FileMode.Open, FileAccess.Read))
                            {
                                byte[] buff = new byte[fs.Length];
                                fs.Read(buff, 0, buff.Length);
                                sw.Write(buff, 0, buff.Length);
                                fs.Close();
                            }
                        }

                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
