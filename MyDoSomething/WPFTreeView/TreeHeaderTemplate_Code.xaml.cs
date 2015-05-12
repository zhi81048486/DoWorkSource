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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFTreeView.Library;

namespace WPFTreeView
{
    /// <summary>
    /// TreeHeaderTemplate_Code.xaml 的交互逻辑
    /// </summary>
    public partial class TreeHeaderTemplate_Code : UserControl
    {
        public TreeHeaderTemplate_Code()
        {
            InitializeComponent();
            LoadTree();
        }
        //这里也是分两步，第一步创建一个Header的DataTemplate，第二步每一个Header都添加这个这个DataTemplate


        private void LoadTree()
        {
            DataTemplate template = GetTreeHeaderDataTemplate();
            TreeViewItem AsianItem=new TreeViewItem();
            AsianItem.Header = "亚洲";
            AsianItem.HeaderTemplate = template;
            TreeViewItem EuropeItem=new TreeViewItem();
            EuropeItem.Header = "欧洲";
            EuropeItem.HeaderTemplate = template;
            TreeViewItem chinaItem=new TreeViewItem();
            chinaItem.Header = "中国";
            chinaItem.HeaderTemplate = template;
            TreeViewItem japnaItem = new TreeViewItem();
            japnaItem.Header = "日本";
            japnaItem.HeaderTemplate = template;
            TreeViewItem ukItem = new TreeViewItem();
            ukItem.Header = "英国";
            ukItem.HeaderTemplate = template;
            TreeViewItem denmarkItem = new TreeViewItem();
            denmarkItem.Header = "丹麦";
            denmarkItem.HeaderTemplate = template;
            AsianItem.Items.Add(chinaItem);
            AsianItem.Items.Add(japnaItem);
            EuropeItem.Items.Add(ukItem);
            EuropeItem.Items.Add(denmarkItem);
            this.MainTreeView.Items.Add(AsianItem);
            this.MainTreeView.Items.Add(EuropeItem);
        }


        private DataTemplate GetTreeHeaderDataTemplate()
        {
            DataTemplate _dataTemplate = new DataTemplate();
            FrameworkElementFactory _stackPanel = new FrameworkElementFactory(typeof(StackPanel));
            _stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            FrameworkElementFactory _image = new FrameworkElementFactory(typeof(Image));
            _image.SetValue(Image.SnapsToDevicePixelsProperty,true);
            _image.SetBinding(Image.SourceProperty, new Binding() { Converter = new ImageSourceConvert() });
            FrameworkElementFactory _textBlock = new FrameworkElementFactory(typeof(TextBlock));
            _textBlock.SetBinding(TextBlock.TextProperty, new Binding());
            _stackPanel.AppendChild(_image);
            _stackPanel.AppendChild(_textBlock);
            _dataTemplate.VisualTree = _stackPanel;
            return _dataTemplate;

        }
    }
}
