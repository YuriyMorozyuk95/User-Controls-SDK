using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for ClassificationButtonCollection.xaml
    /// </summary>
    public partial class ClassificationButtonCollection : UserControl
    {
        #region Constructor
        public ClassificationButtonCollection()
        {
            InitializeComponent();
            FactoryButtonToList();
            this.CxClassificationList.ContainerParent = this;
            CompliteSelectionChange += ButtonList_SelectionChanged;
            if(Title == null || Title == string.Empty) //If the title is empty the title row is being removed
            {
                Title = "";
            }
        }
        #endregion

        #region Field
        private ObservableCollection<ClassificationButton> _listButton;
        private bool _sortedBy;
        private bool _dropShadow;
        private bool _showLabel;
        #endregion

        #region Property
        public int SelectedIndex
        {
            get
            {
                return (int)CxClassificationList.SelectionIndex;
            }

            set
            {
                CxClassificationList.SelectionIndex = value;
            }
        }
        public String Title
        {
            get
            {
                return TitleTextBlock.Text;
            }
            set
            {
                TitleTextBlock.Text = value;
            }
        }
        public ClassificationButton SelectedItem
        {
            get
            {
                return CxClassificationList.SelectionItem;
            }
            set
            {
                CxClassificationList.SelectionItem = value;
            }
        }
        public bool IsUseMore
        {
            get
            {
                return (bool)CxClassificationList.IsUseMore;
            }
            set
            {
                CxClassificationList.IsUseMore = value;
            }
        }
        public bool SortedBy
        {
            get
            {
                return _sortedBy;
            }
            set
            {
                foreach (ClassificationButton btn in _listButton)
                {
                    btn.SortBy = value;
                }
                Sort();
                
                _sortedBy = value;
            }
        }
        public Brush BackgroundColor
        {
            get
            {
                return this.Background;
            }
            set
            {
                this.Background = value;
            }
        }
        public bool DropShadow
        {
            get
            {
                return _dropShadow;
            }
            set
            {
                if(value)
                {
                    ShadowOptions.OnDropShadow(this);
                }
                else
                {
                    ShadowOptions.OffDropShadow(this);
                }
                _dropShadow = value;
            }
        }
        public bool ShowLabel
        {
            get
            {
                return _showLabel;
            }
            set
            {
                if (value)
                {
                    GridLabelRow.Height = new GridLength(12);
                }
                else
                {
                    GridLabelRow.Height = new GridLength(0);
                }
            }
        }
        #endregion

        #region Method
        private void FactoryButtonToList()
        {
            _listButton = new ObservableCollection<ClassificationButton>(CxClassificationList.ItemsCollection);
            //ButtonList.Items.Clear();
        }
        public void AddCollection(ClassificationButton button) //add button
        {
            //_listButton.Add(button);
            //Sort();
            //ButtonList.ItemsSource = _listButton;
            CxClassificationList.AddCollection(button);
        }
        private void Sort()
        {
            var List = new List<ClassificationButton>(_listButton);
            List.Sort();
            _listButton = new ObservableCollection<ClassificationButton>(List);
            //CxClassificationList.ClearChildList();
            //foreach(ClassificationButton btn in _listButton)
            //{
            //    CxClassificationList.StackPanelCollection.Add(btn);
            //}
        }
        //public void OnCompliteSelectionChange(ClassificationButton sender)
        //{

        //    CustomSelectionChangedEventArgs e = new CustomSelectionChangedEventArgs();
        //    e.Index = sender.SortIndex;


        //    if(CompliteSelectionChange!=null)
        //    {
        //        CompliteSelectionChange.Invoke(sender, e);
        //    }
        //}
        public void OnCxSelectionChanged()
        {
            if (CxSelectionChanged != null)
            {
                CxSelectionChanged.Invoke(this, null);
            }
        }
        #endregion

        #region EventAndHandler
        private event EventHandler CompliteSelectionChange;
        public event SelectionChangedEventHandler CxSelectionChanged;
        public void ButtonList_SelectionChanged(object sender, EventArgs e)
        {

            //var btn = sender as ClassificationButton;
            ////(CxClassificationList.SelectionItem as ClassificationButton).OnClick();

            //(ButtonList.ItemContainerGenerator
            //            .ContainerFromIndex(ButtonList.SelectedIndex) as ListBoxItem)
            //            .Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));

            //_listButton[ButtonList.SelectedIndex].Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));



            //SelectedIndex = ButtonList.SelectedIndex;
            //for (int i = 0; i < ButtonList.Items.Count; i++)
            //{
            //    if (i != SelectedIndex)
            //    {
            //        _listButton[i].Selected = false;
            //        _listButton[i].Highlighted = false;

            //        (ButtonList.ItemContainerGenerator
            //            .ContainerFromIndex(i) as ListBoxItem)
            //            .Background = new SolidColorBrush(Color.FromRgb(61, 70, 83));

            //        _listButton[ButtonList.SelectedIndex].Background = new SolidColorBrush(Color.FromRgb(71, 104, 126));

            //    }


            //}
            

            if (CxSelectionChanged != null)
            {
                CxSelectionChanged.Invoke(this, null);
            }
            else
            {
                CustomMessageBox.ShowMessageHandler("SelectionChanged");
                return;
            }

        }

        public event RoutedEventHandler CxMoreClick;
        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (CxMoreClick != null)
            {
                CxMoreClick.Invoke(this, e);
            }
            else
            {
                CustomMessageBox.ShowMessageHandler("CxMoreClick");
                return;
            }
        }
        #endregion
    }
}
    

