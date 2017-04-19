using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CxControlLibrary
{
    class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(ClassificationButton btn) : base()
        {
            SelectedItem = btn;
           // Index = btn.SortIndex;
        }
        public ClassificationButton SelectedItem{ get; set; }
        //public int? Index { get; set; }
    }
}
