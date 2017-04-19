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
    /// Interaction logic for ClassificationList.xaml
    /// </summary>
    public partial class ClassificationList : UserControl
    {
        static int counter = 0;
        #region Constructor
        public ClassificationList()
        {
            InitializeComponent();
            _itemsCollection = new List<ClassificationButton>();
            SelectionChanged += CustomListBox_SelectionChanged;
        }
        #endregion

        #region field
        private bool _isUseMore;
        private List<ClassificationButton> _itemsCollection;
        private int? _selectionIndex=-1;
        private ClassificationButton _selectionItem;
        private ClassificationButtonCollection _containerParent;
        #endregion

        #region Property
        public ClassificationButton this[int i]
        {
            get
            {
                return CxListBox.Children[i] as ClassificationButton;
            }
            set
            {
                _itemsCollection[i] = value;
                CxListBox.Children[i] = value;

            }
        }
        public bool IsUseMore
        {
            get
            {
                return _isUseMore;
            }
            set
            {
                if (value)
                {
                    MoreButton.Visibility = Visibility.Visible;
                }
                else
                {
                    MoreButton.Visibility = Visibility.Collapsed;
                }
                _isUseMore = value;
            }
        }
        public List<ClassificationButton> ItemsCollection
        {
            get
            {
                return _itemsCollection;
            }
        }
        public UIElementCollection StackPanelCollection
        {
            get
            {
                return CxListBox.Children;
            }
        }
        public ClassificationButtonCollection ContainerParent
        {
            get
            {
                return _containerParent;
            }
            set
            {
                _containerParent = value;
            }
        }
        #endregion

        #region Method

        public List<ClassificationButton> GetItemsCollection()
        {
            List<ClassificationButton> list = new List<ClassificationButton>();
            foreach (ClassificationButton btn in CxListBox.Children)
            {
                list.Add(btn);
            }
            return list;
        }
        public void ClearChildList()
        {
            //ItemsCollection.Clear();
            CxListBox.Children.Clear();
        }
        public void SetList()
        {
           // ItemsCollection.Sort();
            ClearChildList();
            foreach (ClassificationButton btn in ItemsCollection)
            {
                CxListBox.Children.Add(btn); //chenge
            }
        }
        public void AddCollection(ClassificationButton btn)
        {
            //btn.Margin = new Thickness(2); ///////////////////////////////////////////////////////////
            //btn.Index = counter++;
            btn.ColectionParent = this;
            ItemsCollection.Add(btn);
            
            SetList();
        }
        public int? SelectionIndex
        {
            get
            {
                bool IsSelectedEmpty = false;
                for (int i = 0; i < ItemsCollection.Count; i++)
                {
                    if ((bool)ItemsCollection[i].Selected)
                    {
                        IsSelectedEmpty = true;
                    }
                }
                if (IsSelectedEmpty)
                {
                    return _selectionIndex;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
            //    for (int i = 0; i < ItemsCollection.Count; i++)
            //    {
            //        if ((bool)ItemsCollection[i].Selected)
            //        {
            //            ItemsCollection[i].Selected = false;
            //        }
            //    }
                //ItemsCollection[(int)value].Selected = true;
                _selectionIndex = value;
            }
        }
        public ClassificationButton SelectionItem
        {
            get
            {
                return _selectionItem;
            }
            set
            {
                _selectionItem = value;
                ContainerParent.OnCxSelectionChanged();
            }
        }

        
        #endregion

        #region Event

        public event EventHandler SelectionChanged;
        public void InvokeSelectionChanged(ClassificationButton btn)  //call in ClassificationButtonList
        {
            if (SelectionChanged != null)
            {
                SelectionChanged.Invoke(this, new CustomEventArgs(btn));
            }
        }
        private void CustomListBox_SelectionChanged(object sender, EventArgs e)
        {
            CustomEventArgs customE = e as CustomEventArgs;
            SelectionIndex = customE.SelectedItem.Index;
            SelectionItem = customE.SelectedItem;   
            
            foreach(ClassificationButton btn in ItemsCollection)
            {
                if (btn != SelectionItem)
                {
                    btn.Highlighted = false;
                    btn.Selected = false;
                }
            }
        }

        #endregion
    }
}
