using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyControlTemplate
{
    /// <summary>
    /// ListVIewTest2.xaml 的交互逻辑
    /// </summary>
    public partial class ListVIewTest2 : Window
    {
        private List<ListSource> _listS;

        public ListVIewTest2()
        {
            InitializeComponent();
            MyListView.ItemsSource = DoSource();
        }
        private IEnumerable<ListSource> DoSource()
        {
            _listS = new List<ListSource>();
            for (int i = 0; i < 1000; i++)
            {
                var s = new ListSource
                {
                    First = "First" + i,
                    Second = "Second" + i,
                    Third = "Third" + i,
                    Forth = "Forth" + i,
                    Firth = "Firth" + i,
                    Sixth = string.Format("Sixth{0}", i)
                };
                _listS.Add(s);
            }
            return _listS;
        }

    }
}
