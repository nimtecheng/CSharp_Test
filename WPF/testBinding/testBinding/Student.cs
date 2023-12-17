using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testBinding
{
    class Student:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if(PropertyChanged!=null)
                { PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name")); }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
