using System;
using System.IO;
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

namespace Graphical_Redaktor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColorRGB thiscolor;
        Color clr;
        bool editing = false;
        public MainWindow()
        {
            InitializeComponent();
            thiscolor = new ColorRGB();
            thiscolor.Red = 0;
            thiscolor.Green = 0;
            thiscolor.Blue = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!editing)
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.Select;
                editing = true;
            }
            else
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.None;
                inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
                editing = false;
            }
        }

        private void Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            thiscolor.Red = Convert.ToByte(Red_Color.Value);
            thiscolor.Blue = Convert.ToByte(Blue_Color.Value);
            thiscolor.Green = Convert.ToByte(Green_Color.Value);
            clr = Color.FromRgb(thiscolor.Red, thiscolor.Blue, thiscolor.Green);
            this.inkCanvas1.DefaultDrawingAttributes.Color = clr;
            Label1.Background = new SolidColorBrush(clr);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            var send = sender as Button;
            if (send != null) inkCanvas1.DefaultDrawingAttributes.Color = ((SolidColorBrush)(send.Background)).Color;
        }
    }
    class ColorRGB
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}
