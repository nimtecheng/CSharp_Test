using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DependencyPropertyTest
{
    class Student:DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student));
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }

        }

        public BindingExpressionBase Setbinding(DependencyProperty dp,BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
}
