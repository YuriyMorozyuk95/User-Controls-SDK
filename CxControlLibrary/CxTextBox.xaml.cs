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
using System.Collections.ObjectModel;

namespace CxControlLibrary
{
    /// <summary>
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class CxTextBox : UserControl
    {
        #region Constructor
        public CxTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Field
        private bool _isAutoComplete;
        private ObservableCollection<AutoCompleteEntry> _beckUpAutoCompleteCollection = new ObservableCollection<AutoCompleteEntry>();
        private ObservableCollection<AutoCompleteEntry> _nullAutoCompleteCollection = new ObservableCollection<AutoCompleteEntry>();
        #endregion

        #region Property
        public ObservableCollection<AutoCompleteEntry> AutoCompleteCollection
        {
            get
            {
                return AutoCompTB.AutoCompletionList;
            }
            set
            {
                AutoCompTB.AutoCompletionList = value;
                CompliteBackUp();
            }
        }
        public bool IsAutoComplete
        {
            get
            {
                return _isAutoComplete;
            }
            set
            {
                if(value)
                {
                    GetBackUp();
                }
                else
                {
                    CompliteBackUp();
                    AutoCompleteCollection = _nullAutoCompleteCollection;
                }
                _isAutoComplete = value;
            }
        }
        public string Label
        {
            get
            {
                return AutoCompTB.Text;
            }
            set
            {
                AutoCompTB.Text = value;
            }
        }
        public string ShadowTextLabel
        {
            get
            {
                return AutoCompTB.DefaultText;
            }
            set
            {
                AutoCompTB.DefaultText = value;
            }
        }
        #endregion

        #region Method
        public void CompliteBackUp()
        {
            _beckUpAutoCompleteCollection.Clear();
            foreach (AutoCompleteEntry item in AutoCompleteCollection)
            {
                _beckUpAutoCompleteCollection.Add(item);
            }
        }
        public void GetBackUp()
        {
            AutoCompleteCollection.Clear();
            foreach (AutoCompleteEntry item in _beckUpAutoCompleteCollection)
            {
                AutoCompleteCollection.Add(item);
            }
        }
        public void AddItem(AutoCompleteEntry ace)
        {
            AutoCompTB.AddItem(ace);
        }
      
        #endregion

    }
}
