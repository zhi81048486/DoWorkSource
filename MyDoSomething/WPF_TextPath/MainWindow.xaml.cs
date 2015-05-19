using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPF_TextPath
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            FormattedText text = new FormattedText("AZIM",
              System.Globalization.CultureInfo.GetCultureInfo("en-US"),
              FlowDirection.LeftToRight, new Typeface("LilyUPC"), 256, Brushes.Black);
            text.MaxTextWidth = 700;
            text.MaxTextHeight = 400;
            LinearGradientBrush brush = new LinearGradientBrush();	// Create a LinearGradientBrush
            // Set GradientStops
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.2));
            brush.GradientStops.Add(new GradientStop(Colors.Green, 0.3));
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Magenta, 0.7));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.8));
            brush.GradientStops.Add(new GradientStop(Colors.Cyan, 0.9));
            text.SetForegroundBrush(brush, 0, 4);			// Apply formatting to 4 chars starting from first char
            drawingContext.DrawText(text, new Point(10, 0));		// Draw text on the Window
            base.OnRender(drawingContext);
            drawingContext.DrawText(text, new Point(10, 0));
        }
        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    string testString = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";

        //    // Create the initial formatted text string.
        //    FormattedText formattedText = new FormattedText(
        //        testString,
        //        CultureInfo.GetCultureInfo("en-us"),
        //        FlowDirection.LeftToRight,
        //        new Typeface("Verdana"),
        //        32,
        //        Brushes.Pink);

        //    // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
        //    formattedText.MaxTextWidth = 300;
        //    formattedText.MaxTextHeight = 240;

        //    // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
        //    // The font size is calculated in terms of points -- not as device-independent pixels.
        //    formattedText.SetFontSize(36 * (96.0 / 72.0), 0, 5);

        //    // Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
        //    formattedText.SetFontWeight(FontWeights.Bold, 6, 11);

        //    // Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
        //    formattedText.SetForegroundBrush(
        //                            new LinearGradientBrush(
        //                            Colors.Orange,
        //                            Colors.Teal,
        //                            90.0),
        //                            6, 11);

        //    // Use an Italic font style beginning at the 28th character and continuing for 28 characters.
        //    formattedText.SetFontStyle(FontStyles.Italic, 28, 28);

        //    // Draw the formatted text string to the DrawingContext of the control.
        //    drawingContext.DrawText(formattedText, new Point(10, 10));
        //    base.OnRender(drawingContext);
        //}

    }
}
