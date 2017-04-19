using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CxControlLibrary
{
    public partial class CxListBoxItem: ListBoxItem
    {

        #region Constructor
        //public CxListBoxItem1()
        //{
            
        //}
        public CxListBoxItem(ImageSource icon,string label )
        {
            _icon = icon;
            _label = label;
        }
        public CxListBoxItem(Users user)
        {
            _icon = user.Image;
            _label = user.User;
        }
        public CxListBoxItem(Options option)
        {
            _icon = new ImageBrush().ImageSource;
            _label = option.Option;
        }

        #endregion

        #region Field

        private ImageSource _icon;
        private string _label;

        #endregion
    }
}
