using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttachedPropertyTest
{
    class School:DependencyObject
    {

        public static int GetGrade(DependencyObject obj)
        { return (int)obj.GetValue(GradeProperty); }
        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("GradeProperty", typeof(int), typeof(School), new UIPropertyMetadata(0));


    }
}
