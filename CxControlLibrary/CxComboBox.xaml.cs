using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CxControlLibrary
{
    
    /// <summary>
    /// Interaction logic for ComboBoxes.xaml
    /// </summary>
    public partial class CxComboBox : UserControl
    {
        #region Field
        private CxStype _cxStype;
        private object _oldItem;
        private object _newItem;
        private ObservableCollection<AutoCompleteEntry> _autoSuggestCollection;
        private AutoCompleteTextBox _autoSuggestTextBox;
        private bool _isAutoComplete;
        private ItemCollection _beckUpComboBoxItemCollection;
        private bool _dropShadow;
        private bool _inBar;
        private Dictionary<ColorArr, Uri> source;
        private ColorArr _arrowColor;
        #endregion

        #region Constructor
        public CxComboBox()
        {
            InitializeComponent();
            FactoryIconPathSourse();
            _autoSuggestCollection = new ObservableCollection<AutoCompleteEntry>();
            _autoSuggestTextBox = new AutoCompleteTextBox();
            _autoSuggestTextBox.AutoCompletionList = _autoSuggestCollection;
            CombBox.DropDownOpened += CombBox_DropDownOpened;
            CombBox.SelectionChanged += CombBox_SelectionChanged;
            PanelBack.Width = this.Width - 5;
            PanelBack.Height = this.Height - 5;
        }
        #endregion

        #region Property
        public bool ReadOnly
        {
            get
            {
                return CombBox.IsReadOnly;
            }
            set
            {
                AutoCompliteTB.ReadOnly = value;
                CombBox.IsReadOnly = value;
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
                //    ConvertToAutoSuggestTextBox();
                AutoCompliteTB.IsComoBox = true;
                ChangeControl(value);

                _isAutoComplete = value;
            }
        }
        public object Selected
        {
            get
            {
                return CombBox.SelectedItem;
            }
            set
            {
                CombBox.SelectedItem = value;
            }
        }
        public bool InBar
        {
            get
            {
                return _inBar;
            }
            set
            {
                _inBar = value;
            }
        }
        public CxStype CxStype
        {
            get
            {
                return _cxStype;
            }
            set
            {
                if(value != CxStype.Rectangle)
                {
                    RoundBorder.CornerRadius = new CornerRadius(15);
                }
                else
                {
                    RoundBorder.CornerRadius = new CornerRadius(5);

                }
                _cxStype = value;
            }
        }
        public ItemCollection ItemCollection
        {
            get
            {
                return CombBox.Items;
            }
        } //add Property
        public new Brush Background
        {
            get
            {
                return PanelBack.Background;
            }
            set
            {
                PanelBack.Background = value;
            }
        }
        public ColorArr ArrowColor
        {
            get
            {
                return _arrowColor;
            }
            set
            {
                _arrowColor = value;

                var bitMap = new BitmapImage();

                bitMap.BeginInit();

                bitMap.UriSource = source[_arrowColor];

                bitMap.EndInit();

                Arrow.Source = bitMap;
            }
        }
        public Object OldItem
        {
            get
            {
                return _oldItem;
            }
            set
            {
                _oldItem = value;
            }
        }
        public Object NewItem
        {
            get
            {
                return _newItem;
            }
            set
            {
                _newItem = value;
            }
        }
        public ObservableCollection<AutoCompleteEntry> AutoComplete
        {
            get
            {
                return AutoCompliteTB.AutoCompletionList;
            }
            set
            {
                AutoCompliteTB.AutoCompletionList = value;
            }
        }
        public new object Tag //addProperty
        {
            get
            {
                return this.Tag;
            }
            set
            {
                this.Tag = value;
            }
        }
        public bool DropShadow //addProperty
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
        public double CxHeight
        {
            get
            {
                return this.Height;
            }
            set
            {
                this.Height = value;
                PanelBack.Height = value - 10;
            }
        }
        public double CxWidth
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
                PanelBack.Width = value - 10;
            }
        }
        #endregion

        #region Event and EventHandlers

        public event SelectionChangedEventHandler CxOnSelectionChange; //addEvent
        private void CombBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (CxOnSelectionChange!=null) 
            {
                CxOnSelectionChange.Invoke(this, e);
            }
            if (!IsAutoComplete)
            {
                NewItem = CombBox.Items[CombBox.SelectedIndex];
            }
        }

        private void CreateBeckUpCollectionItem()
        {
            if (_beckUpComboBoxItemCollection == null)
            {
                _beckUpComboBoxItemCollection = (new CxComboBox()).ItemCollection;
            }
            else
            {
                _beckUpComboBoxItemCollection.Clear();
            }



            foreach (ComboBoxItem item in ItemCollection)
            {
                _beckUpComboBoxItemCollection.Add(item);
            }
        }

        private static ObservableCollection<AutoCompleteEntry> GetAutoSugestCollection(ItemCollection collection)
        {
            var result = new ObservableCollection<AutoCompleteEntry>();
            foreach(ComboBoxItem item in collection)
            {
                var itemEntry = new AutoCompleteEntry(item.ToString(), "ItemsCollection");
                result.Add(itemEntry);
            }
            return result;
        }

        public event EventHandler CxOnOpen; //addEvent
        private void CombBox_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                OldItem = CombBox.Items[CombBox.SelectedIndex];
            }
            catch(ArgumentOutOfRangeException)
            {
                OldItem = null;
            }
            if (CxOnOpen!=null)
            {
                CxOnOpen.Invoke(this, e);
            }
        }
        
        private void Arrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CombBox.IsDropDownOpen = true;
            if(CxOnOpen!=null)
            {
                CxOnOpen.Invoke(this, e);
            }
        }
        #endregion

        #region Method
        public void AddCollection(CxControlLibrary.CxComboBoxItem item) 
                {    
                    CombBox.Items.Add(item);

                    AutoComplete.Add(new AutoCompleteEntry(item.Label, item.Label));
                }
        public void OnDropShadow()
        {
            // Get a reference to the Button.
            CxComboBox ComboBox = this;

            // Initialize a new DropShadowBitmapEffect that will be applied
            // to the Button.
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1; // Note that the alpha value is ignored by Color property. The Opacity property is used to control the alpha.
            myShadowColor.ScB = 0;
            myShadowColor.ScG = 0;
            myShadowColor.ScR = 0;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 320;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 25;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 1;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0.3;

            // Apply the bitmap effect to the Button.
            ComboBox.BitmapEffect = myDropShadowEffect;

        }
        public void OffDropShadow()
        {
            // Get a reference to the Button.
            CxComboBox ComboBox = this;

            // Initialize a new DropShadowBitmapEffect that will be applied
            // to the Button.
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1; // Note that the alpha value is ignored by Color property. The Opacity property is used to control the alpha.
            myShadowColor.ScB = 0;
            myShadowColor.ScG = 0;
            myShadowColor.ScR = 0;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 0;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 0;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 0;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0;

            // Apply the bitmap effect to the Button.
            ComboBox.BitmapEffect = myDropShadowEffect;
        }
        public void FactoryIconPathSourse()
        {
            source = new Dictionary<ColorArr, Uri>();
            //source.Add(ColorArr.Gray, new Uri("pack://application:,,,/Icon/CxComboBox/GrayArrow.png", UriKind.RelativeOrAbsolute));
            //source.Add(ColorArr.Blue, new Uri("pack://application:,,,/Icon/CxComboBox/BlueArrow.png", UriKind.RelativeOrAbsolute));
            source.Add(ColorArr.Gray, new Uri("Icon/CxComboBox/ArrowGray.png", UriKind.Relative));
            source.Add(ColorArr.Blue, new Uri("Icon/CxComboBox/ArrowBlue.png", UriKind.Relative));

        }
        #endregion
    }

    public enum CxStype
    {
        Rectangle,Round
    }
    public enum ColorArr
    {
        Blue, Gray
    }

    partial class CxComboBox
    {
        private ComboBox _myComboBox;
        private AutoCompleteTextBox _myAutoCompliteTextBox;
        private bool _changeControl;

        public void SetComponent(ComboBox cb, AutoCompleteTextBox actb)
        {
            _myComboBox = this.PanelBack.Children.OfType<ComboBox>().FirstOrDefault(); 
            _myAutoCompliteTextBox = this.PanelBack.Children.OfType<AutoCompleteTextBox>().FirstOrDefault();
        }
        public void DelateComboBox()
        {
            CombBox.Visibility = Visibility.Collapsed;
        }
        public void DelateAutoCompliteBox()
        {
            AutoCompliteTB.Visibility = Visibility.Collapsed;
        }
        public void ShowComboBox()
        {
            CombBox.Visibility = Visibility.Visible;
        }
        public void ShowAutoCompliteBox()
        {
            AutoCompliteTB.Visibility = Visibility.Visible;
        }
        public void ChangeControl(bool value)
        {
            if(value)
            {
                DelateComboBox();
                ShowAutoCompliteBox();
                
            }
            else
            {
                DelateAutoCompliteBox();
                ShowComboBox();
            }
        }
    }
}
