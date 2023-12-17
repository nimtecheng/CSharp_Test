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

namespace testTaskScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TaskScheduler m_syncContextTaskScheduler;
        private CancellationTokenSource m_cts;
        public MainWindow()
        {
            InitializeComponent();
            display.Text = "Synchoronization Context Task Scheduler Demo\n";
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        [Obsolete]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessThreadCollection c = Process.GetCurrentProcess().Threads;
            foreach(ProcessThread pt in c)
                display.AppendText($"The ID is {pt.Id}\n");
            display.AppendText($"haha is {AppDomain.GetCurrentThreadId()}\n");
            
            if (m_cts!=null)
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else
            {
                display.AppendText("Opration runnning\n");
                m_cts = new CancellationTokenSource();
                Task<Int32> t = Task.Run(()=>sum(m_cts.Token,20000),m_cts.Token);
                //m_cts.Cancel();
                t.ContinueWith(task => display.AppendText($"Result:{task.Result}"),
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    m_syncContextTaskScheduler);

                t.ContinueWith(task => display.AppendText($"Operation cancelled"),
                     CancellationToken.None,
                     TaskContinuationOptions.OnlyOnCanceled,
                     m_syncContextTaskScheduler);

                t.ContinueWith(task => display.AppendText($"Operation faulted"),
                     CancellationToken.None,
                     TaskContinuationOptions.OnlyOnFaulted,
                     m_syncContextTaskScheduler);
            }


        }
        private Int32 sum(CancellationToken ct, Int32 n)
        {

            Int32 sum = 0;
            for (; n >0;n--)
            {
                //ct.ThrowIfCancellationRequested();
                checked { sum += n; }
            }
            return sum;
        
        }
    }
}
