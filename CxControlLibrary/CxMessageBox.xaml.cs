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
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for CxMessageBox.xaml
    /// </summary>
    public partial class CxMessageBox : Window
    {

        public CxDialogResultEnum DialogResult { get; set; }
        public CxMessageBox()
        {
            InitializeComponent();
            CxRoundYes.IconDisabled = null;
            CxRoundYes.IconHover = null;
            CxRoundYes.IconPressed = null;
            CxRoundYes.IconRegular = null;

            CxRoundNo.IconDisabled = null;
            CxRoundNo.IconHover = null;
            CxRoundNo.IconPressed = null;
            CxRoundNo.IconRegular = null;
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = CxDialogResultEnum.Cancel;
            MessageBox.Show(DialogResult.ToString());
            this.Close();
        }

        private void MainButton_ButtonClick(object sender, EventArgs e)
        {
            CxRoundButton btn = sender as CxRoundButton;
            if(btn.Label == "Yes")
            {
                DialogResult = CxDialogResultEnum.Yes;
            }
            if(btn.Label == "No")
            {
                DialogResult = CxDialogResultEnum.No;
            }
            
            MessageBox.Show(DialogResult.ToString());
            this.Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
