using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace testAsyncStuck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async Task<int> getResult()
        {
            await Task.Run(() => { Thread.Sleep(1000); Debug.Print($"Thread in await:{AppDomain.GetCurrentThreadId()}"); }).ConfigureAwait(false);
            //await Task.Delay(1000);
            Debug.Print($"Thread in await after:{AppDomain.GetCurrentThreadId()}");
            return 10;            
        }


        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "Starting to get Result..........\n";
            //int result;
            //=getResult().Result;
            Debug.Print($"Thread in main:{AppDomain.GetCurrentThreadId()}");
            var t= getResult().Result;
            display.AppendText($"The result is:{t}\n");
        }
    }
}
