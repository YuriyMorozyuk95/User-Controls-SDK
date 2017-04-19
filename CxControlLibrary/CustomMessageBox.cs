using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CxControlLibrary
{
    static class CustomMessageBox
    {
        public static void Show()
        {
            CxMessageBox ms = new CxMessageBox();
            ms.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ms.Show();
        }
        public static void ShowMessageHandler()
        {
            MessageBox.Show("Don't have Handler");
        }
        public static void ShowMessageHandler(string handler)
        {
            MessageBox.Show("Don't have "+handler+ "Handler");
        }
    }
}
