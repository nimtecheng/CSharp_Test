using Microsoft.Win32;
using SimpleMVVMtest.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVMtest.ViewModel
{
    class MainWindowViewModel:NotificationObject
    {
		private double input1;

		public double Input1
		{
			get { return input1; }
			set { 
				input1 = value;
				RaisePropertyChange("Input1");

			}
		}
		private double input2;

		public double Input2
		{
			get { return input2; }
			set {
				input2 = value;
				RaisePropertyChange("Input2");
			}
		}
		private double result;

		public double Result
		{
			get { return result; }
			set { 
				result = value;
				RaisePropertyChange("Result");
			}
		}

		public DelegateCommand AddCommand { get; set; }
		public DelegateCommand SaveCommand { get; set; }
		private void Add(object parameter)
		{

			Result = Input1 + Input2;

		}
		private void Save(object parameter)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.ShowDialog();

		}
		public MainWindowViewModel()
		{
			AddCommand = new DelegateCommand();
			AddCommand.ExecuteAction = new Action<object>(Add);

			SaveCommand = new DelegateCommand();
			SaveCommand.ExecuteAction = new Action<object>(Save);
		}
	}
}
