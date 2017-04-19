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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for ObjectList.xaml
    /// </summary>
    public partial class CxObjectList : UserControl
    {
        #region Constructor
        public CxObjectList()
        {
            InitializeComponent();     
        }
        #endregion

        #region Field
        private bool _checkForAllItems;
        private bool _isOpening=false;
        private bool _showTitles;
        #endregion

        #region Property
        public ItemCollection ObjectlistItemsCollection
        {
            get
            {
                return ListObjects.Items;
            }

        }
        public bool CheckForAllItems
        {
            get
            {
                return _checkForAllItems;
            }
            set
            {
                foreach(ObjectListItem objectItem in ListObjects.Items)
                {

                    if (value)
                    {
                        objectItem.IsCheked = true;
                    }
                    else
                    {
                        objectItem.IsCheked = false;
                    }
                }
                _checkForAllItems = value;
            }

        }
        public string Title
        {
            get
            {
                return TitleAttachentName.Text;
            }
            set
            {
                TitleAttachentName.Text = value;
            }
        } // add Property
        public string CxTitlePolicy
        {
            get
            {
                return TitlePolicy.Text;
            }
            set
            {
                TitlePolicy.Text = value;
            }
        }
        public bool ShowTitles
        {
            get
            {
                return _showTitles;
            }
            set
            {
                if(value)
                {
                    TitleCheckBox.Visibility = Visibility.Collapsed;
                    TitlePolicy.Visibility = Visibility.Collapsed;
                    TitleAttachentName.Foreground = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    TitleCheckBox.Visibility = Visibility.Visible;
                    TitlePolicy.Visibility = Visibility.Visible;
                    TitleAttachentName.Foreground = new SolidColorBrush(Color.FromRgb(61, 70, 83));
                }
                _showTitles = value;
            }
        }
        #endregion

        #region EventAndHandlers
        public event SelectionChangedEventHandler CxOnSelectionChange;
        private void ListObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ListBox;
            for (int i = 0; i < list.Items.Count; i++)
            {
                var item = ((ObjectListItem)list.Items[i]);
                if (i == list.SelectedIndex)
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }
            }

            if(CxOnSelectionChange!=null)
            {
                CxOnSelectionChange.Invoke(this, e);
            }

        }

        private void TitleCheckBox_CxCheked(object sender, RoutedEventArgs e)
        {
            CheckForAllItems = true;
        }

        private void TitleCheckBox_CxUnCheked(object sender, RoutedEventArgs e)
        {
            CheckForAllItems = false;
        }
        #endregion

        #region Method
        public void AnimationOpening(bool isOpening)
        {

            DoubleAnimation animation = new DoubleAnimation();
            if (isOpening)
            {
                animation.From = 0;
                animation.To = 142;
            }
            else
            {
                animation.From = 142;
                animation.To = 0;
            }

            animation.Duration = TimeSpan.FromSeconds(0.5);

            this.BeginAnimation(Rectangle.HeightProperty, animation);
        }
        #endregion
    }
}
