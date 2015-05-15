using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RichListView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += ListViewTest_Loaded;
            MyListView.ItemsSource = _GameCollection;
        }
        void ListViewTest_Loaded(object sender, RoutedEventArgs e)
        {
            _GameCollection.Add(new GameData
            {
                GameName = "World Of Warcraft",
                Creator = "Blizzard",
                Publisher = "Blizzard"
            });
            _GameCollection.Add(new GameData
            {
                GameName = "Halo",
                Creator = "Bungie",
                Publisher = "Microsoft"
            });
            _GameCollection.Add(new GameData
            {
                GameName = "Gears Of War",
                Creator = "Epic",
                Publisher = "Microsoft"
            });
        }

        private readonly ObservableCollection<GameData> _GameCollection = new ObservableCollection<GameData>();

    }

    public class GameData
    {
        public string GameName { get; set; }
        public string Creator { get; set; }
        public string Publisher { get; set; }
    }

    public class DeviceImageCell : ImageCell
    {
        private string _sourceCode;

        public string SourceCode
        {
            get { return _sourceCode; }
            set { _sourceCode = value; OnpropertyChanged("SourceCode"); }
        }
        public DeviceImageCell(string code, string tip)
            : base()
        {
            this.SourceCode = code;
            this.SourceTip = tip;
        }
    }
    public class ImageCell : INotifyPropertyChanged
    {


        private ImageSource _source;
        private string _sourceTip;

        public string SourceTip
        {
            get { return _sourceTip; }
            set { _sourceTip = value; OnpropertyChanged("SourceTip"); }
        }

        public ImageSource Source
        {
            get { return _source; }
            set { _source = value; OnpropertyChanged("Source"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChanged(string value)
        {

            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(value));
        }
    }

}
