using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Interaction logic for MainButton.xaml
    /// </summary>
    public partial class CxRoundButton : UserControl,INotifyPropertyChanged
    {
        #region Constructor
        public CxRoundButton()
        {
            InitializeComponent();
            DataContext = this;
            FactoryIconPathSourse(); //icon default
            InitializeDefaultValue();
            CxForeground = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Field
        private Brush _backgroundHover;
        private Brush _backgroundRegular;
        private Brush _backgroundPressed;
        private Brush _backgroundDisabled;
        private ImageSource _iconHover;
        private ImageSource _iconRegular;
        private ImageSource _iconPressed;
        private ImageSource _iconDisabled;
        private bool _emptyText;
        private GridLength _heightButton;
        private GridLength _widthButton;
        private Thickness _marginImage; 
        private String _contentText;
        private bool _enabled;
        private Brush _beckUpBackground;
        private ImageSource _beckUpIcon;
        private bool EmptyText
        {
            get
            {
                return _emptyText;
            }
            set
            {
                _emptyText = value;
                if (value)
                {
                    this.HeightButton = new GridLength(30);
                    this.WidthButton = new GridLength(0);
                    this.MarginImage = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    this.HeightButton = new GridLength(35);
                    this.WidthButton = new GridLength(115);
                    this.MarginImage = new Thickness(13, 0, 0, 0);
                }
                Notify("EmptyText");

            }
        } 
        private bool _isToggle;
        private bool? _cheked = false;
        private int _fixedWidth=14;
        private double _oldWidth;
        private bool _dropShadow;
        private Brush _foreground;
        #endregion

        #region Property
        public Brush CxForeground
        {
            get
            {
                return _foreground;
            }
            set
            {
                _foreground = value;
                Notify("CxForeground");
            }
        }
        public Brush BackgroundHover
        {
            get
            {
                return _backgroundHover;
            }
            set
            {
                _backgroundHover = value;
                Notify("BackgroundHover");

            }
        }
        public Brush BackgroundRegular
        {
            get
            {
                return _backgroundRegular;
            }
            set
            {
                _backgroundRegular = value;
                Notify("BackgroundRegular");

            }
        }
        public Brush BackgroundDisabled
        {
            get
            {
                return _backgroundDisabled;
            }
            set
            {
                _backgroundDisabled = value;
                Notify("BackgroundDisabled");

            }
        }
        public Brush BackgroundPressed
        {
            get
            {
                return _backgroundPressed;
            }
            set
            {
                _backgroundPressed = value;
                Notify("BackgroundPressed");

            }
        }
        public ImageSource IconHover
        {
            get
            {
                return _iconHover;
            }
            set
            {
                _iconHover = value;
                Notify("IconHover");

            }
        }
        public ImageSource IconRegular
        {
            get
            {
                return _iconRegular;
            }
            set
            {
                _iconRegular = value;
                Notify("IconRegular");

            }
        }
        public ImageSource IconDisabled
        {
            get
            {
                return _iconDisabled;
            }
            set
            {
                _iconDisabled = value;
                Notify("IconDisabled");

            }
        }
        public ImageSource IconPressed
        {
            get
            {
                return _iconPressed;
            }
            set
            {
                _iconPressed = value;
                Notify("IconPressed");

            }
        }
        public Thickness MarginImage
        {
            get
            {
                return _marginImage;
            }
            set
            {
                _marginImage = value;
                Notify("MarginImage");
            }
        }
        public bool Enabled
        {
            get
            {
                return ThisButton.IsEnabled;
            }
            set
            {
                _enabled = value;
                if ((bool)_enabled)
                {
                    BackgroundRegular = _beckUpBackground;
                    IconRegular = _beckUpIcon;
                    ThisButton.IsEnabled = true;
                }
                else
                {
                    BackgroundRegular = BackgroundDisabled;
                    IconRegular = IconDisabled;
                    ThisButton.IsEnabled = false;
                }
            }
        }
        public GridLength HeightButton
        {
            get
            {
                return _heightButton;
            }
            set
            {
                _heightButton = value;
                Notify("HeightButton");
            }
        } 
        public GridLength WidthButton
        {
            get
            {
                return _widthButton;
            }
            set
            {
                _oldWidth = _widthButton.Value;
                _widthButton = value;
                Notify("WidthButton");
            }
        }
        public new int Width
        { get
            {
                return (int)WidthButton.Value;
            }
            set
            {
                WidthButton = new GridLength(value);
            }
        }
        public String Label
        {
            get
            {
                return _contentText;   
            }
            set
            {
                if(value.Contains("..."))
                {
                    value = value.Replace("...",String.Empty);
                }
                if (value == String.Empty)
                {
                    EmptyText = true;
                }
                else
                {
                    EmptyText = false;
                }
                if (value.Length > _fixedWidth)
                {
                    value = value.Remove(_fixedWidth) + "...";
                }
                _contentText = value;
            }
        }
        public Dictionary<ButtonStateType, string> IconPathSourse { get; set; }
        public bool IsToggle
        {
            get
            {
                return _isToggle;
            }
            set
            {
                if(value)
                {
                    _cheked = false;
                }
                _isToggle = value;
            }
        }
        public bool? Checked
        {
            get
            {
                //if Toggle = false Cheked = null
                if(IsToggle)
                {
                    //MessageBox.Show("You mast be handled this property");
                    return _cheked;
                }
                else
                {
                    _cheked = null;
                    return (bool)_cheked;
                }
            }
            set
            {
                if(IsToggle)
                {
                    
                    _cheked = value;
                }
            }
        } //addProperty
        public int FixedWidth
        {
            get
            {
                return _fixedWidth;
            }
            set
            {
                _fixedWidth = value;
                Label = Label;
            }
        } 
        public bool DropShdow
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
        } //addProperty

        #endregion

        #region Method
        public void FactoryIconPathSourse()
        {
            IconPathSourse = new Dictionary<ButtonStateType, string>();
            IconPathSourse.Add(ButtonStateType.Dissabled, "pack://application:,,,/Icon/RoundButton/DissabledRB.png");
            IconPathSourse.Add(ButtonStateType.Hover, "pack://application:,,,/Icon/RoundButton/RegularAndHoverRB.png");
            IconPathSourse.Add(ButtonStateType.Pressed, "pack://application:,,,/Icon/RoundButton/PressedRB.png");
            IconPathSourse.Add(ButtonStateType.Regular, "pack://application:,,,/Icon/RoundButton/RegularAndHoverRB.png");
        }
        #endregion

        #region EventAndHandlers

        public ImageSource SetIcon(ImageSource img,string path)
        {
            ImageSource res = img;
            var bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(path);
            bitMap.EndInit();  
            img = bitMap;
            return res;
        }
        private void InitializeDefaultValue()
        {
            //DefaultValue
            if (!EmptyText)
            {
                HeightButton = new GridLength(35);
                WidthButton = new GridLength(115);
                MarginImage = new Thickness(13, 0, 0, 0);
            }

            BackgroundHover = new SolidColorBrush(Color.FromRgb(51, 143, 196));
            BackgroundRegular = new SolidColorBrush(Color.FromRgb(46, 128, 174));
            BackgroundPressed = new SolidColorBrush(Color.FromRgb(36, 102, 140));
            BackgroundDisabled = new SolidColorBrush(Color.FromRgb(183, 183, 183));


            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Hover]);
            bitMap.EndInit();
            IconHover = bitMap;



            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Regular]);
            bitMap.EndInit();
            IconRegular = bitMap;



            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Pressed]);
            bitMap.EndInit();
            IconPressed = bitMap;

            bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri(IconPathSourse[ButtonStateType.Dissabled]);
            bitMap.EndInit();
            IconDisabled = bitMap;
            if (!EmptyText)
            {
                Label = "Protect & Save";
            }

            _beckUpBackground=BackgroundRegular;
            _beckUpIcon = IconRegular;
    }

        public event EventHandler CxClick = null;
        private void ThisButton_Click(object sender, RoutedEventArgs e)
        {
            if(IsToggle)
            {
                Checked = !Checked;
            }
            if (CxClick != null)
            {
                CxClick.Invoke(this, e);
            }
            else
            {
                MessageBox.Show("ButtonClik is Empty");
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event MouseEventHandler CxMouseEnter;
        private void ThisButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if(CxMouseEnter!=null)
            {
                CxMouseEnter.Invoke(this, e);
            }

        }

        public event MouseEventHandler CxMouseLeave;
        private void ThisButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if(CxMouseLeave!=null)
            {
                CxMouseLeave.Invoke(this, e);
            }

        }

        #endregion
    }

    internal class ToggleFalseExeption : Exception
    {
        public ToggleFalseExeption()
        {
        }

        public ToggleFalseExeption(string message) : base(message)
        {
        }

        public ToggleFalseExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToggleFalseExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }


}
