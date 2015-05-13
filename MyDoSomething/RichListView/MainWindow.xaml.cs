using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
}
