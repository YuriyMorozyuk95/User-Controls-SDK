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
    /// Interaction logic for ClassificationBar.xaml
    /// </summary>
    public partial class ClassificationBar : UserControl
    {
        #region Constructor
        public ClassificationBar()
        {
            InitializeComponent();
            CxxDialog.InitCxButtonCollection(ref CxClasificationButtonCollection);
        }
        #endregion

        #region Property

        public string EmailBodyText
        {
            get
            {
                return EmailBody.Text;
            }
            set
            {
                EmailBody.Text = value;
            }
        }

        public string ClassificationText
        {
            get
            {
                return Classification.Text;
            }
            set
            {
                Classification.Text = value;
            }
        }

        public string PolicyText
        {
            get
            {
                return Policy.Text;
            }
            set
            {
                Policy.Text = value;
            }
        }

        #endregion
    }
}
