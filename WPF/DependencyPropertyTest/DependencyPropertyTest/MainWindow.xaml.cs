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

namespace DependencyPropertyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();
           // Binding binding = new Binding("Text") { Source = textBox1 };
            //BindingOperations.SetBinding(stu, Student.NameProperty, binding);
            stu.Setbinding(Student.NameProperty, new Binding("Text") { Source=textBox1});
            textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source=stu});
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(stu.Name);
        }
    }
}
