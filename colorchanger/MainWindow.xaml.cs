using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace colorchanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Blogpost> posts =new 
        ObservableCollection<Blogpost>();


        public MainWindow()
        {
            InitializeComponent();



            lbBlogPosts.ItemsSource = posts;
        }

        private void btnbutton_Click(object sender, RoutedEventArgs e)
        {
            string header = txtheader.Text;
            string body = runBody.Text;
            Brush headerColor = btnHeader.Foreground;
            Brush bodyColor= btnBody.Foreground;

            Blogpost bp = new Blogpost(header, body, headerColor, bodyColor);

            posts.Add(bp);

            DefaultColors();
        }
        private void DefaultColors()
        {
            btnHeader.Foreground = txtR.Foreground;
            btnBody.Foreground = txtR.Foreground;   
            btngen.Foreground = txtR.Foreground;    
        }
       
        private void DisplayBlogPost(Paragraph blogPost)
        {
            fdDisplay.Blocks.Add(blogPost);

        }

        private void lbBlogPosts_SeclectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearBlogDisplay();

            int selectedIndex = lbBlogPosts.SelectedIndex;  
            Blogpost selectedBlogPost = posts[selectedIndex];
            DisplayBlogPost(selectedBlogPost.PostFormatted());
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Paragraph para = new Paragraph();
            para.Foreground = new SolidColorBrush(Colors.Red);

            Run inline = new Run("Size 22 - Color Red");
            inline.Foreground = new SolidColorBrush(Colors.Red);

            para.Inlines.Add(inline);
        }
        public void DisplayToFlowDocument()
        {
            Run sentence1 = new Run("This is a single Sentence");

            sentence1.Foreground = new SolidColorBrush(Colors.Tomato);

            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(sentence1);

            fdDisplay.Blocks.Add(paragraph);
        }
        private void ClearBlogDisplay()
        {
            fdDisplay.Blocks.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rValueString = txtR.Text;
            string gvalueString = txtG.Text;
            string bvalueString = txtB.Text;

            byte r = ColorFormat(rValueString);
            byte g = ColorFormat(gvalueString);  
            byte b = ColorFormat(bvalueString);  

            SolidColorBrush color= new SolidColorBrush(Color.FromRgb(r, g, b));
            btngen.Foreground = color;
        }

        private void btnBody_Click(object sender, RoutedEventArgs e)
        {
            btnBody.Foreground= btngen.Foreground;
        }

        private void btnHeader_Click(object sender, RoutedEventArgs e)
        {
            btnHeader.Foreground= btngen.Foreground;
        }
        public byte ColorFormat(string value)
        {
            byte colorValue = 0;
            byte defaultvalue = 0;
            bool isANumber = byte.TryParse(value, out colorValue);

            if (!isANumber)
            {
                MessageBox.Show($"{value} is not a valid number in between 0 and 255");
                return defaultvalue;
            }

            return colorValue;
        }
    }
}
