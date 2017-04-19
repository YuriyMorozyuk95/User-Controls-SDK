using System;
using System.Collections.Generic;
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

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for CheckBoxes.xaml
    /// </summary>
    public partial class CheckBoxes : UserControl
    {
        public CheckBoxes()
        {
            InitializeComponent();

        }
        public bool? IsCheked
        {
            get
            {
                return ThisChekBox.IsChecked;
            }
            set
            {
                ThisChekBox.IsChecked = value;
            }
        }

        public event RoutedEventHandler CxCheked; 
        private void ThisChekBox_Checked(object sender, RoutedEventArgs e)
        {
            if(CxCheked!=null)
            {
                CxCheked.Invoke(this, e);
            }
        }

        public event RoutedEventHandler CxUnCheked;

        private void ThisChekBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CxUnCheked != null)
            {
                CxUnCheked.Invoke(this, e);
            }
        }
    }
}
