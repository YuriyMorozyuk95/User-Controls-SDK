using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ClassificationButton.xaml
    /// </summary>

    public partial class ClassificationButton : UserControl, INotifyPropertyChanged 
    {

        #region Constructor
        public ClassificationButton()
        {
            InitializeComponent();
            DataContext = this;
            Selected = false;
            if(_dicMark.Count!=7)
                FactoryIcon();
            IcoFont = new FontFamily(new Uri("pack://application:,,,/"), "#Segoe MDL2 Assets");
            //Index = counter;
            counter++;

        }
        public ClassificationButton(ClassificationList parent)
        {
            InitializeComponent();
            DataContext = this;
            Selected = false;
            ColectionParent = parent;
            IcoFont = new FontFamily(new Uri("pack://application:,,,/"), "#Segoe MDL2 Assets");
            //Index = counter;
            counter++;

        }
        #endregion

        #region Field
        private string _text;
        private Brush _color;
        private Brush _colorMark;   
        private Brush _colorRect;
        private bool _selected;
        private string _contentText;
        private Visibility _visibilityMark;
        private Visibility _visibilityLine;
        private FontFamily _icoFont;
        private bool _highlighted;
        private int? _sortindex=0;
        private ClassificationButtonCollection _container;
        static int counter = 0;
        private static Dictionary<string, BitmapImage> _dicMark = new Dictionary<string, BitmapImage>();
        #endregion

        #region Property
        
        public ImageSource MarkImage
        {
            get
            {
                return _markImage;
            }
            set
            {
                _markImage = value;
                
            }
        }
        public FontFamily IcoFont
        {
            get
            {
                return _icoFont;
            }
            set
            {
                _icoFont = value;
                Notify("IcoFont");
            }
        }
        public Visibility VisibilityMark
        {
            get
            {
                return _visibilityMark;
            }
            set
            {
                _visibilityMark = value;
                Notify("VisibilityMark");
            }
        }
        public Visibility VisibilityLine
        {
            get
            {
                return _visibilityLine;
            }
            set
            {
                _visibilityLine = value;
                Notify("VisibilityLine");
            }
        }
        public String Text
        {
            get { return ContentText; }

            set
            {
                if (value.Length > 22)
                {
                    value = value.Remove(22) + "...";
                }
                ContentText = value;
            }
        }
        public string ContentText
        {
            get
            {
                return _contentText;
            }
            set
            {
                _contentText = value;
                Notify("ContentText");
            }
        }
        public Brush Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

                ColorMark = value;
                ColorRect = value;
            }
        } 
        public Brush ColorMark
        {
            get
            {
                return _colorMark;
            }
            set
            {
                _colorMark = value;
                Notify("ColorMark");
            }
        }
        public Brush ColorRect
        {
            get
            {
                return _colorRect;
            }
            set
            {
                _colorRect = value;
                Notify("ColorRect");
            }
        }
        public bool? Selected
        {
            get { return _selected; }

            set
            {
                if ((bool)value)
                {
                    VisibilityMark = Visibility.Visible;
                }
                else
                {
                    VisibilityMark = Visibility.Hidden;
                }

                _selected = (bool)value;
            }
        }
        public bool Highlighted
        {
            get
            {
                return _highlighted;
            }
            set
            {
                if(value)
                {
                    this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb( 20 ,255, 255, 255));
                }
                else
                {
                    this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0 , 255, 255, 255)); ;
                }
                _highlighted = value;
            }
        }
        public int? SortIndex
        {
            get
            {
                return _sortindex;
            }
            set
            {
                _sortindex = value;
            }
        }
        public int? Index { get; set; }
        public ClassificationButtonCollection Container
        {
            get
            {
                return _container;
            }
            set
            {
                _container = value;
            }
        }
        public ClassificationList ColectionParent { get; set; }
      
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
        #endregion

        #region EventAndEventHandler
        public event MouseEventHandler CxMouseLeave;
        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CxMouseLeave != null)
            {
                CxMouseLeave.Invoke(this, e);
            }
        }

        
        private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Highlighted = !Highlighted;
            //if (CxRightButtonDown != null)
            //{
            //    CxRightButtonDown.Invoke(this, e);
            //}
        }

        public event MouseEventHandler CxMouseEnter;
        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CxMouseEnter != null)
            {
                CxMouseEnter.Invoke(this, e);
            }
        }

        public static RoutedEvent CxClickEvent;
        private bool _dropShadow;
        private string _nameMark;
        private ImageSource _markImage;

        public event RoutedEventHandler CxClick;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Selected = !Selected;
            Highlighted = !Highlighted;
            if (CxClick != null)
            {              
                CxClick.Invoke(this, e);
            }
            
            else
            {
               // CustomMessageBox.ShowMessageHandler("Click");
            }
            if (ColectionParent != null)
            {
                ColectionParent.InvokeSelectionChanged(this);
            }
        }
        public void OnClick()
        {

            if (CxClick != null)
            {
                Selected = !Selected;
                Highlighted = !Highlighted;
                CxClick.Invoke(this, new RoutedEventArgs());
            }
            else
            {
                Selected = !Selected;
                Highlighted = !Highlighted;
                CustomMessageBox.ShowMessageHandler("Click");

            }

        }


        public event RoutedEventHandler CxDoubleClick;
        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Highlighted = !Highlighted;
            if (CxDoubleClick != null)
            {
                CxDoubleClick.Invoke(this, e);
            }
            //CustomSelectionChangedEventArgs tmp;
            if (ColectionParent != null)
            {
                ColectionParent.InvokeSelectionChanged(this);
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

        
        public event MouseEventHandler CxRightClick;
        private void ThisButton_MouseRightButtonUp(object sender, MouseButtonEventArgs e) //addEvent
        {
            if (CxRightClick != null)
            {
                CxRightClick.Invoke(this, e);
            }
        }
        #endregion

        #region Method'
        public static ImageSource GetIcon(string nameIcon)
        {
            return _dicMark[nameIcon];
        }
        public  void FactoryIcon()
        {
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            var Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir+ @"\CxControlLibrary\Icon\ClassificationButtonCollection\RedMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();

            _dicMark.Add("Red", Icon);
            /////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/OrMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();

            _dicMark.Add("RedOrange", Icon);
            ///////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/OrYelMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();
            ////////

            _dicMark.Add("Orange", Icon);
            ////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/YelMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();

            _dicMark.Add("Yellow", Icon);

            ////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/GrenBlueMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();

            _dicMark.Add("Green", Icon);
            //////////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/AzurBlueMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();



            _dicMark.Add("Blue", Icon);
            //////////
            Icon = new BitmapImage();

            Icon.BeginInit();
            Icon.UriSource = new Uri(dir + @"/CxControlLibrary/Icon/ClassificationButtonCollection/WhiteMark.png", UriKind.RelativeOrAbsolute);
            Icon.EndInit();
            _dicMark.Add("White", Icon);

        }
        
        #endregion
    }

    partial class ClassificationButton: IComparable<ClassificationButton>
    {
        public bool SortBy { get; set; }

        public int CompareTo(ClassificationButton obj)
        {

            var element = obj as ClassificationButton;

           if (SortBy)
            {
                if (this.SortIndex < element.SortIndex)
                {
                    return -1;
                }
                else if (this.SortIndex == element.SortIndex)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                int i = 0;
                if (this.ContentText[0] < element.ContentText[0])
                {
                    return -1;
                }
                else if (this.ContentText[0] == element.ContentText[0])
                {
                    return this.CompareTo(element, ++i);
                }
                else
                {
                    return 1;
                }
            }
        }

        public int CompareTo(ClassificationButton element ,int i)
        {
            if (i == this.ContentText.Length || i == element.ContentText.Length)
            {
                return 0;
            }
            if (this.ContentText[i] < element.ContentText[i])
            {
                return -1;
            }
            else if (this.ContentText[i] == element.ContentText[i])
            {
                if(i == this.ContentText.Length || i == element.ContentText.Length)
                {
                    return 0;
                }
                return this.CompareTo(element, ++i);
            }
            else
            {
                return 1;
            }
        }
    }

  
}
