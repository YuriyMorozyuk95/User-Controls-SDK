using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CxListBoxItem.xaml
    /// </summary>
    public partial class CxListBoxItem : UserControl
    {
        public CxListBoxItem()
        {
            InitializeComponent();
            this.Tag = 1;
            this.Enabled = true;
            this.Label = "Label";
            Arrow.IsVisibleChanged += Arrow_IsVisibleChanged;
        }

        private void Arrow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           if(Arrow.Visibility == Visibility.Visible)
            {
                this.Padding = new Thickness(3, 0, 0, 0);
            }
           else
            {
                this.Padding = new Thickness(20, 0, 0, 0);
            }
        }

        private bool? _selected=false;
        private Brush _colorText;
        public static bool _hidingArrow = false;
        private bool _opionsOrUsers;

        public ImageSource Icon
        {
            get
            {
                return CxImage.Source;
            }
            set
            {
                if(value!=null)
                {
                    CxCheckBox.Visibility = Visibility.Visible;
                }
                CxImage.Source = value;
            }
        } //add Property
        public string Label
        {
            get
            {
                return CxText.Text;
            }
            set
            {
                CxText.Text = value;
            }
        } //add Property
        public Brush ColorText
        {
            get
            {
                return _colorText;
            }
            set
            {
                _colorText = value;
            }
        }
        public bool? Selected 
        {
            get
            {
                return _selected;
            }
            set
            {
                if ((bool)value)
                {
                    BackgroundItem.Fill = new SolidColorBrush(Color.FromRgb(114, 179, 216));
                    CxText.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    BackgroundItem.Fill = new SolidColorBrush(Colors.White);
                    CxText.Foreground = new SolidColorBrush(Colors.Black);
                }
                _selected = value;
            }
        }
        public bool Enabled
        {
            get
            {
                return IsEnabled;
            }
            set
            {
                IsEnabled = value;
            }
        } //add Property
        public void ShowArrow()
        {
            if (!HidingArrow)
            {
                Arrow.Visibility = Visibility.Visible;
            }
        }
        public void HideArrow()
        {
            Arrow.Visibility = Visibility.Collapsed;
        }
        public static bool HidingArrow
        {
            get
            {
                return _hidingArrow;
            }
            set
            {
                _hidingArrow = value;
            }
        }
        public bool OpionsOrUsers
        {
            get
            {
                return _opionsOrUsers;
            }
            set
            {
                if(value)
                {
                    Arrow.Visibility = Visibility.Collapsed;
                    CxCheckBox.Visibility = Visibility.Collapsed;
                    CxImage.Visibility = Visibility.Collapsed;
                    CxText.Visibility = Visibility.Visible;
                    CxText.Margin = new Thickness(12, 0, 0, 0);
                    BackgroundItem.SetValue(Grid.ColumnProperty, 0);
                    BackgroundItem.SetValue(Grid.ColumnSpanProperty, 4);
                }
                else
                {
                    this.Padding = new Thickness(20, 0, 0, 0);
                    Arrow.Visibility = Visibility.Collapsed;
                    CxCheckBox.Margin = new Thickness(12, 0, 0, 0);
                    CxCheckBox.Visibility = Visibility.Visible;
                    CxImage.Visibility = Visibility.Visible;
                    CxText.Visibility = Visibility.Visible;
                    CxText.Margin = new Thickness(0, 0, 0, 0);
                    BackgroundItem.SetValue(Grid.ColumnProperty, 1);
                    BackgroundItem.SetValue(Grid.ColumnSpanProperty, 3);
                }
                _opionsOrUsers = value;
            }
        }
    }
    public abstract class ListPerent : INotifyPropertyChanged, ICloneable
    {

        private CxListBoxItem _cxListBoxItem;
        public CxListBoxItem CxListBoxItem
        {
            get
            {
                return _cxListBoxItem;
            }
            set
            {
                _cxListBoxItem = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract object Clone();
    }

    public class Options : ListPerent
    {

        public Options(string option, Brush color, Brush background, int i) : base()
        {
            _option = option;
            _colorText = color;
            _background = background;
            index = i;

            CxListBoxItem = new CxListBoxItem()
            {
                Icon = null,
                Label = _option,
                ColorText = _colorText,
                OpionsOrUsers = true
            };
        }

        #region field

        private string _option;
        private Brush _colorText;

        private Brush _background;
        private Brush _foreground;
        #endregion

        #region Property
        public string Option
        {
            get
            {
                return _option;
            }
            set
            {
                _option = value;
                Notify("Options");
            }
        }
        public Brush ColorText
        {
            get
            {
                return _colorText;
            }
            set
            {
                _colorText = value;
                Notify("ColorText");
            }
        }
        public Brush Background
        {
            get
            {
                return _background;
            }
            set
            {

                _background = value;
                Notify("Background1");
            }
        }
        public Brush Foreground
        {
            get
            {
                return _foreground;
            }
            set
            {
                _background = value;
                Notify("Foreground");
            }
        }
        #endregion

        #region EventAndHandlers

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }



        #endregion

        #region Method
        public override object Clone()

        {
            if (this == null)
            {
                return null;
            }
            return this.MemberwiseClone();
        }
        #endregion
        public int index { get; set; }
    }


    public class Users : ListPerent
    {

        public Users(string user, ImageSource image, int i) : base()
        {
            _user = user;
            _image = image;
            index = i;
            CxListBoxItem = new CxListBoxItem()
            {
                Icon = image,
                Label = user,
                OpionsOrUsers = false
            };
        }

        #region field
        private string _user;
        private ImageSource _image;

        private Brush _background;
        private Brush _foreground;

        #endregion

        #region Property
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                Notify("User");
            }
        }
        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Notify("Image");
            }
        }

        public Brush Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                Notify("Background");
            }
        }
        public Brush Foreground
        {
            get
            {
                return _foreground;
            }
            set
            {
                _background = value;
                Notify("Foreground");
            }
        }

        #endregion

        #region EventAndHandlers

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Method
        public override object Clone()
        {
            if (this == null)
            {
                return null;
            }
            return this.MemberwiseClone();
        }
        #endregion

        public int index { get; set; }
    }
}
