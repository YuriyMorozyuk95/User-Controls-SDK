using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CxControlLibrary
{
    class Presenter
    {
        //Model model = null;
        Window mainWindow = null;

        public Presenter(Window mainWindow)
        {
            //this.model = new Model();
            this.mainWindow = mainWindow;
           // this.mainWindow.myEvent += new EventHandler(mainWindow_myEvent);
        }

        //void mainWindow_myEvent(object sender, System.EventArgs e)
        //{
        //    string variable = model.Logic(this.mainWindow.textBox1.Text);

        //    this.mainWindow.textBox1.Text = variable;
        //}
    }
}
